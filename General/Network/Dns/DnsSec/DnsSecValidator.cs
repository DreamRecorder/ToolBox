using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading ;
using System . Threading . Tasks ;

using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;
using DreamRecorder . ToolBox . Network . Dns . Resolver ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsSec
{

	internal class DnsSecValidator <TState> where TState : IDnsSecValidatorContext
	{

		private readonly IInternalDnsSecResolver <TState> _resolver ;

		private readonly IResolverHintStore _resolverHintStore ;

		public DnsSecValidator ( IInternalDnsSecResolver <TState> resolver , IResolverHintStore resolverHintStore )
		{
			_resolver          = resolver ;
			_resolverHintStore = resolverHintStore ;
		}

		private static void CheckAndUpdatedResolvedDomains ( TState state , DomainName name , RecordType recordType )
		{
			if ( state . HasDomainAlreadyBeenResolvedInValidation ( name , recordType ) )
			{
				throw new DnsSecValidationException (
													 $"The domain '{name}' (record type '{recordType}') has already been resolved during the DNSSEC validation. Aborting validation to avoid endless loop." ) ;
			}

			state . AddResolvedDomainInValidation ( name , recordType ) ;
		}

		public async Task <DnsSecValidationResult> ValidateAsync <TRecord> (
			DomainName        name ,
			RecordType        recordType ,
			RecordClass       recordClass ,
			DnsMessage        msg ,
			List <TRecord>    resultRecords ,
			TState            state ,
			CancellationToken token ) where TRecord : DnsRecordBase
		{
			CheckAndUpdatedResolvedDomains ( state , name , recordType ) ;

			List <RrSigRecord> rrSigRecords = msg . AnswerRecords . OfType <RrSigRecord> ( ) .
													Union ( msg . AuthorityRecords . OfType <RrSigRecord> ( ) ) .
													Where (
														   x
															   => name . IsEqualOrSubDomainOf ( x . SignersName )
																  && ( x . SignatureInception  <= DateTime . Now )
																  && ( x . SignatureExpiration >= DateTime . Now ) ) .
													ToList ( ) ;

			if ( rrSigRecords . Count == 0 )
			{
				return await ValidateOptOut ( name , recordClass , state , token )
						   ? DnsSecValidationResult . Unsigned
						   : DnsSecValidationResult . Bogus ;
			}

			DomainName zoneApex = rrSigRecords . OrderByDescending ( x => x . Labels ) . First ( ) . SignersName ;

			if ( resultRecords . Count != 0 )
			{
				return await ValidateRrSigAsync (
												 name ,
												 recordType ,
												 recordClass ,
												 resultRecords ,
												 rrSigRecords ,
												 zoneApex ,
												 msg ,
												 state ,
												 token ) ;
			}

			return await ValidateNonExistenceAsync (
													name ,
													recordType ,
													recordClass ,
													rrSigRecords ,
													DomainName . Asterisk + zoneApex ,
													zoneApex ,
													msg ,
													state ,
													token ) ;
		}

		private async Task <DnsSecValidationResult> ValidateNonExistenceAsync (
			DomainName         name ,
			RecordType         recordType ,
			RecordClass        recordClass ,
			List <RrSigRecord> rrSigRecords ,
			DomainName         stop ,
			DomainName         zoneApex ,
			DnsMessageBase     msg ,
			TState             state ,
			CancellationToken  token )
		{
			DnsSecValidationResult nsecRes = await ValidateNSecAsync (
																	  name ,
																	  recordType ,
																	  recordClass ,
																	  rrSigRecords ,
																	  stop ,
																	  zoneApex ,
																	  msg ,
																	  state ,
																	  token ) ;
			if ( nsecRes == DnsSecValidationResult . Signed )
			{
				return nsecRes ;
			}

			DnsSecValidationResult nsec3Res = await ValidateNSec3Async (
																		name ,
																		recordType ,
																		recordClass ,
																		rrSigRecords ,
																		stop == DomainName . Asterisk + zoneApex ,
																		zoneApex ,
																		msg ,
																		state ,
																		token ) ;
			if ( nsec3Res == DnsSecValidationResult . Signed )
			{
				return nsec3Res ;
			}

			if ( ( nsecRes     == DnsSecValidationResult . Unsigned )
				 || ( nsec3Res == DnsSecValidationResult . Unsigned ) )
			{
				return DnsSecValidationResult . Unsigned ;
			}

			if ( ( nsecRes     == DnsSecValidationResult . Bogus )
				 || ( nsec3Res == DnsSecValidationResult . Bogus ) )
			{
				return DnsSecValidationResult . Bogus ;
			}

			return DnsSecValidationResult . Indeterminate ;
		}

		private async Task <DnsSecValidationResult> ValidateNSec3Async (
			DomainName         name ,
			RecordType         recordType ,
			RecordClass        recordClass ,
			List <RrSigRecord> rrSigRecords ,
			bool               checkWildcard ,
			DomainName         zoneApex ,
			DnsMessageBase     msg ,
			TState             state ,
			CancellationToken  token )
		{
			List <NSec3Record> nsecRecords = msg . AuthorityRecords . OfType <NSec3Record> ( ) . ToList ( ) ;

			if ( nsecRecords . Count == 0 )
			{
				return DnsSecValidationResult . Indeterminate ;
			}

			foreach ( IGrouping <DomainName , NSec3Record> nsecGroup in nsecRecords . GroupBy ( x => x . Name ) )
			{
				DnsSecValidationResult validationResult = await ValidateRrSigAsync (
														   nsecGroup . Key ,
														   RecordType . NSec3 ,
														   recordClass ,
														   nsecGroup . ToList ( ) ,
														   rrSigRecords ,
														   zoneApex ,
														   msg ,
														   state ,
														   token ) ;

				if ( validationResult != DnsSecValidationResult . Signed )
				{
					return validationResult ;
				}
			}

			var nsec3Parameter = nsecRecords . Where ( x => x . Name . GetParentName ( ) . Equals ( zoneApex ) ) .
											   Where ( x => x . HashAlgorithm . IsSupported ( ) ) .
											   Select (
													   x => new
															{
																x . HashAlgorithm , x . Iterations , x . Salt ,
															} ) .
											   OrderBy ( x => x . HashAlgorithm . GetPriority ( ) ) .
											   First ( ) ;

			DomainName hashedName = name . GetNsec3HashName (
															 nsec3Parameter . HashAlgorithm ,
															 nsec3Parameter . Iterations ,
															 nsec3Parameter . Salt ,
															 zoneApex ) ;

			if ( recordType == RecordType . Ds
				 && nsecRecords . Any ( x => ( x . Flags == 1 ) && ( x . IsCovering ( hashedName ) ) ) )
			{
				return DnsSecValidationResult . Unsigned ;
			}

			NSec3Record directMatch = nsecRecords . FirstOrDefault ( x => x . Name . Equals ( hashedName ) ) ;
			if ( directMatch != null )
			{
				return directMatch . Types . Contains ( recordType )
						   ? DnsSecValidationResult . Bogus
						   : DnsSecValidationResult . Signed ;
			}

			// find closest encloser
			DomainName current            = name ;
			DomainName previousHashedName = hashedName ;

			while ( true )
			{
				if ( nsecRecords . Any ( x => x . Name . Equals ( hashedName , true ) ) )
				{
					break ;
				}

				if ( current == zoneApex )
				{
					return
						DnsSecValidationResult .
							Bogus ; // closest encloser could not be found, but at least the zone apex must be found as
				}

				current            = current . GetParentName ( ) ;
				previousHashedName = hashedName ;
				hashedName = current . GetNsec3HashName (
														 nsec3Parameter . HashAlgorithm ,
														 nsec3Parameter . Iterations ,
														 nsec3Parameter . Salt ,
														 zoneApex ) ;
			}

			if ( ! nsecRecords . Any ( x => x . IsCovering ( previousHashedName ) ) )
			{
				return DnsSecValidationResult . Bogus ;
			}

			if ( checkWildcard )
			{
				DomainName wildcardHashName =
					( DomainName . Asterisk + current ) . GetNsec3HashName (
																			nsec3Parameter . HashAlgorithm ,
																			nsec3Parameter . Iterations ,
																			nsec3Parameter . Salt ,
																			zoneApex ) ;

				NSec3Record wildcardDirectMatch =
					nsecRecords . FirstOrDefault ( x => x . Name . Equals ( wildcardHashName ) ) ;
				if ( ( wildcardDirectMatch != null )
					 && ( ! wildcardDirectMatch . Types . Contains ( recordType ) ) )
				{
					return wildcardDirectMatch . Types . Contains ( recordType )
							   ? DnsSecValidationResult . Bogus
							   : DnsSecValidationResult . Signed ;
				}

				NSec3Record wildcardCoveringMatch =
					nsecRecords . FirstOrDefault ( x => x . IsCovering ( wildcardHashName ) ) ;
				return ( wildcardCoveringMatch != null )
						   ? DnsSecValidationResult . Signed
						   : DnsSecValidationResult . Bogus ;
			}
			else
			{
				return DnsSecValidationResult . Signed ;
			}
		}

		private async Task <DnsSecValidationResult> ValidateNSecAsync (
			DomainName         name ,
			RecordType         recordType ,
			RecordClass        recordClass ,
			List <RrSigRecord> rrSigRecords ,
			DomainName         stop ,
			DomainName         zoneApex ,
			DnsMessageBase     msg ,
			TState             state ,
			CancellationToken  token )
		{
			List <NSecRecord> nsecRecords = msg . AuthorityRecords . OfType <NSecRecord> ( ) . ToList ( ) ;

			if ( nsecRecords . Count == 0 )
			{
				return DnsSecValidationResult . Indeterminate ;
			}

			foreach ( IGrouping <DomainName , NSecRecord> nsecGroup in nsecRecords . GroupBy ( x => x . Name ) )
			{
				DnsSecValidationResult validationResult = await ValidateRrSigAsync (
														   nsecGroup . Key ,
														   RecordType . NSec ,
														   recordClass ,
														   nsecGroup . ToList ( ) ,
														   rrSigRecords ,
														   zoneApex ,
														   msg ,
														   state ,
														   token ) ;

				if ( validationResult != DnsSecValidationResult . Signed )
				{
					return validationResult ;
				}
			}

			DomainName current = name ;

			while ( true )
			{
				if ( current . Equals ( stop ) )
				{
					return DnsSecValidationResult . Signed ;
				}

				NSecRecord nsecRecord = nsecRecords . FirstOrDefault ( x => x . Name . Equals ( current ) ) ;
				if ( nsecRecord != null )
				{
					return nsecRecord . Types . Contains ( recordType )
							   ? DnsSecValidationResult . Bogus
							   : DnsSecValidationResult . Signed ;
				}
				else
				{
					nsecRecord = nsecRecords . FirstOrDefault ( x => x . IsCovering ( current , zoneApex ) ) ;
					if ( nsecRecord == null )
					{
						return DnsSecValidationResult . Bogus ;
					}
				}

				// Updated the following lines to fix an issue where an NSEC entry is present for a parent domain but is not a wildcard entry.
				if ( current . Labels [ 0 ] == "*" )
				{
					current = current . GetParentName ( ) ;
				}
				else
				{
					current = DomainName . Asterisk + current . GetParentName ( ) ;
				}
			}
		}

		private async Task <bool> ValidateOptOut (
			DomainName        name ,
			RecordClass       recordClass ,
			TState            state ,
			CancellationToken token )
		{
			while ( name != DomainName . Root )
			{
				DnsMessage msg =
					await _resolver . ResolveMessageAsync ( name , RecordType . Ds , recordClass , state , token ) ;

				if ( ( msg == null )
					 || ( ( msg . ReturnCode    != ReturnCode . NoError )
						  && ( msg . ReturnCode != ReturnCode . NxDomain ) ) )
				{
					throw new Exception ( "DNS request failed" ) ;
				}

				List <RrSigRecord> rrSigRecords = msg . AnswerRecords . OfType <RrSigRecord> ( ) .
														Union ( msg . AuthorityRecords . OfType <RrSigRecord> ( ) ) .
														Where (
															   x
																   => name . IsEqualOrSubDomainOf ( x . SignersName )
																	  && ( x . SignatureInception <= DateTime . Now )
																	  && ( x . SignatureExpiration
																		   >= DateTime . Now ) ) .
														ToList ( ) ;

				if ( rrSigRecords . Count != 0 )
				{
					DomainName zoneApex =
						rrSigRecords . OrderByDescending ( x => x . Labels ) . First ( ) . SignersName ;

					DnsSecValidationResult nonExistenceValidation =
						await ValidateNonExistenceAsync (
														 name ,
														 RecordType . Ds ,
														 recordClass ,
														 rrSigRecords ,
														 name ,
														 zoneApex ,
														 msg ,
														 state ,
														 token ) ;
					if ( ( nonExistenceValidation    != DnsSecValidationResult . Bogus )
						 && ( nonExistenceValidation != DnsSecValidationResult . Indeterminate ) )
					{
						return true ;
					}
				}

				name = name . GetParentName ( ) ;
			}

			return false ;
		}

		private async Task <DnsSecValidationResult> ValidateRrSigAsync <TRecord> (
			DomainName         name ,
			RecordType         recordType ,
			RecordClass        recordClass ,
			List <TRecord>     resultRecords ,
			List <RrSigRecord> rrSigRecords ,
			DomainName         zoneApex ,
			DnsMessageBase     msg ,
			TState             state ,
			CancellationToken  token ) where TRecord : DnsRecordBase
		{
			DnsSecValidationResult res = DnsSecValidationResult . Bogus ;

			foreach ( RrSigRecord record in rrSigRecords . Where (
																  x
																	  => x . Name . Equals ( name )
																		 && ( x . TypeCovered == recordType ) ) )
			{
				res = await VerifyAsync ( record , resultRecords , recordClass , state , token ) ;
				if ( res == DnsSecValidationResult . Signed )
				{
					if ( ( record . Labels == name . LabelCount )
						 || ( ( name . Labels [ 0 ] == "*" ) && ( record . Labels == name . LabelCount - 1 ) ) )
					{
						return DnsSecValidationResult . Signed ;
					}

					if ( await ValidateNonExistenceAsync (
														  name ,
														  recordType ,
														  recordClass ,
														  rrSigRecords ,
														  DomainName . Asterisk
														  + record . Name . GetParentName (
														   record . Name . LabelCount - record . Labels ) ,
														  zoneApex ,
														  msg ,
														  state ,
														  token )
						 == DnsSecValidationResult . Signed )
					{
						return DnsSecValidationResult . Signed ;
					}
				}
			}

			return res ;
		}

		private async Task <DnsSecValidationResult> VerifyAsync <TRecord> (
			RrSigRecord       rrSigRecord ,
			List <TRecord>    coveredRecords ,
			RecordClass       recordClass ,
			TState            state ,
			CancellationToken token ) where TRecord : DnsRecordBase
		{
			if ( rrSigRecord . TypeCovered == RecordType . DnsKey )
			{
				List <DsRecord> dsRecords ;

				if ( rrSigRecord . SignersName . Equals ( DomainName . Root ) )
				{
					dsRecords = _resolverHintStore . RootKeys ;
				}
				else
				{
					DnsSecResult <DsRecord> dsRecordResults =
						await _resolver . ResolveSecureAsync <DsRecord> (
																		 rrSigRecord . SignersName ,
																		 RecordType . Ds ,
																		 recordClass ,
																		 state ,
																		 token ) ;

					if ( ( dsRecordResults . ValidationResult    == DnsSecValidationResult . Bogus )
						 || ( dsRecordResults . ValidationResult == DnsSecValidationResult . Indeterminate ) )
					{
						throw new DnsSecValidationException ( "DS records could not be retrieved" ) ;
					}

					if ( dsRecordResults . ValidationResult == DnsSecValidationResult . Unsigned )
					{
						return DnsSecValidationResult . Unsigned ;
					}

					dsRecords = dsRecordResults . Records ;
				}

				return dsRecords . Any (
										dsRecord => rrSigRecord . Verify (
																		  coveredRecords ,
																		  coveredRecords . Cast <DnsKeyRecord> ( ) .
																			  Where ( dsRecord . IsCovering ) .
																			  ToList ( ) ) )
						   ? DnsSecValidationResult . Signed
						   : DnsSecValidationResult . Bogus ;
			}
			else
			{
				DnsSecResult <DnsKeyRecord> dnsKeyRecordResults =
					await _resolver . ResolveSecureAsync <DnsKeyRecord> (
																		 rrSigRecord . SignersName ,
																		 RecordType . DnsKey ,
																		 recordClass ,
																		 state ,
																		 token ) ;

				if ( ( dnsKeyRecordResults . ValidationResult    == DnsSecValidationResult . Bogus )
					 || ( dnsKeyRecordResults . ValidationResult == DnsSecValidationResult . Indeterminate ) )
				{
					throw new DnsSecValidationException ( "DNSKEY records could not be retrieved" ) ;
				}

				if ( dnsKeyRecordResults . ValidationResult == DnsSecValidationResult . Unsigned )
				{
					return DnsSecValidationResult . Unsigned ;
				}

				return rrSigRecord . Verify ( coveredRecords , dnsKeyRecordResults . Records )
						   ? DnsSecValidationResult . Signed
						   : DnsSecValidationResult . Bogus ;
			}
		}

	}

}

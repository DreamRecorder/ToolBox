﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;
using System . Threading ;
using System . Threading . Tasks ;

using DreamRecorder . ToolBox . Network . Dns . Cache ;
using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;
using DreamRecorder . ToolBox . Network . Dns . DnsSec ;

namespace DreamRecorder . ToolBox . Network . Dns . Resolver
{

	/// <summary>
	///     <para>Self validating security aware stub resolver</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc4033">RFC 4033</see>
	///         ,
	///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
	///         and
	///         <see cref="!:http://tools.ietf.org/html/rfc4035">RFC 4035</see>
	///     </para>
	/// </summary>
	public class SelfValidatingInternalDnsSecStubResolver
		: IDnsSecResolver , IInternalDnsSecResolver <DnsSecValidatorContext>
	{

		private readonly DnsClient _dnsClient ;

		private readonly DnsSecValidator <DnsSecValidatorContext> _validator ;

		private DnsCache _cache ;

		/// <summary>
		///     Provides a new instance using a custom
		///     <see cref="DnsClient">DNS client</see>
		/// </summary>
		/// <param name="dnsClient">
		///     The
		///     <see cref="DnsClient">DNS client</see>
		///     to use
		/// </param>
		/// <param name="resolverHintStore"> The resolver hint store with the root DnsKey hints</param>
		public SelfValidatingInternalDnsSecStubResolver (
			DnsClient          dnsClient         = null ,
			IResolverHintStore resolverHintStore = null )
		{
			_dnsClient = dnsClient ?? DnsClient . Default ;
			_cache     = new DnsCache ( ) ;
			_validator =
				new DnsSecValidator <DnsSecValidatorContext> (
															  this ,
															  resolverHintStore ?? new StaticResolverHintStore ( ) ) ;
		}

		/// <summary>
		///     Provides a new instance using a list of custom DNS servers and a default query timeout of 10 seconds
		/// </summary>
		/// <param name="servers"> The list of servers to use </param>
		public SelfValidatingInternalDnsSecStubResolver ( IEnumerable <IPAddress> servers ) : this ( servers , 10000 )
		{
		}

		/// <summary>
		///     Provides a new instance using a list of custom DNS servers and a custom query timeout
		/// </summary>
		/// <param name="servers"> The list of servers to use </param>
		/// <param name="queryTimeout"> The query timeout in milliseconds </param>
		public SelfValidatingInternalDnsSecStubResolver ( IEnumerable <IPAddress> servers , int queryTimeout ) :
			this ( new DnsClient ( servers , queryTimeout ) )
		{
		}

		/// <summary>
		///     Resolves specified records.
		/// </summary>
		/// <typeparam name="T"> Type of records, that should be returned </typeparam>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="recordClass"> Class the should be queried </param>
		/// <returns>
		///     A list of matching
		///     <see cref="DnsRecordBase">records</see>
		/// </returns>
		public List <T> Resolve <T> (
			DomainName  name ,
			RecordType  recordType  = RecordType . A ,
			RecordClass recordClass = RecordClass . INet ) where T : DnsRecordBase
		{
			Task <List <T>> res = ResolveAsync <T> ( name , recordType , recordClass ) ;
			res . Wait ( ) ;
			return res . Result ;
		}

		/// <summary>
		///     Resolves specified records as an asynchronous operation.
		/// </summary>
		/// <typeparam name="T"> Type of records, that should be returned </typeparam>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="recordClass"> Class the should be queried </param>
		/// <param name="token"> The token to monitor cancellation requests </param>
		/// <returns>
		///     A list of matching
		///     <see cref="DnsRecordBase">records</see>
		/// </returns>
		public async Task <List <T>> ResolveAsync <T> (
			DomainName        name ,
			RecordType        recordType  = RecordType . A ,
			RecordClass       recordClass = RecordClass . INet ,
			CancellationToken token       = default ( CancellationToken ) ) where T : DnsRecordBase
		{
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) , "Name must be provided" ) ;
			}

			DnsSecResult <T> res = await ResolveSecureAsync <T> ( name , recordType , recordClass , token ) ;

			return res . Records ;
		}

		/// <summary>
		///     Resolves specified records.
		/// </summary>
		/// <typeparam name="T"> Type of records, that should be returned </typeparam>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="recordClass"> Class the should be queried </param>
		/// <returns>
		///     A list of matching
		///     <see cref="DnsRecordBase">records</see>
		/// </returns>
		public DnsSecResult <T> ResolveSecure <T> (
			DomainName  name ,
			RecordType  recordType  = RecordType . A ,
			RecordClass recordClass = RecordClass . INet ) where T : DnsRecordBase
		{
			Task <DnsSecResult <T>> res = ResolveSecureAsync <T> ( name , recordType , recordClass ) ;
			res . Wait ( ) ;
			return res . Result ;
		}

		/// <summary>
		///     Resolves specified records as an asynchronous operation.
		/// </summary>
		/// <typeparam name="T"> Type of records, that should be returned </typeparam>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="recordClass"> Class the should be queried </param>
		/// <param name="token"> The token to monitor cancellation requests </param>
		/// <returns>
		///     A list of matching
		///     <see cref="DnsRecordBase">records</see>
		/// </returns>
		public Task <DnsSecResult <T>> ResolveSecureAsync <T> (
			DomainName        name ,
			RecordType        recordType  = RecordType . A ,
			RecordClass       recordClass = RecordClass . INet ,
			CancellationToken token       = default ( CancellationToken ) ) where T : DnsRecordBase
			=> ResolveSecureInternalAsync <T> (
											   name ,
											   recordType ,
											   recordClass ,
											   new DnsSecValidatorContext ( ) ,
											   token ) ;

		/// <summary>
		///     Clears the record cache
		/// </summary>
		public void ClearCache ( ) { _cache = new DnsCache ( ) ; }

		Task <DnsMessage> IInternalDnsSecResolver <DnsSecValidatorContext> . ResolveMessageAsync (
			DomainName             name ,
			RecordType             recordType ,
			RecordClass            recordClass ,
			DnsSecValidatorContext state ,
			CancellationToken      token )
			=> _dnsClient . ResolveAsync (
										  name ,
										  RecordType . Ds ,
										  recordClass ,
										  new DnsQueryOptions
										  {
											  IsEDnsEnabled      = true ,
											  IsDnsSecOk         = true ,
											  IsCheckingDisabled = true ,
											  IsRecursionDesired = true ,
										  } ,
										  token ) ;

		Task <DnsSecResult <TRecord>> IInternalDnsSecResolver <DnsSecValidatorContext> . ResolveSecureAsync <TRecord> (
			DomainName             name ,
			RecordType             recordType ,
			RecordClass            recordClass ,
			DnsSecValidatorContext state ,
			CancellationToken      token )
			=> ResolveSecureInternalAsync <TRecord> ( name , recordType , recordClass , state , token ) ;

		private async Task <DnsSecResult <T>> ResolveSecureInternalAsync <T> (
			DomainName             name ,
			RecordType             recordType ,
			RecordClass            recordClass ,
			DnsSecValidatorContext state ,
			CancellationToken      token ) where T : DnsRecordBase
		{
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) , "Name must be provided" ) ;
			}

			if ( _cache . TryGetRecords ( name , recordType , recordClass , out DnsCacheRecordList <T> cacheResult ) )
			{
				return new DnsSecResult <T> (
											 cacheResult . ReturnCode ,
											 cacheResult ,
											 cacheResult . ValidationResult ) ;
			}

			DnsMessage msg = await _dnsClient . ResolveAsync (
															  name ,
															  recordType ,
															  recordClass ,
															  new DnsQueryOptions
															  {
																  IsEDnsEnabled      = true ,
																  IsDnsSecOk         = true ,
																  IsCheckingDisabled = true ,
																  IsRecursionDesired = true ,
															  } ,
															  token ) ;

			if ( ( msg == null )
				 || ( ( msg . ReturnCode != ReturnCode . NoError ) && ( msg . ReturnCode != ReturnCode . NxDomain ) ) )
			{
				throw new Exception ( "DNS request failed" ) ;
			}

			DnsSecValidationResult validationResult ;

			CNameRecord cName = msg . AnswerRecords .
									  Where (
											 x => ( x . RecordType     == RecordType . CName )
												  && ( x . RecordClass == recordClass )
												  && x . Name . Equals ( name ) ) .
									  OfType <CNameRecord> ( ) .
									  FirstOrDefault ( ) ;

			if ( cName != null )
			{
				DnsSecValidationResult cNameValidationResult =
					await _validator . ValidateAsync (
													  name ,
													  RecordType . CName ,
													  recordClass ,
													  msg ,
													  new List <CNameRecord> { cName , } ,
													  state ,
													  token ) ;
				if ( cNameValidationResult is DnsSecValidationResult . Bogus or DnsSecValidationResult . Indeterminate )
				{
					throw new DnsSecValidationException ( "CNAME record could not be validated" ) ;
				}

				List <T> records = msg . AnswerRecords .
										 Where (
												x => ( x . RecordType     == recordType )
													 && ( x . RecordClass == recordClass )
													 && x . Name . Equals ( cName . CanonicalName ) ) .
										 OfType <T> ( ) .
										 ToList ( ) ;
				if ( records . Count > 0 )
				{
					DnsSecValidationResult recordsValidationResult =
						await _validator . ValidateAsync (
														  cName . CanonicalName ,
														  recordType ,
														  recordClass ,
														  msg ,
														  records ,
														  state ,
														  token ) ;
					if ( recordsValidationResult is DnsSecValidationResult . Bogus
						 or DnsSecValidationResult . Indeterminate )
					{
						throw new DnsSecValidationException ( "CNAME matching records could not be validated" ) ;
					}

					validationResult = cNameValidationResult == recordsValidationResult
										   ? cNameValidationResult
										   : DnsSecValidationResult . Unsigned ;
					_cache . Add (
								  name ,
								  recordType ,
								  recordClass ,
								  records ,
								  msg . ReturnCode ,
								  validationResult ,
								  Math . Min ( cName . TimeToLive , records . Min ( x => x . TimeToLive ) ) ) ;

					return new DnsSecResult <T> ( msg . ReturnCode , records , validationResult ) ;
				}

				if ( name . Equals ( cName . CanonicalName ) )
				{
					throw new Exception ( $"CNAME loop detected for '{name}'." ) ;
				}

				DnsSecResult <T> cNameResults =
					await ResolveSecureAsync <T> ( cName . CanonicalName , recordType , recordClass , token ) ;
				validationResult = cNameValidationResult == cNameResults . ValidationResult
									   ? cNameValidationResult
									   : DnsSecValidationResult . Unsigned ;

				if ( cNameResults . Records . Count > 0 )
				{
					_cache . Add (
								  name ,
								  recordType ,
								  recordClass ,
								  cNameResults . Records ,
								  msg . ReturnCode ,
								  validationResult ,
								  Math . Min (
											  cName . TimeToLive ,
											  cNameResults . Records . Min ( x => x . TimeToLive ) ) ) ;
				}

				return new DnsSecResult <T> ( msg . ReturnCode , cNameResults . Records , validationResult ) ;
			}

			List <T> res = msg . AnswerRecords .
								 Where (
										x => ( x . RecordType     == recordType )
											 && ( x . RecordClass == recordClass )
											 && x . Name . Equals ( name ) ) .
								 OfType <T> ( ) .
								 ToList ( ) ;

			validationResult =
				await _validator . ValidateAsync ( name , recordType , recordClass , msg , res , state , token ) ;

			if ( validationResult is DnsSecValidationResult . Bogus or DnsSecValidationResult . Indeterminate )
			{
				throw new DnsSecValidationException ( "Response records could not be validated" ) ;
			}

			if ( res . Count > 0 )
			{
				_cache . Add (
							  name ,
							  recordType ,
							  recordClass ,
							  res ,
							  msg . ReturnCode ,
							  validationResult ,
							  res . Min ( x => x . TimeToLive ) ) ;
			}

			return new DnsSecResult <T> ( msg . ReturnCode , res , validationResult ) ;
		}

	}

}

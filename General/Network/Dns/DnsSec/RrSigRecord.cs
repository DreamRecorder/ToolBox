﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Globalization ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;
using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsSec
{

	/// <summary>
	///     <para>Record signature record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
	///         and
	///         <see cref="!:http://tools.ietf.org/html/rfc3755">RFC 3755</see>
	///     </para>
	/// </summary>
	public class RrSigRecord : DnsRecordBase
	{

		/// <summary>
		///     <see cref="DnsSecAlgorithm">Algorithm</see>
		///     that is used for signature
		/// </summary>
		public DnsSecAlgorithm Algorithm { get ; private set ; }

		/// <summary>
		///     Key tag
		/// </summary>
		public ushort KeyTag { get ; private set ; }

		/// <summary>
		///     Label count of original record that is covered by this record
		/// </summary>
		public byte Labels { get ; private set ; }

		protected internal override int MaximumRecordDataLength
			=> 20 + SignersName . MaximumRecordDataLength + Signature . Length ;

		/// <summary>
		///     Original time to live value of original record that is covered by this record
		/// </summary>
		public int OriginalTimeToLive { get ; private set ; }

		/// <summary>
		///     Binary data of the signature
		/// </summary>
		public byte [ ] Signature { get ; internal set ; }

		/// <summary>
		///     Signature is valid until this date
		/// </summary>
		public DateTime SignatureExpiration { get ; private set ; }

		/// <summary>
		///     Signature is valid from this date
		/// </summary>
		public DateTime SignatureInception { get ; private set ; }

		/// <summary>
		///     Domain name of generator of the signature
		/// </summary>
		public DomainName SignersName { get ; private set ; }

		/// <summary>
		///     <see cref="RecordType">Record type</see>
		///     that is covered by this record
		/// </summary>
		public RecordType TypeCovered { get ; private set ; }

		internal RrSigRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the RrSigRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="recordClass"> Class of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="typeCovered">
		///     <see cref="RecordType">Record type</see>
		///     that is covered by this record
		/// </param>
		/// <param name="algorithm">
		///     <see cref="DnsSecAlgorithm">Algorithm</see>
		///     that is used for signature
		/// </param>
		/// <param name="labels"> Label count of original record that is covered by this record </param>
		/// <param name="originalTimeToLive"> Original time to live value of original record that is covered by this record </param>
		/// <param name="signatureExpiration"> Signature is valid until this date </param>
		/// <param name="signatureInception"> Signature is valid from this date </param>
		/// <param name="keyTag"> Key tag </param>
		/// <param name="signersName"> Domain name of generator of the signature </param>
		/// <param name="signature"> Binary data of the signature </param>
		public RrSigRecord (
			DomainName      name ,
			RecordClass     recordClass ,
			int             timeToLive ,
			RecordType      typeCovered ,
			DnsSecAlgorithm algorithm ,
			byte            labels ,
			int             originalTimeToLive ,
			DateTime        signatureExpiration ,
			DateTime        signatureInception ,
			ushort          keyTag ,
			DomainName      signersName ,
			byte [ ]        signature ) : base ( name , RecordType . RrSig , recordClass , timeToLive )
		{
			TypeCovered         = typeCovered ;
			Algorithm           = algorithm ;
			Labels              = labels ;
			OriginalTimeToLive  = originalTimeToLive ;
			SignatureExpiration = signatureExpiration ;
			SignatureInception  = signatureInception ;
			KeyTag              = keyTag ;
			SignersName         = signersName ?? DomainName . Root ;
			Signature           = signature   ?? new byte [ ] { } ;
		}

		internal RrSigRecord (
			List <DnsRecordBase> records ,
			DnsKeyRecord         key ,
			DateTime             inception ,
			DateTime             expiration ) : base (
													  records [ 0 ] . Name ,
													  RecordType . RrSig ,
													  records [ 0 ] . RecordClass ,
													  records [ 0 ] . TimeToLive )
		{
			TypeCovered = records [ 0 ] . RecordType ;
			Algorithm   = key . Algorithm ;
			Labels = ( byte )( records [ 0 ] . Name . Labels [ 0 ] == DomainName . Asterisk . Labels [ 0 ]
								   ? records [ 0 ] . Name . LabelCount - 1
								   : records [ 0 ] . Name . LabelCount ) ;
			OriginalTimeToLive  = records [ 0 ] . TimeToLive ;
			SignatureExpiration = expiration ;
			SignatureInception  = inception ;
			KeyTag              = key . CalculateKeyTag ( ) ;
			SignersName         = key . Name ;
			Signature           = new byte [ ] { } ;

			EncodeSigningBuffer ( records , out byte [ ] signBuffer , out int signBufferLength ) ;

			Signature = key . Sign ( signBuffer , signBufferLength ) ;
		}

		internal static void EncodeDateTime ( byte [ ] buffer , ref int currentPosition , DateTime value )
		{
			int timeStamp =
				( int )( value . ToUniversalTime ( )
						 - new DateTime ( 1970 , 1 , 1 , 0 , 0 , 0 , DateTimeKind . Utc ) ) . TotalSeconds ;
			DnsMessageBase . EncodeInt ( buffer , ref currentPosition , timeStamp ) ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			EncodeRecordData ( messageData , offset , ref currentPosition , domainNames , useCanonical , true ) ;
		}

		internal void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical ,
			bool                             encodeSignature )
		{
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , ( ushort )TypeCovered ) ;
			messageData [ currentPosition++ ] = ( byte )Algorithm ;
			messageData [ currentPosition++ ] = Labels ;
			DnsMessageBase . EncodeInt ( messageData , ref currentPosition , OriginalTimeToLive ) ;
			EncodeDateTime ( messageData , ref currentPosition , SignatureExpiration ) ;
			EncodeDateTime ( messageData , ref currentPosition , SignatureInception ) ;
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , KeyTag ) ;
			DnsMessageBase . EncodeDomainName (
											   messageData ,
											   offset ,
											   ref currentPosition ,
											   SignersName ,
											   null ,
											   useCanonical ) ;

			if ( encodeSignature )
			{
				DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , Signature ) ;
			}
		}

		private void EncodeSigningBuffer <T> ( List <T> records , out byte [ ] messageData , out int length )
			where T : DnsRecordBase
		{
			messageData =
				new byte[ 2
						  + MaximumRecordDataLength
						  - Signature . Length
						  + records . Sum ( x => x . MaximumLength ) ] ;
			length = 0 ;
			EncodeRecordData ( messageData , 0 , ref length , null , true , false ) ;
			foreach ( T record in records . OrderBy ( x => x ) )
			{
				if ( record . Name . LabelCount == Labels )
				{
					DnsMessageBase . EncodeDomainName ( messageData , 0 , ref length , record . Name , null , true ) ;
				}
				else if ( record . Name . LabelCount > Labels )
				{
					DnsMessageBase . EncodeDomainName (
													   messageData ,
													   0 ,
													   ref length ,
													   DomainName . Asterisk
													   + record . Name . GetParentName (
														record . Name . LabelCount - Labels ) ,
													   null ,
													   true ) ;
				}
				else
				{
					throw new Exception ( "Encoding of records with less labels than RrSigRecord is not allowed" ) ;
				}

				DnsMessageBase . EncodeUShort ( messageData , ref length , ( ushort )record . RecordType ) ;
				DnsMessageBase . EncodeUShort ( messageData , ref length , ( ushort )record . RecordClass ) ;
				DnsMessageBase . EncodeInt ( messageData , ref length , OriginalTimeToLive ) ;

				record . EncodeRecordBody ( messageData , 0 , ref length , null , true ) ;
			}
		}

		private static DateTime ParseDateTime ( byte [ ] buffer , ref int currentPosition )
		{
			int timeStamp = DnsMessageBase . ParseInt ( buffer , ref currentPosition ) ;
			return new DateTime ( 1970 , 1 , 1 , 0 , 0 , 0 , DateTimeKind . Utc ) . AddSeconds ( timeStamp ) .
				ToLocalTime ( ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			int currentPosition = startPosition ;

			TypeCovered         = ( RecordType )DnsMessageBase . ParseUShort ( resultData , ref currentPosition ) ;
			Algorithm           = ( DnsSecAlgorithm )resultData [ currentPosition++ ] ;
			Labels              = resultData [ currentPosition++ ] ;
			OriginalTimeToLive  = DnsMessageBase . ParseInt ( resultData , ref currentPosition ) ;
			SignatureExpiration = ParseDateTime ( resultData , ref currentPosition ) ;
			SignatureInception  = ParseDateTime ( resultData , ref currentPosition ) ;
			KeyTag              = DnsMessageBase . ParseUShort ( resultData , ref currentPosition ) ;
			SignersName         = DnsMessageBase . ParseDomainName ( resultData , ref currentPosition ) ;
			Signature = DnsMessageBase . ParseByteData (
														resultData ,
														ref currentPosition ,
														length + startPosition - currentPosition ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length < 9 )
			{
				throw new FormatException ( ) ;
			}

			TypeCovered        = RecordTypeHelper . ParseShortString ( stringRepresentation [ 0 ] ) ;
			Algorithm          = ( DnsSecAlgorithm )byte . Parse ( stringRepresentation [ 1 ] ) ;
			Labels             = byte . Parse ( stringRepresentation [ 2 ] ) ;
			OriginalTimeToLive = int . Parse ( stringRepresentation [ 3 ] ) ;
			SignatureExpiration = DateTime . ParseExact (
														 stringRepresentation [ 4 ] ,
														 "yyyyMMddHHmmss" ,
														 CultureInfo . InvariantCulture ,
														 DateTimeStyles . AssumeUniversal ) ;
			SignatureInception = DateTime . ParseExact (
														stringRepresentation [ 5 ] ,
														"yyyyMMddHHmmss" ,
														CultureInfo . InvariantCulture ,
														DateTimeStyles . AssumeUniversal ) ;
			KeyTag      = ushort . Parse ( stringRepresentation [ 6 ] ) ;
			SignersName = ParseDomainName ( origin , stringRepresentation [ 7 ] ) ;
			Signature   = string . Join ( string . Empty , stringRepresentation . Skip ( 8 ) ) . FromBase64String ( ) ;
		}

		internal override string RecordDataToString ( )
			=> TypeCovered . ToShortString ( )
			   + " "
			   + ( byte )Algorithm
			   + " "
			   + Labels
			   + " "
			   + OriginalTimeToLive
			   + " "
			   + SignatureExpiration . ToUniversalTime ( ) . ToString ( "yyyyMMddHHmmss" )
			   + " "
			   + SignatureInception . ToUniversalTime ( ) . ToString ( "yyyyMMddHHmmss" )
			   + " "
			   + KeyTag
			   + " "
			   + SignersName
			   + " "
			   + Signature . ToBase64String ( ) ;

		internal bool Verify <T> ( List <T> coveredRecords , IEnumerable <DnsKeyRecord> dnsKeys )
			where T : DnsRecordBase
		{
			EncodeSigningBuffer ( coveredRecords , out byte [ ] messageData , out int length ) ;

			return dnsKeys .
				   Where (
						  x => x . IsZoneKey
							   && ( x . Protocol == 3 )
							   && x . Algorithm . IsSupported ( )
							   && ( KeyTag == x . CalculateKeyTag ( ) ) ) .
				   Any ( x => x . Verify ( messageData , length , Signature ) ) ;
		}

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;
using DreamRecorder . ToolBox . Network . Dns . DnsSec ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Child Delegation signer</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc7344">RFC 7344</see>
	///     </para>
	/// </summary>
	public class CDsRecord : DnsRecordBase
	{

		/// <summary>
		///     Algorithm used
		/// </summary>
		public DnsSecAlgorithm Algorithm { get ; private set ; }

		/// <summary>
		///     Binary data of the digest
		/// </summary>
		public byte [ ] Digest { get ; private set ; }

		/// <summary>
		///     Type of the digest
		/// </summary>
		public DnsSecDigestType DigestType { get ; private set ; }

		/// <summary>
		///     Key tag
		/// </summary>
		public ushort KeyTag { get ; private set ; }

		protected internal override int MaximumRecordDataLength => 4 + Digest . Length ;

		internal CDsRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the CDsRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="recordClass"> Class of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="keyTag"> Key tag </param>
		/// <param name="algorithm"> Algorithm used </param>
		/// <param name="digestType"> Type of the digest </param>
		/// <param name="digest"> Binary data of the digest </param>
		public CDsRecord (
			DomainName       name ,
			RecordClass      recordClass ,
			int              timeToLive ,
			ushort           keyTag ,
			DnsSecAlgorithm  algorithm ,
			DnsSecDigestType digestType ,
			byte [ ]         digest ) : base ( name , RecordType . Ds , recordClass , timeToLive )
		{
			KeyTag     = keyTag ;
			Algorithm  = algorithm ;
			DigestType = digestType ;
			Digest     = digest ?? new byte [ ] { } ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , KeyTag ) ;
			messageData [ currentPosition++ ] = ( byte )Algorithm ;
			messageData [ currentPosition++ ] = ( byte )DigestType ;
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , Digest ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			KeyTag     = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			Algorithm  = ( DnsSecAlgorithm )resultData [ startPosition++ ] ;
			DigestType = ( DnsSecDigestType )resultData [ startPosition++ ] ;
			Digest     = DnsMessageBase . ParseByteData ( resultData , ref startPosition , length - 4 ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length < 4 )
			{
				throw new FormatException ( ) ;
			}

			KeyTag     = ushort . Parse ( stringRepresentation [ 0 ] ) ;
			Algorithm  = ( DnsSecAlgorithm )byte . Parse ( stringRepresentation [ 1 ] ) ;
			DigestType = ( DnsSecDigestType )byte . Parse ( stringRepresentation [ 2 ] ) ;
			Digest     = string . Join ( string . Empty , stringRepresentation . Skip ( 3 ) ) . FromBase16String ( ) ;
		}

		internal override string RecordDataToString ( )
			=> KeyTag + " " + ( byte )Algorithm + " " + ( byte )DigestType + " " + Digest . ToBase16String ( ) ;

	}

}

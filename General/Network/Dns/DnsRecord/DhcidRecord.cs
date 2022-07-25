using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Dynamic Host Configuration Protocol (DHCP) Information record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc4701">RFC 4701</see>
	///     </para>
	/// </summary>
	public class DhcidRecord : DnsRecordBase
	{

		/// <summary>
		///     Record data
		/// </summary>
		public byte [ ] RecordData { get ; private set ; }

		protected internal override int MaximumRecordDataLength => RecordData . Length ;

		internal DhcidRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the DhcidRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="recordData"> Record data </param>
		public DhcidRecord ( DomainName name , int timeToLive , byte [ ] recordData ) : base (
		name ,
		RecordType . Dhcid ,
		RecordClass . INet ,
		timeToLive )
		{
			RecordData = recordData ?? new byte [ ] { } ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			RecordData = DnsMessageBase . ParseByteData ( resultData , ref startPosition , length ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length < 1 )
			{
				throw new FormatException ( ) ;
			}

			RecordData = string . Join ( string . Empty , stringRepresentation ) . FromBase64String ( ) ;
		}

		internal override string RecordDataToString ( ) => RecordData . ToBase64String ( ) ;

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , RecordData ) ;
		}

	}

}

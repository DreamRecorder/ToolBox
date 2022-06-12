using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     Represent a dns record, which is not directly supported by this library
	/// </summary>
	public class UnknownRecord : DnsRecordBase
	{

		/// <summary>
		///     Binary data of the RDATA section of the record
		/// </summary>
		public byte [ ] RecordData { get ; private set ; }

		protected internal override int MaximumRecordDataLength => RecordData . Length ;

		internal UnknownRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the UnknownRecord class
		/// </summary>
		/// <param name="name"> Domain name of the record </param>
		/// <param name="recordType"> Record type </param>
		/// <param name="recordClass"> Record class </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="recordData"> Binary data of the RDATA section of the record </param>
		public UnknownRecord (
			DomainName  name ,
			RecordType  recordType ,
			RecordClass recordClass ,
			int         timeToLive ,
			byte [ ]    recordData ) : base ( name , recordType , recordClass , timeToLive )
		{
			RecordData = recordData ?? new byte [ ] { } ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			RecordData = DnsMessageBase . ParseByteData ( resultData , ref startPosition , length ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			ParseUnknownRecordData ( stringRepresentation ) ;
		}

		internal override string RecordDataToString ( )
			=> @"\# " + ( ( RecordData == null ) ? "0" : RecordData . Length + " " + RecordData . ToBase16String ( ) ) ;

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

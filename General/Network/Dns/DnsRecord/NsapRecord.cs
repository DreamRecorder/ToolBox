using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>NSAP address, NSAP style A record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc1706">RFC 1706</see>
	///         and
	///         <see cref="!:http://tools.ietf.org/html/rfc1348">RFC 1348</see>
	///     </para>
	/// </summary>
	public class NsapRecord : DnsRecordBase
	{

		/// <summary>
		///     Binary encoded NSAP data
		/// </summary>
		public byte [ ] RecordData { get ; private set ; }

		protected internal override int MaximumRecordDataLength => RecordData . Length ;

		internal NsapRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the NsapRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="recordData"> Binary encoded NSAP data </param>
		public NsapRecord ( DomainName name , int timeToLive , byte [ ] recordData ) : base (
																							name ,
																							RecordType . Nsap ,
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
			if ( stringRepresentation . Length != 1 )
			{
				throw new FormatException ( ) ;
			}

			if ( ! stringRepresentation [ 0 ] . StartsWith ( "0x" , StringComparison . InvariantCultureIgnoreCase ) )
			{
				throw new FormatException ( ) ;
			}

			RecordData = stringRepresentation [ 0 ] .
						Substring ( 2 ) .
						Replace ( "." , string . Empty ) .
						FromBase16String ( ) ;
		}

		internal override string RecordDataToString ( ) => "0x" + RecordData . ToBase16String ( ) ;

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

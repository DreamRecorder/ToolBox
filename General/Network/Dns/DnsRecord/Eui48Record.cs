using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>EUI48</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc7043">RFC 7043</see>
	///     </para>
	/// </summary>
	public class Eui48Record : DnsRecordBase
	{

		/// <summary>
		///     IP address of the host
		/// </summary>
		public byte [ ] Address { get ; private set ; }

		protected internal override int MaximumRecordDataLength => 6 ;

		internal Eui48Record ( ) { }

		/// <summary>
		///     Creates a new instance of the Eui48Record class
		/// </summary>
		/// <param name="name"> Domain name of the host </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="address"> The EUI48 address</param>
		public Eui48Record ( DomainName name , int timeToLive , byte [ ] address ) : base (
																							name ,
																							RecordType . Eui48 ,
																							RecordClass . INet ,
																							timeToLive )
			=> Address = address ?? new byte[ 6 ] ;

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Address = DnsMessageBase . ParseByteData ( resultData , ref startPosition , 6 ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 1 )
			{
				throw new NotSupportedException ( ) ;
			}

			Address = stringRepresentation [ 0 ] .
					Split ( '-' ) .
					Select ( x => Convert . ToByte ( x , 16 ) ) .
					ToArray ( ) ;

			if ( Address . Length != 6 )
			{
				throw new NotSupportedException ( ) ;
			}
		}

		internal override string RecordDataToString ( )
		{
			return string . Join ( "-" , Address . Select ( x => x . ToString ( "x2" ) ) . ToArray ( ) ) ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , Address ) ;
		}

	}

}

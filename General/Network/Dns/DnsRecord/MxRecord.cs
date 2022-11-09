using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Mail exchange</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
	///     </para>
	/// </summary>
	public class MxRecord : DnsRecordBase
	{

		/// <summary>
		///     Host name of the mail exchanger
		/// </summary>
		public DomainName ExchangeDomainName { get ; private set ; }

		protected internal override int MaximumRecordDataLength => ExchangeDomainName . MaximumRecordDataLength + 4 ;

		/// <summary>
		///     Preference of the record
		/// </summary>
		public ushort Preference { get ; private set ; }

		internal MxRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the MxRecord class
		/// </summary>
		/// <param name="name"> Name of the zone </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="preference"> Preference of the record </param>
		/// <param name="exchangeDomainName"> Host name of the mail exchanger </param>
		public MxRecord ( DomainName name , int timeToLive , ushort preference , DomainName exchangeDomainName ) :
			base ( name , RecordType . Mx , RecordClass . INet , timeToLive )
		{
			Preference         = preference ;
			ExchangeDomainName = exchangeDomainName ?? DomainName . Root ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , Preference ) ;
			DnsMessageBase . EncodeDomainName (
											   messageData ,
											   offset ,
											   ref currentPosition ,
											   ExchangeDomainName ,
											   domainNames ,
											   useCanonical ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Preference         = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			ExchangeDomainName = DnsMessageBase . ParseDomainName ( resultData , ref startPosition ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 2 )
			{
				throw new FormatException ( ) ;
			}

			Preference         = ushort . Parse ( stringRepresentation [ 0 ] ) ;
			ExchangeDomainName = ParseDomainName ( origin , stringRepresentation [ 1 ] ) ;
		}

		internal override string RecordDataToString ( ) => Preference + " " + ExchangeDomainName ;

	}

}

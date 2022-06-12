using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Key exchanger record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc2230">RFC 2230</see>
	///     </para>
	/// </summary>
	public class KxRecord : DnsRecordBase
	{

		/// <summary>
		///     Preference of the record
		/// </summary>
		public ushort Preference { get ; private set ; }

		/// <summary>
		///     Domain name of the exchange host
		/// </summary>
		public DomainName Exchanger { get ; private set ; }

		protected internal override int MaximumRecordDataLength => Exchanger . MaximumRecordDataLength + 4 ;

		internal KxRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the KxRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="preference"> Preference of the record </param>
		/// <param name="exchanger"> Domain name of the exchange host </param>
		public KxRecord ( DomainName name , int timeToLive , ushort preference , DomainName exchanger ) : base (
																												name ,
																												RecordType . Kx ,
																												RecordClass . INet ,
																												timeToLive )
		{
			Preference = preference ;
			Exchanger  = exchanger ?? DomainName . Root ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 2 )
			{
				throw new FormatException ( ) ;
			}

			Preference = ushort . Parse ( stringRepresentation [ 0 ] ) ;
			Exchanger  = ParseDomainName ( origin , stringRepresentation [ 1 ] ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Preference = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			Exchanger  = DnsMessageBase . ParseDomainName ( resultData , ref startPosition ) ;
		}

		internal override string RecordDataToString ( ) => Preference + " " + Exchanger ;

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
												Exchanger ,
												domainNames ,
												useCanonical ) ;
		}

	}

}

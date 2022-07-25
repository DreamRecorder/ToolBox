using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Uniform Resource Identifier</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc7553">RFC 7553</see>
	///     </para>
	/// </summary>
	public class UriRecord : DnsRecordBase
	{

		/// <summary>
		///     Priority
		/// </summary>
		public ushort Priority { get ; private set ; }

		/// <summary>
		///     Weight
		/// </summary>
		public ushort Weight { get ; private set ; }

		/// <summary>
		///     Target
		/// </summary>
		public string Target { get ; private set ; }

		protected internal override int MaximumRecordDataLength => Target . Length + 4 ;

		internal UriRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the MxRecord class
		/// </summary>
		/// <param name="name"> Name of the zone </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="priority"> Priority of the record </param>
		/// <param name="weight"> Weight of the record </param>
		/// <param name="target"> Target of the record </param>
		public UriRecord ( DomainName name , int timeToLive , ushort priority , ushort weight , string target ) : base (
		name ,
		RecordType . Uri ,
		RecordClass . INet ,
		timeToLive )
		{
			Priority = priority ;
			Weight   = weight ;
			Target   = target ?? string . Empty ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Priority = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			Weight   = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			Target   = DnsMessageBase . ParseText ( resultData , ref startPosition , length - 4 ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 3 )
			{
				throw new FormatException ( ) ;
			}

			Priority = ushort . Parse ( stringRepresentation [ 0 ] ) ;
			Weight   = ushort . Parse ( stringRepresentation [ 1 ] ) ;
			Target   = stringRepresentation [ 2 ] ;
		}

		internal override string RecordDataToString ( ) => Priority + " " + Weight + " \"" + Target + "\"" ;

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , Priority ) ;
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , Weight ) ;
			DnsMessageBase . EncodeTextWithoutLength ( messageData , ref currentPosition , Target ) ;
		}

	}

}

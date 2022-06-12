using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>CAA</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc6844">RFC 6844</see>
	///     </para>
	/// </summary>

	// ReSharper disable once InconsistentNaming
	public class CAARecord : DnsRecordBase
	{

		/// <summary>
		///     The flags
		/// </summary>
		public byte Flags { get ; private set ; }

		/// <summary>
		///     The name of the tag
		/// </summary>
		public string Tag { get ; private set ; }

		/// <summary>
		///     The value of the tag
		/// </summary>
		public string Value { get ; private set ; }

		protected internal override int MaximumRecordDataLength => 2 + Tag . Length + Value . Length ;

		internal CAARecord ( ) { }

		/// <summary>
		///     Creates a new instance of the CAARecord class
		/// </summary>
		/// <param name="name"> Name of the zone </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="flags">The flags</param>
		/// <param name="tag">The name of the tag</param>
		/// <param name="value">The value of the tag</param>
		public CAARecord ( DomainName name , int timeToLive , byte flags , string tag , string value ) : base (
																												name ,
																												RecordType . CAA ,
																												RecordClass . INet ,
																												timeToLive )
		{
			Flags = flags ;
			Tag   = tag ;
			Value = value ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Flags = resultData [ startPosition++ ] ;
			Tag   = DnsMessageBase . ParseText ( resultData , ref startPosition ) ;
			Value = DnsMessageBase . ParseText ( resultData , ref startPosition , length - ( 2 + Tag . Length ) ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 3 )
			{
				throw new FormatException ( ) ;
			}

			Flags = byte . Parse ( stringRepresentation [ 0 ] ) ;
			Tag   = stringRepresentation [ 1 ] ;
			Value = stringRepresentation [ 2 ] ;
		}

		internal override string RecordDataToString ( )
			=> Flags
				+ " "
				+ Tag . ToMasterfileLabelRepresentation ( )
				+ " "
				+ Value . ToMasterfileLabelRepresentation ( ) ;

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			messageData [ currentPosition++ ] = Flags ;
			DnsMessageBase . EncodeTextBlock ( messageData , ref currentPosition , Tag ) ;
			DnsMessageBase . EncodeTextWithoutLength ( messageData , ref currentPosition , Value ) ;
		}

	}

}

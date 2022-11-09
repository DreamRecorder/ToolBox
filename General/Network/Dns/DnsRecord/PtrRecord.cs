using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Domain name pointer</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
	///     </para>
	/// </summary>
	public class PtrRecord : DnsRecordBase
	{

		protected internal override int MaximumRecordDataLength => PointerDomainName . MaximumRecordDataLength + 2 ;

		/// <summary>
		///     Domain name the address points to
		/// </summary>
		public DomainName PointerDomainName { get ; private set ; }

		internal PtrRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the PtrRecord class
		/// </summary>
		/// <param name="name"> Reverse name of the address </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="pointerDomainName"> Domain name the address points to </param>
		public PtrRecord ( DomainName name , int timeToLive , DomainName pointerDomainName ) : base (
		 name ,
		 RecordType . Ptr ,
		 RecordClass . INet ,
		 timeToLive )
			=> PointerDomainName = pointerDomainName ?? DomainName . Root ;

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeDomainName (
											   messageData ,
											   offset ,
											   ref currentPosition ,
											   PointerDomainName ,
											   domainNames ,
											   useCanonical ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			PointerDomainName = DnsMessageBase . ParseDomainName ( resultData , ref startPosition ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 1 )
			{
				throw new FormatException ( ) ;
			}

			PointerDomainName = ParseDomainName ( origin , stringRepresentation [ 0 ] ) ;
		}

		internal override string RecordDataToString ( ) => PointerDomainName . ToString ( ) ;

	}

}

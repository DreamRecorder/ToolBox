using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Canonical name for an alias</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
	///     </para>
	/// </summary>
	public class CNameRecord : DnsRecordBase
	{

		/// <summary>
		///     Canonical name
		/// </summary>
		public DomainName CanonicalName { get ; private set ; }

		protected internal override int MaximumRecordDataLength => CanonicalName . MaximumRecordDataLength + 2 ;

		internal CNameRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the CNameRecord class
		/// </summary>
		/// <param name="name"> Domain name the host </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="canonicalName"> Canocical name for the alias of the host </param>
		public CNameRecord ( DomainName name , int timeToLive , DomainName canonicalName ) : base (
		name ,
		RecordType . CName ,
		RecordClass . INet ,
		timeToLive )
			=> CanonicalName = canonicalName ?? DomainName . Root ;

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			CanonicalName = DnsMessageBase . ParseDomainName ( resultData , ref startPosition ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 1 )
			{
				throw new FormatException ( ) ;
			}

			CanonicalName = ParseDomainName ( origin , stringRepresentation [ 0 ] ) ;
		}

		internal override string RecordDataToString ( ) => CanonicalName . ToString ( ) ;

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
												CanonicalName ,
												domainNames ,
												useCanonical ) ;
		}

	}

}

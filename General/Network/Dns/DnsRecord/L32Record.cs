using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>L32</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc6742">RFC 6742</see>
	///     </para>
	/// </summary>
	public class L32Record : DnsRecordBase
	{

		/// <summary>
		///     The Locator
		/// </summary>
		public uint Locator32 { get ; private set ; }

		protected internal override int MaximumRecordDataLength => 6 ;

		/// <summary>
		///     The preference
		/// </summary>
		public ushort Preference { get ; private set ; }

		internal L32Record ( ) { }

		/// <summary>
		///     Creates a new instance of the L32Record class
		/// </summary>
		/// <param name="name"> Domain name of the host </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="preference"> The preference </param>
		/// <param name="locator32"> The Locator </param>
		public L32Record ( DomainName name , int timeToLive , ushort preference , uint locator32 ) : base (
		 name ,
		 RecordType . L32 ,
		 RecordClass . INet ,
		 timeToLive )
		{
			Preference = preference ;
			Locator32  = locator32 ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , Preference ) ;
			DnsMessageBase . EncodeUInt ( messageData , ref currentPosition , Locator32 ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Preference = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			Locator32  = DnsMessageBase . ParseUInt ( resultData , ref startPosition ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 2 )
			{
				throw new FormatException ( ) ;
			}

			Preference = ushort . Parse ( stringRepresentation [ 0 ] ) ;
			Locator32  = uint . Parse ( stringRepresentation [ 1 ] ) ;
		}

		internal override string RecordDataToString ( ) => Preference + " " + new IPAddress ( Locator32 ) ;

	}

}

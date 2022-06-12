using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>L64</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc6742">RFC 6742</see>
	///     </para>
	/// </summary>
	public class L64Record : DnsRecordBase
	{

		/// <summary>
		///     The preference
		/// </summary>
		public ushort Preference { get ; private set ; }

		/// <summary>
		///     The Locator
		/// </summary>
		public ulong Locator64 { get ; private set ; }

		protected internal override int MaximumRecordDataLength => 10 ;

		internal L64Record ( ) { }

		/// <summary>
		///     Creates a new instance of the L64Record class
		/// </summary>
		/// <param name="name"> Domain name of the host </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="preference"> The preference </param>
		/// <param name="locator64"> The Locator </param>
		public L64Record ( DomainName name , int timeToLive , ushort preference , ulong locator64 ) : base (
																											name ,
																											RecordType . L64 ,
																											RecordClass . INet ,
																											timeToLive )
		{
			Preference = preference ;
			Locator64  = locator64 ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Preference = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			Locator64  = DnsMessageBase . ParseULong ( resultData , ref startPosition ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 2 )
			{
				throw new FormatException ( ) ;
			}

			Preference = ushort . Parse ( stringRepresentation [ 0 ] ) ;
			Locator64  = ulong . Parse ( stringRepresentation [ 1 ] ) ;
		}

		internal override string RecordDataToString ( )
		{
			string locator = Locator64 . ToString ( "x16" ) ;
			return Preference
					+ " "
					+ locator . Substring ( 0 , 4 )
					+ ":"
					+ locator . Substring ( 4 , 4 )
					+ ":"
					+ locator . Substring ( 8 , 4 )
					+ ":"
					+ locator . Substring ( 12 ) ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , Preference ) ;
			DnsMessageBase . EncodeULong ( messageData , ref currentPosition , Locator64 ) ;
		}

	}

}

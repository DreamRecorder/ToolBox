using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . EDns
{

	/// <summary>
	///     <para>Expire EDNS Option</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc7314">RFC 7314</see>
	///     </para>
	/// </summary>
	public class ExpireOption : EDnsOptionBase
	{

		internal override ushort DataLength => ( ushort )( SoaExpire . HasValue ? 4 : 0 ) ;

		/// <summary>
		///     The expiration of the SOA record in seconds. Should be null on queries.
		/// </summary>
		public int ? SoaExpire { get ; private set ; }

		/// <summary>
		///     Creates a new instance of the ExpireOption class
		/// </summary>
		public ExpireOption ( ) : base ( EDnsOptionType . Expire ) { }

		/// <summary>
		///     Creates a new instance of the ExpireOption class
		/// </summary>
		/// <param name="soaExpire">The expiration of the SOA record in seconds</param>
		public ExpireOption ( int soaExpire ) : this ( ) => SoaExpire = soaExpire ;

		internal override void EncodeData ( byte [ ] messageData , ref int currentPosition )
		{
			if ( SoaExpire . HasValue )
			{
				DnsMessageBase . EncodeInt ( messageData , ref currentPosition , SoaExpire . Value ) ;
			}
		}

		internal override void ParseData ( byte [ ] resultData , int startPosition , int length )
		{
			if ( length == 4 )
			{
				SoaExpire = DnsMessageBase . ParseInt ( resultData , ref startPosition ) ;
			}
		}

	}

}

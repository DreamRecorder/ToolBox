using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . EDns
{

	/// <summary>
	///     <para>Cookie Option</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/draft-ietf-dnsop-cookies">draft-ietf-dnsop-cookies</see>
	///     </para>
	/// </summary>
	public class CookieOption : EDnsOptionBase
	{

		private byte [ ] _clientCookie ;

		/// <summary>
		///     Client cookie
		/// </summary>
		public byte [ ] ClientCookie
		{
			get => _clientCookie ;
			private set
			{
				if ( ( value            == null )
					|| ( value . Length != 8 ) )
				{
					throw new ArgumentException ( "Client cookie must contain 8 bytes" ) ;
				}

				_clientCookie = value ;
			}
		}

		/// <summary>
		///     Server cookie
		/// </summary>
		public byte [ ] ServerCookie { get ; private set ; }

		internal override ushort DataLength => ( ushort )( 8 + ServerCookie . Length ) ;

		/// <summary>
		///     Creates a new instance of the ClientCookie class
		/// </summary>
		public CookieOption ( ) : base ( EDnsOptionType . Cookie ) { }

		/// <summary>
		///     Creates a new instance of the ClientCookie class
		/// </summary>
		/// <param name="clientCookie">The client cookie</param>
		/// <param name="serverCookie">The server cookie</param>
		public CookieOption ( byte [ ] clientCookie , byte [ ] serverCookie = null ) : this ( )
		{
			ClientCookie = clientCookie ;
			ServerCookie = serverCookie ?? new byte [ ] { } ;
		}

		internal override void ParseData ( byte [ ] resultData , int startPosition , int length )
		{
			ClientCookie = DnsMessageBase . ParseByteData ( resultData , ref startPosition , 8 ) ;
			ServerCookie = DnsMessageBase . ParseByteData ( resultData , ref startPosition , length - 8 ) ;
		}

		internal override void EncodeData ( byte [ ] messageData , ref int currentPosition )
		{
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , ClientCookie ) ;
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , ServerCookie ) ;
		}

	}

}

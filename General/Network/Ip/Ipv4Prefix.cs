using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network . Ip
{

	public class Ipv4Prefix : IpPrefix , IPrefix <Ipv4Address>
	{

		public override AddressType Type => AddressType . Ipv4 ;

		public Ipv4Prefix ( )
		{
			AddressBytes = new byte[ 4 ] ;
			Length       = 0 ;
		}

		private Ipv4Prefix ( [NotNull] Memory <byte> address , byte length )
		{
			if ( address . Length != 4 )
			{
				throw new ArgumentException ( ) ; //todo
			}

			AddressBytes = address ;
			Length       = length ;
		}

		public Ipv4Prefix ( [NotNull] string addressString )
		{
			if ( addressString == null )
			{
				throw new ArgumentNullException ( nameof ( addressString ) ) ;
			}

			string [ ] data = addressString . Split ( '/' ) ;

			switch ( data . Length )
			{
				case 2 :

				{
					Ipv4Address address = new Ipv4Address ( data [ 0 ] ) ;

					AddressBytes = address . AddressBytes ;

					Length = Convert . ToByte ( data [ 1 ] ) ;

					break ;
				}

				case 1 :

				{
					Ipv4Address address = new Ipv4Address ( data [ 0 ] ) ;

					AddressBytes = address . AddressBytes ;

					Length = 32 ;

					break ;
				}

				default :

				{
					throw new ArgumentException ( ) ;
				}
			}
		}

		public bool Contains ( Ipv4Address address ) { throw new NotImplementedException ( ) ; }

		public static explicit operator Ipv4Prefix ( [NotNull] string address )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof ( address ) ) ;
			}

			return new Ipv4Prefix ( address ) ;
		}

		public override object Clone ( ) { return new Ipv4Prefix ( AddressBytes , Length ) ; }

	}

}

﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network . Ip
{

	public class Ipv4Prefix : IpPrefix
	{

		public override AddressType Type => AddressType . Ipv4 ;

		private Ipv4Prefix ( [NotNull] byte [ ] address , byte length )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof(address) ) ;
			}

			if ( address . Length != 4 )
			{
				throw new ArgumentException ( ) ; //todo
			}

			AddressBytes = ( byte [ ] ) address . Clone ( ) ;
			Length = length ;
		}

		public Ipv4Prefix ( [NotNull] string addressString )
		{
			if ( addressString == null )
			{
				throw new ArgumentNullException ( nameof(addressString) ) ;
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

		public override object Clone ( ) { return new Ipv4Prefix ( AddressBytes , Length ) ; }

	}

}

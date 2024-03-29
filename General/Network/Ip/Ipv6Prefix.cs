﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network . Ip
{

	public class Ipv6Prefix : IpPrefix
	{

		public override AddressType Type => AddressType . Ipv6 ;

		public Ipv6Prefix ( )
		{
			AddressBytes = new byte[ 16 ] ;
			Length       = 0 ;
		}

		private Ipv6Prefix ( Memory <byte> address , byte length )
		{
			if ( address . Length != 6 )
			{
				throw new ArgumentException ( ) ; //todo
			}

			AddressBytes = address ;
			Length       = length ;
		}

		public Ipv6Prefix ( [NotNull] string addressString )
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
					Ipv6Address address = new Ipv6Address ( data [ 0 ] ) ;

					AddressBytes = address . AddressBytes ;

					Length = Convert . ToByte ( data [ 1 ] ) ;

					break ;
				}

				case 1 :
				{
					Ipv6Address address = new Ipv6Address ( data [ 0 ] ) ;

					AddressBytes = address . AddressBytes ;

					Length = 128 ;

					break ;
				}

				default :
				{
					throw new ArgumentException ( ) ;
				}
			}
		}

		public override object Clone ( ) => new Ipv6Prefix ( AddressBytes , Length ) ;

		public static explicit operator Ipv6Prefix ( [NotNull] string address )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof ( address ) ) ;
			}

			return new Ipv6Prefix ( address ) ;
		}

		public override string ToString ( )
		{
			StringBuilder builder = new StringBuilder ( ) ;

			for ( int i = 0 ; i < AddressBytes . Length ; i += 2 )
			{
				int segment = ( ushort )( AddressBytes . Span [ i ] << 8 ) | AddressBytes . Span [ i + 1 ] ;
				builder . AppendFormat ( "{0:X}" , segment ) ;

				if ( i + 2 != AddressBytes . Length )
				{
					builder . Append ( ':' ) ;
				}
			}

			builder . Append ( '/' ) ;
			builder . Append ( Length ) ;

			return builder . ToString ( ) ;
		}

	}

}

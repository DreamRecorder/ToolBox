﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network . Ip
{

	public class Ipv4Address : IpAddress
	{

		public override AddressType Type => AddressType . Ipv4 ;

		public Ipv4Address ( ) => AddressBytes = new byte[ 4 ] ;

		public Ipv4Address ( long address ) : this ( )
		{
			AddressBytes       = new byte[ 4 ] ;
			AddressBytes [ 0 ] = ( byte ) address ;
			AddressBytes [ 1 ] = ( byte ) ( address >> 8 ) ;
			AddressBytes [ 2 ] = ( byte ) ( address >> 16 ) ;
			AddressBytes [ 3 ] = ( byte ) ( address >> 24 ) ;
		}

		public Ipv4Address ( string address ) : this ( )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof (address) ) ;
			}

			if ( ! address . Contains ( ':' ) )
			{
				int  end = address . Length ;
				long result ;

				unsafe
				{
					fixed ( char * name = address )
					{
						result = Ipv4AddressHelper . ParseNonCanonical ( name , 0 , ref end , true ) ;
					}
				}

				if ( ( result == Ipv4AddressHelper . Invalid )
					|| ( end  != address . Length ) )
				{
					throw new FormatException ( ) ;
				}

				// IPv4AddressHelper always returns IP address in a format that we need to reverse.
				result = ( ( result  & 0x000000FF ) << 24 )
						| ( ( result & 0x0000FF00 ) << 8 )
						| ( ( result & 0x00FF0000 ) >> 8 )
						| ( ( result & 0xFF000000 ) >> 24 ) ;

				AddressBytes [ 0 ] = ( byte ) result ;
				AddressBytes [ 1 ] = ( byte ) ( result >> 8 ) ;
				AddressBytes [ 2 ] = ( byte ) ( result >> 16 ) ;
				AddressBytes [ 3 ] = ( byte ) ( result >> 24 ) ;
			}
			else
			{
				throw new ArgumentException ( ) ; //todo:
			}
		}

		public static explicit operator Ipv4Address ( [NotNull] string address )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof (address) ) ;
			}

			return new Ipv4Address ( address ) ;
		}

		public override object Clone ( ) => throw new NotImplementedException ( ) ;

		public override string ToString ( )
			=> $"{AddressBytes [ 0 ]}.{AddressBytes [ 1 ]}.{AddressBytes [ 2 ]}.{AddressBytes [ 3 ]}" ;

	}

}

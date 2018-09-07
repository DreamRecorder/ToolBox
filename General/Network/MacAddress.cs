﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network
{

	public class MacAddress : Address
	{

		public override AddressType Type => AddressType . Mac ;

		public MacAddress ( ) { AddressBytes = new byte[ 8 ] ; }

		internal MacAddress ( byte [ ] address )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof(address) ) ;
			}

			if ( address . Length != 8 )
			{
				throw new ArgumentException ( ) ;
			}

			AddressBytes = address ;
		}


		public MacAddress ( [NotNull] string address ) : this ( )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof(address) ) ;
			}

			int validCount = 0 ;
			bool hasDashes = false ;
			byte [ ] buffer ;


			//has dashes?
			if ( address . IndexOf ( '-' ) >= 0 )
			{
				hasDashes = true ;
				buffer = new byte[ ( address . Length + 1 ) / 3 ] ;
			}
			else
			{
				if ( address . Length % 2 > 0 )
				{
					//should be even
					throw new FormatException ( ) ;
				}

				buffer = new byte[ address . Length / 2 ] ;
			}

			int j = 0 ;
			for ( int i = 0 ; i < address . Length ; i++ )
			{
				int value = address [ i ] ;

				if ( value >= 0x30
					&& value <= 0x39 )
				{
					value -= 0x30 ;
				}
				else if ( value >= 0x41
						&& value <= 0x46 )
				{
					value -= 0x37 ;
				}
				else if ( value == '-' )
				{
					if ( validCount == 2 )
					{
						validCount = 0 ;
						continue ;
					}
					else
					{
						throw new FormatException ( ) ;
					}
				}
				else
				{
					throw new FormatException ( ) ;
				}

				//we had too many characters after the last dash
				if ( hasDashes && validCount >= 2 )
				{
					throw new FormatException ( ) ;
				}

				if ( validCount % 2 == 0 )
				{
					buffer [ j ] = ( byte ) ( value << 4 ) ;
				}
				else
				{
					buffer [ j++ ] |= ( byte ) value ;
				}

				validCount++ ;
			}

			//we too few characters after the last dash
			if ( validCount < 2 )
			{
				throw new FormatException ( ) ;
			}

			AddressBytes = buffer . Take ( 8 ) . ToArray ( ) ;
		}

		public override object Clone ( ) { return new MacAddress ( AddressBytes ) ; }

	}

}

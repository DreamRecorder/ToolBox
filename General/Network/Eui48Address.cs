using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network
{

	public class Eui48Address : Address
	{

		public override AddressType Type => AddressType . Mac ;

		public Eui48Address ( ) { AddressBytes = new byte[ 6 ] ; }

		internal Eui48Address ( byte [ ] address )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof(address) ) ;
			}

			if ( address . Length != 6 )
			{
				throw new ArgumentException ( ) ;
			}

			AddressBytes = address ;
		}

		public Eui48Address ( [NotNull] string address ) : this ( )
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
			foreach ( char t in address )
			{
				int value = t ;

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
					if ( validCount != 2 )
					{
						throw new FormatException ( ) ;
					}

					validCount = 0 ;
					continue ;
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

		public override string ToString ( )
		{
			StringBuilder addressString = new StringBuilder ( ) ;

			foreach ( byte value in AddressBytes )
			{
				int tmp = ( value >> 4 ) & 0x0F ;

				for ( int i = 0 ; i < 2 ; i++ )
				{
					if ( tmp < 0x0A )
					{
						addressString . Append ( ( char ) ( tmp + 0x30 ) ) ;
					}
					else
					{
						addressString . Append ( ( char ) ( tmp + 0x37 ) ) ;
					}

					tmp = value & 0x0F ;
				}
			}

			return addressString . ToString ( ) ;
		}

		public static explicit operator Eui48Address ( [NotNull] string address )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof(address) ) ;
			}

			return new Eui48Address ( address ) ;
		}

		public override object Clone ( ) { return new Eui48Address ( AddressBytes ) ; }

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class Crc8Helper
	{

		static Crc8Helper ( )
		{
			for ( int i = 0 ; i < 256 ; ++i )
			{
				int temp = i ;

				for ( int j = 0 ; j < 8 ; ++j )
				{
					if ( ( temp & 0x80 ) != 0 )
					{
						temp = ( temp << 1 ) ^ Poly ;
					}
					else
					{
						temp <<= 1 ;
					}
				}

				Table [ i ] = ( byte ) temp ;
			}
		}

		// x8 + x7 + x6 + x4 + x2 + 1
		private const byte Poly = 0xd5 ;

		private static readonly byte [ ] Table = new byte[ 256 ] ;

		public static byte CalculateCrc8 ( this byte [ ] data ) => ComputeChecksum ( data ) ;

		public static byte ComputeChecksum (
			[NotNull]
			params byte [ ] data )
		{
			if ( data == null )
			{
				throw new ArgumentNullException ( nameof ( data ) ) ;
			}

			byte crc = 0 ;

			if ( data . Length > 0 )
			{
				crc = data . Aggregate ( crc , ( current , b ) => Table [ current ^ b ] ) ;
			}

			return crc ;
		}

	}

}

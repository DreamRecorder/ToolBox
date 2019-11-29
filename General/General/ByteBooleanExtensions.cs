using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Runtime . InteropServices ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class ByteBooleanExtensions
	{

		public static bool [ ] ToBooleanArray ( this byte b )
		{
			bool [ ] result = new bool[ 8 ] ;

			for ( int bitPosition = 0 ; bitPosition < 8 ; bitPosition++ )
			{
				result [ bitPosition ] = ( b & ( 1 << ( 7 - bitPosition ) ) ) != 0 ;
			}

			return result ;
		}

		public static bool [ ] ToBooleanArray ( [NotNull] this byte [ ] bytes )
		{
			if ( bytes == null )
			{
				throw new ArgumentNullException ( nameof ( bytes ) ) ;
			}

			bool [ ] result = new bool[ 8 * bytes . Length ] ;

			for ( int bytePosition = 0 ; bytePosition < bytes . Length ; bytePosition++ )
			{
				byte b = bytes [ bytePosition ] ;

				for ( int bitPosition = 0 ; bitPosition < 8 ; bitPosition++ )
				{
					result [ ( bytePosition * 8 ) + bitPosition ] = ( b & ( 1 << ( 7 - bitPosition ) ) ) != 0 ;
				}
			}

			return result ;
		}

		//public static bool [ ] ToBooleanArray ( [NotNull] this Span <byte> bytes )
		//{
		//	if ( bytes == null )
		//	{
		//		throw new ArgumentNullException ( nameof(bytes) ) ;
		//	}

		//	bool [ ] result = new bool[ 8 * bytes . Length ] ;

		//	for ( int bytePosition = 0 ; bytePosition < bytes . Length ; bytePosition++ )
		//	{
		//		byte b = bytes [ bytePosition ] ;

		//		for ( int bitPosition = 0 ; bitPosition < 8 ; bitPosition++ )
		//		{
		//			result [ ( bytePosition * 8 ) + bitPosition ] = ( b & ( 1 << ( 7 - bitPosition ) ) ) != 0 ;
		//		}
		//	}

		//	return result ;
		//}

		public static byte ToByte ([NotNull]this bool [ ] source )
		{
			if ( source == null )
			{
				throw new ArgumentNullException ( nameof ( source ) ) ;
			}

			if ( source . Length != 8 )
			{
				throw new ArgumentException ( ) ;
			}

			byte result = 0 ;

			for ( int i = 7 ; i >= 0 ; i-- )
			{
				byte value = source [ i ] ? ( byte ) 1 : ( byte ) 0 ;

				result = ( byte ) ( result | ( value << i ) ) ;
			}

			return result ;
		}

		public static byte [ ] ToByteArray (this bool [ ] source )
		{
			if ( source == null )
			{
				throw new ArgumentNullException ( nameof ( source ) ) ;
			}

			if ( ( source . Length % 8 ) != 0 )
			{
				throw new ArgumentException ( ) ;
			}

			int length = source . Length / 8 ;

			byte [ ] result = new byte[ length ] ;

			for ( int j = 0 ; j < length ; j++ )
			{
				for ( int i = 0 ; i < 8 ; i++ )
				{
					byte value = source [ i + 8 * j ] ? ( byte ) 1 : ( byte ) 0 ;

					result [ j ] = ( byte ) ( result [ j ] | ( value << i ) ) ;
				}
			}

			return result ;
		}

		public static T BytesToStruct <T> ( this byte [ ] bytes )
		{
			int    size   = Marshal . SizeOf ( typeof ( T ) ) ;
			IntPtr buffer = Marshal . AllocHGlobal ( size ) ;

			try
			{
				Marshal . Copy ( bytes , 0 , buffer , size ) ;

				return ( T ) Marshal . PtrToStructure ( buffer , typeof ( T ) ) ;
			}
			finally
			{
				Marshal . FreeHGlobal ( buffer ) ;
			}
		}

		public static byte [ ] StructToBytes <T> ( this T value ) where T : struct
		{
			int size = Marshal . SizeOf ( typeof ( T ) ) ;

			byte [ ] bytes = new byte[ size ] ;

			IntPtr buffer = Marshal . AllocHGlobal ( size ) ;

			try
			{
				Marshal . StructureToPtr ( value , buffer , false ) ;
				Marshal . Copy ( bytes ,  0 ,     buffer , size ) ;
				Marshal . Copy ( buffer , bytes , 0 ,      size ) ;
				Marshal . FreeHGlobal ( buffer ) ;

				return bytes ;
			}
			finally
			{
				Marshal . FreeHGlobal ( buffer ) ;
			}
		}

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{
	[PublicAPI ]
	public static class ByteBooleanExtensions
	{

		public static bool[] ToBooleanArray(this byte b)
		{
			bool[] result = new bool[8];

			for (int bitPosition = 0; bitPosition < 8; bitPosition++)
			{
				result[bitPosition] = (b & (1 << (7 - bitPosition))) != 0;
			}

			return result;
		}

		public static bool[] ToBooleanArray( [NotNull] this byte[] bytes)
		{
			if ( bytes == null )
			{
				throw new ArgumentNullException ( nameof(bytes) ) ;
			}

			bool[] result = new bool[8 * bytes.Length];

			for (int bytePosition = 0; bytePosition < bytes.Length; bytePosition++)
			{
				byte b = bytes[bytePosition];
				for (int bitPosition = 0; bitPosition < 8; bitPosition++)
				{
					result[(bytePosition * 8) + bitPosition] = (b & (1 << (7 - bitPosition))) != 0;
				}
			}

			return result;
		}

	}

}
using System ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	/// <summary>
	///     提供将x,y映射到单个值的方法
	/// </summary>
	public static class CantorPairing
	{

		public static long Calculate ( int x , int y ) { return ( x + y ) * ( x + y + 1 ) / 2 + y ; }

		public static (int X , int Y) Calculate ( long value )
		{
			long w = Convert . ToInt64 ( Math . Floor ( ( Math . Sqrt ( Convert . ToDouble ( 8m * value + 1 ) ) - 1 )
														/ 2 ) ) ;
			long t = ( w * w + w ) / 2 ;

			return ( Convert . ToInt32 ( w - value + t ) , Convert . ToInt32 ( value - t ) ) ;
		}

	}

}

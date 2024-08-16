using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.General;

/// <summary>
///     提供将x,y映射到单个值的方法
/// </summary>
public static class CantorPairing
{

	public static (int X , int Y) Calculate ( long value )
	{
		long w = Convert.ToInt64 ( Math.Floor ( ( Math.Sqrt ( Convert.ToDouble ( 8L * value + 1L ) ) - 1L ) / 2L ) );

		long t = ( w * w + w ) / 2L;

		return ( Convert.ToInt32 ( w - value + t ) , Convert.ToInt32 ( value - t ) );
	}

	public static long Calculate ( int x , int y ) => ( x + y ) * ( x + y + 1L ) / 2L + y;

}

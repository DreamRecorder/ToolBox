using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Runtime . CompilerServices ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class FloatExtensions
	{

		/// <summary>
		///     smallest such that 1.0+Epsilon != 1.0
		/// </summary>
		public const float Epsilon = 1.192092896e-07F ;

		[MethodImpl ( MethodImplOptions . AggressiveInlining )]
		public static bool DefinitelyGreaterThan ( float a , float b )
			=> a - b > Math . Max ( Math . Abs ( a ) , Math . Abs ( b ) ) * Epsilon ;

		[MethodImpl ( MethodImplOptions . AggressiveInlining )]
		public static bool DefinitelyLessThan ( float a , float b )
			=> b - a > Math . Max ( Math . Abs ( a ) , Math . Abs ( b ) ) * Epsilon ;

		[MethodImpl ( MethodImplOptions . AggressiveInlining )]
		public static bool IsAboutZero ( this float value ) => value < Epsilon && - value > Epsilon ;

	}

}

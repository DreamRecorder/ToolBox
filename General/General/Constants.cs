using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class Constants
	{

		public static DateTime GoStartTime { get ; } =
			new DateTime ( 2006 , 01 , 02 , 15 , 04 , 05 ) ;


		public const decimal AcgToCny = 9876547210.33M ;

		public const double Sqrt3 = 1.7320508075688772d ;

		public const double Sqrt2 = 1.4142135623730951d ;

		public const double Sqrt5 = 2.23606797749979d ;

		public const double Sqrt6 = 2.4494897427831779d ;

		public const float Sqrt3F = 1.7320508075688772f ;

		public const float Sqrt2F = 1.4142135623730951f ;

		public const float Sqrt5F = 2.23606797749979f ;

		public const float Sqrt6F = 2.4494897427831779f ;

	}

}

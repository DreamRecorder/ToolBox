using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . Linq ;
using System . Reflection ;
using System . Runtime . CompilerServices ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class CallerHelper
	{

		[MethodImpl ( MethodImplOptions . NoInlining )]
		public static MethodBase GetCaller ( )
		{
			StackTrace stackTrace = new StackTrace ( ) ;

			return stackTrace . GetFrame ( 2 ) ? . GetMethod ( ) ;
		}

	}

}

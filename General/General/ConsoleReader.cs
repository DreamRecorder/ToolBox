using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	public static class ConsoleReader
	{

		private static Thread InputThread { get ; }

		private static AutoResetEvent GetInput { get ; }

		private static AutoResetEvent GotInput { get ; }

		public static string Input { get ; private set ; }

		static ConsoleReader ( )
		{
			GetInput    = new AutoResetEvent ( false ) ;
			GotInput    = new AutoResetEvent ( false ) ;
			InputThread = new Thread ( Reader ) { IsBackground = true } ;
			InputThread . Start ( ) ;
		}

		private static void Reader ( )
		{
			while ( true )
			{
				GetInput . WaitOne ( ) ;
				Input = Console . ReadLine ( ) ;
				GotInput . Set ( ) ;
			}
		}

		// omit the parameter to read a line without a timeout
		[CanBeNull]
		public static string ReadLine ( int timeout = Timeout . Infinite )
		{
			GetInput . Set ( ) ;
			bool success = GotInput . WaitOne ( timeout ) ;
			if ( success )
			{
				return Input ;
			}
			else
			{
				return null ;
			}
		}

	}

}

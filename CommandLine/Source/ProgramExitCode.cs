using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . CommandLine
{

	[PublicAPI]
	public class ProgramExitCode <T> where T : ProgramExitCode <T> , new ( )
	{

		public int Code { get ; private set ; }

		public static T Success => ( ProgramExitCode <T> ) 0 ;

		public static T LicenseNotAccepted => ( ProgramExitCode <T> ) 1 ;

		public static T ExceptionUnhandled => ( ProgramExitCode <T> ) 2 ;

		public static T SignalInterrupt => ( ProgramExitCode <T> ) 140 ;


		public static T InvalidSetting = ( ProgramExitCode <T> ) 3 ;

		public static readonly T LicenseNotAccepted = ( ProgramExitCode <T> ) 1 ;

		public static implicit operator int ( ProgramExitCode <T> item ) { return item . Code ; }


		public static implicit operator ProgramExitCode <T> ( int item )
		{
			return new ProgramExitCode <T> { Code = item } ;
		}


		public static implicit operator T ( ProgramExitCode <T> item )
		{
			T result = new T { Code = item } ;

			return result ;
		}

	}

}

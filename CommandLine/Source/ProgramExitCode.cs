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

		public static readonly T Success = ( ProgramExitCode <T> ) 0 ;

		public static readonly T LicenseNotAccepted = ( ProgramExitCode <T> ) 1 ;

		public static readonly T ExceptionUnhandled = ( ProgramExitCode <T> ) 2 ;

		public static implicit operator int ( ProgramExitCode <T> item ) => item . Code ;

		public static implicit operator ProgramExitCode <T> ( int item )
			=> new ProgramExitCode <T> { Code = item } ;


		public static implicit operator T ( ProgramExitCode <T> item )
		{
			T result = new T { Code = item } ;

			return result ;
		}

	}

}

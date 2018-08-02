using System ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . CommandLine
{

	[PublicAPI]
	public class ProgramExitCode <T> where T : ProgramExitCode <T>
	{

		public int Code { get ; }

		protected ProgramExitCode ( int code ) { Code = code ; }

		public static readonly T Success = ( T ) 0 ;

		public static readonly T LicenseNotAccepted = ( T ) 1 ;

		public static readonly T ExceptionUnhandled = ( T ) 2 ;

		public static implicit operator int ( ProgramExitCode <T> item ) { return item . Code ; }

		public static implicit operator ProgramExitCode <T> ( int item ) { return new ProgramExitCode <T> ( item ) ; }

	}

}

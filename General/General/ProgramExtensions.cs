using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class ProgramExtensions
	{

		public static string GetProgramName ( )
		{
			return Assembly . GetEntryAssembly ( ) ? . GetProgramName ( )
				   ?? AppDomain . CurrentDomain . GetAssemblies ( ) .
								  Select ( ass => ass . GetProgramName ( ) ) .
								  FirstOrDefault ( name => name != null )
				   ?? Assembly . GetEntryAssembly ( ) ? . GetDisplayName ( ) ;
		}

	}

}

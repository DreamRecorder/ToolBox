using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;

namespace DreamRecorder . ToolBox . General
{

	public static class AppDomainExtensions
	{

		public static void PrepareCurrentDomain ( )
		{
			Assembly [ ] assemblies = AppDomain . CurrentDomain . GetAssemblies ( ) ;

			AppDomain . CurrentDomain . AssemblyLoad += CurrentDomain_AssemblyLoad ;

			foreach ( Assembly assembly in assemblies )
			{
				assembly . Prepare ( ) ;
			}
		}

		private static void CurrentDomain_AssemblyLoad ( object sender , AssemblyLoadEventArgs args )
		{
			args . LoadedAssembly . Prepare ( ) ;
		}

	}

}
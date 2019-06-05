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
			lock ( StaticServiceProvider . ServiceCollection )
			{
				AppDomain . CurrentDomain . AssemblyLoad += CurrentDomain_AssemblyLoad ;

				Assembly [ ] assemblies = AppDomain . CurrentDomain . GetAssemblies ( ) ;

				foreach ( Assembly assembly in assemblies )
				{
					assembly . Prepare ( ) ;
				}

				StaticServiceProvider . Update ( ) ;
			}
		}

		private static void CurrentDomain_AssemblyLoad ( object sender , AssemblyLoadEventArgs args )
		{
			lock ( StaticServiceProvider . ServiceCollection )
			{
				args . LoadedAssembly . Prepare ( ) ;

				StaticServiceProvider . Update ( ) ;
			}
		}

	}

}

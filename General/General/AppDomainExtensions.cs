using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Threading . Tasks ;

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

				int assembliesCount = assemblies . Length ;

				Task [ ] tasks = new Task[ assembliesCount ] ;

				for ( int i = 0 ; i < assembliesCount ; i++ )
				{
					Assembly assembly = assemblies [ i ] ;

					tasks [ i ] = assembly . Prepare ( ) ;
				}

				Task . WaitAll ( tasks ) ;

				StaticServiceProvider . Update ( ) ;
			}
		}

		private static void CurrentDomain_AssemblyLoad ( object sender , AssemblyLoadEventArgs args )
		{
			lock ( StaticServiceProvider . ServiceCollection )
			{
				args . LoadedAssembly . Prepare ( ) . Wait ( ) ;

				StaticServiceProvider . Update ( ) ;
			}
		}

	}

}

﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;

namespace DreamRecorder . ToolBox . General
{

	public static class AppDomainExtensions
	{

		private static volatile bool Loaded ;

		public static void PrepareCurrentDomain ( )
		{
			if ( ! Loaded )
			{
				lock ( StaticServiceProvider . ServiceCollection )
				{
					if ( ! Loaded )
					{
						Loaded = true ;
					}
					else
					{
						return ;
					}
				}

				AppDomain . CurrentDomain . AssemblyLoad += CurrentDomain_AssemblyLoad ;

				Assembly [ ] assemblies = AppDomain . CurrentDomain . GetAssemblies ( ) ;

				int assembliesCount = assemblies . Length ;

				for ( int i = 0 ; i < assembliesCount ; i++ )
				{
					Assembly assembly = assemblies [ i ] ;

					lock ( StaticServiceProvider . ServiceCollection )
					{
						assembly . Prepare ( ) ;
					}
				}

				StaticServiceProvider . Update ( ) ;
			}
		}

		private static void CurrentDomain_AssemblyLoad ( object sender , AssemblyLoadEventArgs args )
		{
			lock ( StaticServiceProvider . ServiceCollection )
			{
				args . LoadedAssembly . Prepare ( ) ;
			}

			StaticServiceProvider . Update ( ) ;
		}

	}

}

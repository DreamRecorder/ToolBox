﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;

namespace DreamRecorder . ToolBox . General
{

	public static class AppDomainExtensions
	{

		private static volatile bool _loaded ;

		public static void PrepareCurrentDomain ( )
		{
			if ( ! _loaded )
			{
				lock ( StaticServiceProvider . ServiceCollection )
				{
					if ( ! _loaded )
					{
						_loaded = true ;
					}
					else
					{
						return ;
					}
				}

				AppDomain . CurrentDomain . AssemblyLoad += CurrentDomain_AssemblyLoad ;

				Assembly [ ] assemblies = AppDomain . CurrentDomain . GetAssemblies ( ) ;

				foreach ( Assembly assembly in assemblies )
				{
					lock ( StaticServiceProvider . ServiceCollection )
					{
						assembly . Prepare ( ) ;
					}
				}

				StaticServiceProvider . Update ( ) ;
			}
		}

		public static List <Type> FindType ( Predicate <Type> predicate )
		{
			return AppDomain . CurrentDomain . GetAssemblies ( ) .
								SelectMany ( assembly => assembly . GetTypes ( ) ) .
								Distinct ( ) .
								Where ( predicate . Invoke ) .
								ToList ( ) ;
		}

		public static List <PropertyInfo> FindProperty ( Predicate <PropertyInfo> predicate )
		{
			return AppDomain . CurrentDomain . GetAssemblies ( ) .
								SelectMany ( assembly => assembly . GetTypes ( ) ) .
								SelectMany ( type => type . GetProperties ( ) ) .
								Distinct ( ) .
								Where ( predicate . Invoke ) .
								ToList ( ) ;
		}

		private static void CurrentDomain_AssemblyLoad (
			object                sender ,
			AssemblyLoadEventArgs args )
		{
			lock ( StaticServiceProvider . ServiceCollection )
			{
				args . LoadedAssembly . Prepare ( ) ;
			}

			StaticServiceProvider . Update ( ) ;
		}

	}

}

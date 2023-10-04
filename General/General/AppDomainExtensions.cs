using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;

namespace DreamRecorder . ToolBox . General
{

	public static class AppDomainExtensions
	{

		private static volatile bool _loaded ;

		private static void CurrentDomain_AssemblyLoad ( object sender , AssemblyLoadEventArgs args )
		{
			lock ( StaticServiceProvider . ServiceCollection )
			{
				args . LoadedAssembly . Prepare ( ) ;
			}

			StaticServiceProvider . Update ( ) ;
		}

		public static List <(PropertyInfo info , TAttribute attribute)> FindProperty
			<TAttribute> ( Predicate <(PropertyInfo info , TAttribute attribute)> predicate )
			where TAttribute : Attribute
		{
			return AppDomain . CurrentDomain . GetAssemblies ( ) .
							   SelectMany ( assembly => assembly . GetTypes ( ) ) .
							   SelectMany (
										   type => type . GetProperties ( ) .
														  Select (
																  prop => ( prop ,
																			  prop .
																				  GetCustomAttribute <
																					  TAttribute> ( ) ) ) .
														  Where ( prop => prop . Item2 != null ) ) .
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

		public static List <Type> FindType ( Predicate <Type> predicate )
		{
			return AppDomain . CurrentDomain . GetAssemblies ( ) .
							   SelectMany ( assembly => assembly . GetTypes ( ) ) .
							   Distinct ( ) .
							   Where ( predicate . Invoke ) .
							   ToList ( ) ;
		}

		private static void LoadReferencedAssembly ( Assembly assembly )
		{
			foreach ( AssemblyName name in assembly . GetReferencedAssemblies ( ) )
			{
				if ( AppDomain . CurrentDomain . GetAssemblies ( ) . All ( a => a . FullName != name . FullName ) )
				{
					LoadReferencedAssembly ( Assembly . Load ( name ) ) ;
				}
			}
		}

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

				Assembly [ ] assemblies ;

				do
				{
					assemblies = AppDomain . CurrentDomain . GetAssemblies ( ) ;

					foreach ( Assembly assembly in AppDomain . CurrentDomain . GetAssemblies ( ) )
					{
						LoadReferencedAssembly ( assembly ) ;
					}
				}
				while ( assemblies . Length != AppDomain . CurrentDomain . GetAssemblies ( ) . Length ) ;

				AppDomain . CurrentDomain . AssemblyLoad += CurrentDomain_AssemblyLoad ;

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

	}

}

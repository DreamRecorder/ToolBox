using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Threading . Tasks ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class AssemblyExtensions
	{

		public static readonly string CommaWithNewline = $",{Environment . NewLine}" ;

		public static string GetAssemblyFullName ( this Type type )
			=> type . GetTypeInfo ( ) . Assembly . GetName ( ) . FullName . Replace ( ", " , CommaWithNewline ) ;

		public static Task Prepare ( this Assembly assembly )
		{
			PrepareAttribute attribute = assembly . GetCustomAttribute <PrepareAttribute> ( ) ;

			if ( attribute != null )
			{
				List <Task> tasks = new List <Task> ( ) ;

				foreach ( TypeInfo type in assembly . DefinedTypes )
				{
					foreach ( MethodInfo method in type . DeclaredMethods )
					{
						if ( method . GetCustomAttributes ( typeof ( PrepareAttribute ) ) . Any ( ) )
						{
							tasks . Add ( Task . Run ( ( ) => method . Invoke ( null , new object [ ] { } ) ) ) ;
						}
					}
				}

				return Task . WhenAll ( tasks ) ;
			}

			return TaskExtensions . CompletedTask ;
		}

		public static string GetDisplayName ( [NotNull] this Assembly assembly )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			AssemblyDisplayNameAttribute attribute = assembly . GetCustomAttribute <AssemblyDisplayNameAttribute> ( ) ;

			return attribute ? . Name ?? assembly . GetName ( ) . Name ;
		}

	}

}

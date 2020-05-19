using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Runtime . InteropServices ;
using System . Text ;
using System . Text . RegularExpressions ;
using System . Threading . Tasks ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class AssemblyExtensions
	{

		public static readonly string CommaWithNewline = $",{Environment . NewLine}" ;

		public static Regex InformationalVersionRegex = new Regex (
																	"Code version \"([^\"]+)\" build by \"([^\"]+)\" at \"([^\"]+)\"" ,
																	RegexOptions . Compiled ) ;

		public static string GetAssemblyFullName ( this Type type )
		{
			return type . GetTypeInfo ( ) . Assembly . GetName ( ) . FullName . Replace ( ", " , CommaWithNewline ) ;
		}

		public static void GetAssemblyInfo <T> ( [NotNull] StringBuilder builder )
		{
			if ( builder == null )
			{
				throw new ArgumentNullException ( nameof ( builder ) ) ;
			}

			builder . AppendLine ( typeof ( T ) . Assembly . GetName ( ) . Name ) ;

			builder . AppendLine (
								typeof ( T ) . Assembly . GetName ( ) . Version . ToString ( ) ) ;


			builder . AppendLine (
								typeof ( T ) . Assembly .
												GetCustomAttribute <
													AssemblyInformationalVersionAttribute> ( ) ? .
												InformationalVersion ) ;

			builder . AppendLine (
								typeof ( T ) . Assembly .
												GetCustomAttribute <AssemblyCopyrightAttribute
												> ( ) ? .
												Copyright ) ;

			builder . AppendLine ( ) ;
		}

		public static string GetResourceFile <T> ( this Assembly assembly , string fileName )
		{
			Stream stream = assembly . GetManifestResourceStream ( typeof ( T ) , fileName ) ;
			if ( stream != null )
			{
				string license ;

				using ( StreamReader reader = new StreamReader ( stream ) )
				{
					license = reader . ReadToEnd ( ) ;
				}

				return license ;
			}

			return null ;
		}

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
							tasks . Add (
										Task . Run (
													( ) =>
													{
														try
														{
															method . Invoke ( null , new object [ ] { } ) ;
														}
														catch ( Exception e )
														{
															Debug . WriteLine ( e ) ;
														}
													} ) ) ;
						}
					}
				}

				return Task . WhenAll ( tasks ) ;
			}

			return Task . CompletedTask ;
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

		public static Guid ? GetGuid ( [NotNull] this Assembly assembly )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			GuidAttribute attribute = assembly . GetCustomAttributes <GuidAttribute> ( ) . FirstOrDefault ( ) ;
			string        guid      = attribute ? . Value ;

			if ( guid is null )
			{
				return null ;
			}

			return Guid . Parse ( guid ) ;
		}

		public static (string SourceCodeVersion , string Builder , DateTimeOffset ? BuildTime) ?
			GetInformationalVersion ( [NotNull] this Assembly assembly )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			AssemblyInformationalVersionAttribute attribute =
				assembly . GetCustomAttribute <AssemblyInformationalVersionAttribute> ( ) ;
			string value = attribute ? . InformationalVersion ;

			if ( value != null )
			{
				Match match = InformationalVersionRegex . Match ( value ) ;

				if ( match . Success )
				{
					return ( match . Captures [ 0 ] . Value , match . Captures [ 1 ] . Value ,
								new DateTimeOffset (
													DateTime . Parse ( match . Captures [ 2 ] . Value ) ,
													TimeSpan . Zero ) ) ;
				}
			}

			return default ;
		}

		public static string GetSourceCodeVersion ( [NotNull] this Assembly assembly )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			return assembly . GetInformationalVersion ( ) ? . SourceCodeVersion ;
		}

		public static string GetBuilder ( [NotNull] this Assembly assembly )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			return assembly . GetInformationalVersion ( ) ? . Builder ;
		}

		public static DateTimeOffset ? GetBuildTime ( [NotNull] this Assembly assembly )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			return assembly . GetInformationalVersion ( ) ? . BuildTime ;
		}

	}

}

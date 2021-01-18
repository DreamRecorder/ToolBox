using System ;
using System.Collections ;
using System.Collections.Concurrent ;
using System.Collections.Generic ;
using System.Linq ;
using System.Net ;
using System . Reflection ;
using System.Threading.Tasks ;

using JetBrains.Annotations ;

using Newtonsoft.Json ;

namespace DreamRecorder . ToolBox . AspNet . General
{
	[AttributeUsage( AttributeTargets.Assembly)]
	public sealed class WebTitleAttribute : Attribute
	{

		public string Name { get; }

		public WebTitleAttribute(string name) => Name = name;

	}

	[PublicAPI]
	public static class AssemblyExtensions
	{

		public static string GetWebTitle(
			[NotNull]
			this Assembly assembly)
		{
			if (assembly == null)
			{
				throw new ArgumentNullException(nameof(assembly));
			}

			WebTitleAttribute attribute = assembly.GetCustomAttribute<WebTitleAttribute>();

			return attribute?.Name ?? assembly.GetName().Name;
		}
	}

	public class CdnjsWebAssetProvider : IWebAssetProvider
	{

		private WebClient CurrentClient { get ; } = new WebClient ( ) ;

		public static ConcurrentDictionary <string , string> PackageVersions { get ; set ; } =
			new ConcurrentDictionary <string , string> ( ) ;


		public async Task <string> GetPackageVersion (
			[NotNull]
			string packageName )
		{
			if ( packageName == null )
			{
				throw new ArgumentNullException ( nameof ( packageName ) ) ;
			}

			if ( PackageVersions . TryGetValue ( packageName , out string version ) )
			{
				return version ;
			}
			else
			{
				dynamic apiQuery = JsonConvert . DeserializeObject (
																	await CurrentClient . DownloadStringTaskAsync (
																	$"https://api.cdnjs.com/libraries/{packageName}?fields=version" ) ) ;

				version = apiQuery . version ;

				if ( string . IsNullOrWhiteSpace ( version ) )
				{
					throw new Exception ( "Parse API error" ) ;
				}

				PackageVersions . TryAdd ( packageName , version ) ;

				return version ;
			}
		}

		public async Task <string> GetFileUrl (
			[NotNull]
			string packageName ,
			[NotNull]
			string fileName )
		{
			if ( packageName == null )
			{
				throw new ArgumentNullException ( nameof ( packageName ) ) ;
			}

			if ( fileName == null )
			{
				throw new ArgumentNullException ( nameof ( fileName ) ) ;
			}

			while ( ( await GetPackageVersion ( packageName ) ) is string version )
			{
				return $"https://cdnjs.cloudflare.com/ajax/libs/{packageName}/{version}/{fileName}" ;
			}

			throw new Exception ( ) ;
		}

		public async Task ClearCache ( ) => PackageVersions . Clear ( ) ;

	}

}

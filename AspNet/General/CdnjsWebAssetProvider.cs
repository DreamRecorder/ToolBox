using System ;
using System . Collections ;
using System . Collections . Concurrent ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;
using System . Net . Http ;
using System . Threading . Tasks ;

using JetBrains . Annotations ;

using Newtonsoft . Json ;

namespace DreamRecorder . ToolBox . AspNet . General
{

	public class CdnjsWebAssetProvider : IWebAssetProvider
	{

		private HttpClient CurrentClient { get ; } = new HttpClient ( ) ;

		public static ConcurrentDictionary <string , string> PackageVersions { get ; set ; } =
			new ConcurrentDictionary <string , string> ( ) ;


		public async Task <string> GetPackageVersion ( [NotNull] string packageName )
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
																	await CurrentClient . GetStringAsync (
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
			[NotNull] string packageName ,
			[NotNull] string fileName ,
			string           version )
		{
			if ( packageName == null )
			{
				throw new ArgumentNullException ( nameof ( packageName ) ) ;
			}

			if ( fileName == null )
			{
				throw new ArgumentNullException ( nameof ( fileName ) ) ;
			}

			version ??= ( await GetPackageVersion ( packageName ) ) ;

			if ( version is not null )
			{
				return $"https://cdnjs.cloudflare.com/ajax/libs/{packageName}/{version}/{fileName}" ;
			}

			throw new Exception ( ) ;
		}

		public async Task ClearCache ( ) => PackageVersions . Clear ( ) ;

	}

}

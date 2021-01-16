using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

using JetBrains . Annotations ;

using Microsoft.AspNetCore.Razor.TagHelpers;

using Newtonsoft.Json;


namespace DreamRecorder.ToolBox.AspNet.RequestHelper
{

	public class ExternalAssetTagHelper : TagHelper
	{

	}

	public interface IExternalWebAssetProvider
	{

		Task<string> GetPackageVersion(string packageName);

		Task<string> GetFileUrl(string packageName, string fileName);


	}

	public class CdnjsWebAssetProvider : IExternalWebAssetProvider
	{
		private WebClient CurrentClient { get; } = new WebClient();

		public static ConcurrentDictionary <string , string> PackageVersions { get ; set ; }

		public async Task<string> GetPackageVersion(
			[NotNull]
			string packageName)
		{
			if ( packageName == null )
			{
				throw new ArgumentNullException ( nameof ( packageName ) ) ;
			}

			if ( PackageVersions.TryGetValue(packageName,out string version) )
			{
				return version ;
			}
			else
			{
				dynamic apiQuery = JsonConvert.DeserializeObject(await CurrentClient.DownloadStringTaskAsync($"https://api.cdnjs.com/libraries/{packageName}?fields=version"));

				version = apiQuery . version ;

				if ( string.IsNullOrWhiteSpace(version) )
				{
					throw new Exception();
				}

				PackageVersions . TryAdd ( packageName , version ) ;

				return version;
			}
			
		}

		public Task <string> GetFileUrl (
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


		}

	}

}

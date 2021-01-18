using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

namespace DreamRecorder . ToolBox . AspNet . RequestHelper
{

	public class DreamryWebAssetProvider:IWebAssetProvider
	{

		public async Task <string> GetPackageVersion ( string packageName ) => string.Empty ;

		public async Task <string> GetFileUrl ( string packageName , string fileName ) => $"https://webresources.dreamry.org/lib/{packageName}/{fileName}";

		public async Task ClearCache ( ) {  }

	}

}

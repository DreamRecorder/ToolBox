using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamRecorder.ToolBox.AspNet.General;

public class DreamryWebAssetProvider : IWebAssetProvider
{

	public async Task <string> GetPackageVersion ( string packageName ) => "current";

	public async Task <string> GetFileUrl ( string packageName , string fileName , string version )
		=> $"{ConstantUrls.WebResource}lib/{packageName}/{version ?? await GetPackageVersion ( packageName )}/{fileName}";

	public async Task ClearCache ( ) { }

}

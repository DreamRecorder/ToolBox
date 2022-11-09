using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

namespace DreamRecorder . ToolBox . AspNet . General
{

	public interface IWebAssetProvider
	{

		Task ClearCache ( ) ;

		Task <string> GetFileUrl ( string packageName , string fileName , string version ) ;

		Task <string> GetPackageVersion ( string packageName ) ;

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

namespace DreamRecorder . ToolBox . AspNet . RequestHelper
{

	public interface IWebAssetProvider
	{

		Task <string> GetPackageVersion ( string packageName ) ;

		Task <string> GetFileUrl ( string packageName , string fileName ) ;

		Task ClearCache ( ) ;

	}

}

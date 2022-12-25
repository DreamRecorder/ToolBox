using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . AspNet . General ;

public abstract class ExternalAssetInfoBase
{

	protected ExternalAssetInfoBase ( string packageName , string fileName , string version = null )
	{
		FileName    = fileName ;
		PackageName = packageName ;
		Version     = version ;
	}

	public string FileName { get ; set ; }

	public string PackageName { get ; set ; }

	public string Version { get ; set ; }

}
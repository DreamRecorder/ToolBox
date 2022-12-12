using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . AspNet . General ;

public class StyleSheetInfo
{

	public string FileName { get ; set ; }

	public string PackageName { get ; set ; }

	public string Version { get ; set ; }

	public StyleSheetInfo ( string packageName , string fileName , string version = null )
	{
		FileName    = fileName ;
		PackageName = packageName ;
		Version     = version ;
	}

}
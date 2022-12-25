using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . AspNet . General ;

public sealed class ScriptInfo : ExternalAssetInfoBase
{

	public ScriptInfo ( string packageName , string fileName , string version = null ) : base ( packageName , fileName , version )
	{
	}

}
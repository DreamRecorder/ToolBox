using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using Microsoft . AspNetCore . Mvc . Razor ;

namespace DreamRecorder . ToolBox . AspNet . General ;

[PublicAPI]
public static class RazorPageBaseViewBagExtensions
{

	public static void AddScript ( this RazorPageBase page , ScriptInfo scriptInfo )
	{
		if ( page . ViewBag . AdditionalScript is not IList <ScriptInfo> list )
		{
			list = page . ViewBag . AdditionalScript = new List <ScriptInfo> ( ) ;
		}

		if ( scriptInfo != null )
		{
			list . Add ( scriptInfo ) ;
		}
	}

	public static void AddScript (
		this RazorPageBase      page ,
		string                  packageName ,
		string                  fileName ,
		string                  version = null ,
		bool                    isDefer = false ,
		ScriptInfo . ScriptType type    = ScriptInfo . ScriptType . Default )
	{
		page . AddScript ( new ScriptInfo ( packageName , fileName , version , isDefer , type ) ) ;
	}

	public static void AddStyleSheet ( this RazorPageBase page , StyleSheetInfo styleSheetInfo )
	{
		if ( page . ViewBag . AdditionalStyleSheet is not IList <StyleSheetInfo> list )
		{
			list = page . ViewBag . AdditionalStyleSheet = new List <StyleSheetInfo> ( ) ;
		}

		if ( styleSheetInfo != null )
		{
			list . Add ( styleSheetInfo ) ;
		}
	}

	public static void AddStyleSheet (
		this RazorPageBase page ,
		string             packageName ,
		string             fileName ,
		string             version = null )
	{
		page . AddStyleSheet ( new StyleSheetInfo ( packageName , fileName , version ) ) ;
	}

}

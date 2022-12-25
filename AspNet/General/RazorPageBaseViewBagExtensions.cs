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
		if ( page . ViewBag . AdditionalStyleSheet is not IList <StyleSheetInfo> list )
		{
			list = page . ViewBag . AdditionalStyleSheet = new List <StyleSheetInfo> ( ) ;
		}

		list . Add ( new StyleSheetInfo ( packageName , fileName , version ) ) ;
	}

}

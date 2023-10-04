using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

using JetBrains . Annotations ;

using Microsoft . AspNetCore . Razor . TagHelpers ;

namespace DreamRecorder . ToolBox . AspNet . General ;

[HtmlTargetElement ( Stylesheet )]
[HtmlTargetElement ( Script )]
[PublicAPI]
public class ExternalAssetTagHelper : TagHelper
{

	public string FileName { get ; set ; }

	public string PackageName { get ; set ; }

	public string Version { get ; set ; }

	public IWebAssetProvider WebAssetProvider { get ; }

	public ExternalAssetTagHelper ( IWebAssetProvider webAssetProvider ) => WebAssetProvider = webAssetProvider ;

	public const string Stylesheet = "stylesheet" ;

	public const string Script = "script" ;

	public override async Task ProcessAsync ( TagHelperContext context , TagHelperOutput output )
	{
		if ( PackageName == null
			 || FileName == null )
		{
			return ;
		}

		string uri = await WebAssetProvider . GetFileUrl ( PackageName , FileName , Version ) ;

		switch ( context . TagName )
		{
			case Stylesheet :
			{
				output . TagName = "link" ;
				output . TagMode = TagMode . SelfClosing ;
				output . Attributes . SetAttribute ( "rel" ,  Stylesheet ) ;
				output . Attributes . SetAttribute ( "href" , uri ) ;
				break ;
			}
			case Script :
			{
				output . TagName = Script ;
				output . TagMode = TagMode . StartTagAndEndTag ;
				output . Attributes . SetAttribute ( "src" , uri ) ;
				break ;
			}
		}

		output . Attributes . SetAttribute ( "crossorigin" , "anonymous" ) ;
	}

}

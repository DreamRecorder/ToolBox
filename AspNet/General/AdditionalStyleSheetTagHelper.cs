using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

using JetBrains . Annotations ;

using Microsoft . AspNetCore . Mvc . Rendering ;
using Microsoft . AspNetCore . Razor . TagHelpers ;

namespace DreamRecorder . ToolBox . AspNet . General ;

[PublicAPI]
public class AdditionalStyleSheetTagHelper : TagHelper
{

	public dynamic ViewBag { get ; set ; }

	public IWebAssetProvider WebAssetProvider { get ; }

	public AdditionalStyleSheetTagHelper ( IWebAssetProvider webAssetProvider )
		=> WebAssetProvider = webAssetProvider ;

	public override async Task ProcessAsync ( TagHelperContext context , TagHelperOutput output )
	{
		output . TagName = null ;

		if ( ViewBag ? . AdditionalStyleSheet is IList <StyleSheetInfo> list )
		{
			foreach ( StyleSheetInfo info in list )
			{
				string uri =
					await WebAssetProvider . GetFileUrl ( info . PackageName , info . FileName , info . Version ) ;

				TagBuilder link = new TagBuilder ( "link" ) ;
				link . Attributes . Add ( "rel" ,  ExternalAssetTagHelper . Stylesheet ) ;
				link . Attributes . Add ( "href" , uri ) ;
				link . TagRenderMode = TagRenderMode . SelfClosing ;

				output . Content . AppendHtml ( link ) ;
			}
		}
	}

}
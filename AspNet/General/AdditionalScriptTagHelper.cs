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
public class AdditionalScriptTagHelper : TagHelper
{

	public dynamic ViewBag { get ; set ; }

	public IWebAssetProvider WebAssetProvider { get ; }

	public AdditionalScriptTagHelper ( IWebAssetProvider webAssetProvider ) => WebAssetProvider = webAssetProvider ;

	public override async Task ProcessAsync ( TagHelperContext context , TagHelperOutput output )
	{
		output . TagName = null ;

		if ( ViewBag ? . AdditionalScript is IList <ScriptInfo> list )
		{
			foreach ( ScriptInfo info in list )
			{
				string uri =
					await WebAssetProvider . GetFileUrl ( info . PackageName , info . FileName , info . Version ) ;

				TagBuilder link = new TagBuilder ( ExternalAssetTagHelper . Script ) ;
				output . TagMode = TagMode . StartTagAndEndTag ;
				output . Attributes . SetAttribute ( "src" , uri ) ;

				if ( info . IsDefer )
				{
					output . Attributes . SetAttribute ( new TagHelperAttribute ( "defer" ) ) ;
				}

				switch ( info . Type )
				{
					case ScriptInfo . ScriptType . Module :
						output . Attributes . SetAttribute ( "type" , "module" ) ;
						break ;
					case ScriptInfo . ScriptType . ImportMap :
						output . Attributes . SetAttribute ( "type" , @"importmap" ) ;
						break ;
				}

				output . Content . AppendHtml ( link ) ;
			}
		}
	}

}

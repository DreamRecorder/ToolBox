using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

using Microsoft . AspNetCore . Razor . TagHelpers ;

namespace DreamRecorder . ToolBox . AspNet . RequestHelper
{

	[HtmlTargetElement ( Stylesheet )]
	[HtmlTargetElement ( Script )]
	public class ExternalAssetTagHelper : TagHelper
	{
		public IWebAssetProvider WebAssetProvider { get ; set ; }

		public string PackageName { get ; set ; }

		public string FileName { get ; set ; }

		public const string Stylesheet = "stylesheet" ;

		public const string Script = "script" ;

		public override async Task ProcessAsync ( TagHelperContext context , TagHelperOutput output )
		{
			if ( PackageName == null
				|| FileName  == null )
			{
				return ;
			}

			string uri = await WebAssetProvider . GetFileUrl ( PackageName , FileName ) ;

			switch ( context . TagName )
			{
				case Stylesheet :
				{
					output . TagName = "link" ;
					output . TagMode = TagMode . SelfClosing ;
					output . Attributes . SetAttribute ( "rel" ,  "stylesheet" ) ;
					output . Attributes . SetAttribute ( "href" , uri ) ;
					break ;
				}
				case Script :
				{
					output . TagName = "script" ;
					output . TagMode = TagMode . StartTagAndEndTag ;
					output . Attributes . SetAttribute ( "src" , uri ) ;
					break ;
				}
			}

			output . Attributes . SetAttribute ( "crossorigin" , "anonymous" ) ;
		}

	}

}

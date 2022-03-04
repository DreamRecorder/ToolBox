using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net . Http ;
using System . Text ;
using System . Threading . Tasks ;

using Microsoft . AspNetCore . Mvc . Rendering ;
using Microsoft . AspNetCore . Mvc . ViewFeatures ;
using Microsoft . AspNetCore . Razor . TagHelpers ;

namespace DreamRecorder . ToolBox . AspNet . CommonComponent
{

	[HtmlTargetElement ( "commonfooter" )]
	public class CommonFooterTagHelper : TagHelper
	{

		private HttpClient HttpClient { get ; }

		public CommonFooterTagHelper ( HttpClient httpClient ) { HttpClient = httpClient ; }

		public override async Task ProcessAsync ( TagHelperContext context , TagHelperOutput output )
		{
			output . TagName = @"div" ;
			output . TagMode = TagMode . StartTagAndEndTag ;
			output . Content . SetHtmlContent (
												await HttpClient . GetStringAsync (
												"https://webresources.dreamry.org/CommonFooter.html" ) ) ;
		}

	}

}

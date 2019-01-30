using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;

using Microsoft . AspNetCore . Mvc . Rendering ;
using Microsoft . AspNetCore . Mvc . ViewFeatures ;
using Microsoft . AspNetCore . Razor . TagHelpers ;

namespace DreamRecorder . ToolBox . AspNet . AlertHelper
{

	public class AlertsTagHelper : TagHelper
	{

		[ViewContext]
		public ViewContext ViewContext { get ; set ; }

		private List <Alert> Alerts
			=> ViewContext ? . ViewData [ StringConst . Alerts ] as List <Alert> ?? new List <Alert> ( ) ;

		public override void Process ( TagHelperContext context , TagHelperOutput output )
		{
			StringBuilder result = new StringBuilder ( ) ;

			foreach ( Alert alert in Alerts )
			{
				result . AppendLine ( $"<div class=\"alert alert-{alert . Variation . ToString ( ) . ToLower ( )}\" role=\"alert\">{alert . Message}</div>" ) ;
			}

			output . TagName = @"div" ;
			output . TagMode = TagMode . StartTagAndEndTag ;
			output . Content . SetHtmlContent ( result . ToString ( ) ) ;
		}

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;
using System . Runtime . Serialization . Formatters . Binary ;
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

		public List <Alert> GetAlerts ( )
		{
			BinaryFormatter formatter = new BinaryFormatter ( ) ;
			List <Alert>    alerts ;

			if ( ViewContext . HttpContext . Session . TryGetValue ( StringConst . Alerts , out byte [ ] buffer ) )
			{
				MemoryStream stream = new MemoryStream ( buffer ) ;
				alerts = formatter . Deserialize ( stream ) as List <Alert> ?? new List <Alert> ( ) ;
			}
			else
			{
				alerts = new List <Alert> ( ) ;
			}

			return alerts ;
		}

		public void ClearAlerts ( ) { ViewContext . HttpContext . Session . Remove ( StringConst . Alerts ) ; }

		public override void Process ( TagHelperContext context , TagHelperOutput output )
		{
			StringBuilder result = new StringBuilder ( ) ;
			List <Alert>  alerts = GetAlerts ( ) ;

			foreach ( Alert alert in alerts )
			{
				result . AppendLine ( $"<div class=\"alert alert-{alert . Variation . ToString ( ) . ToLower ( )}\" role=\"alert\">{alert . Message}</div>" ) ;
			}

			output . TagName = @"div" ;
			output . TagMode = TagMode . StartTagAndEndTag ;
			output . Content . SetHtmlContent ( result . ToString ( ) ) ;

			ClearAlerts ( ) ;
		}

	}

}

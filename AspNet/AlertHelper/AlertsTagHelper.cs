using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;
using System . Text ;
using System . Xml . Serialization ;

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
			XmlSerializer formatter = new XmlSerializer ( typeof ( AlertGroup ) ) ;
			List <Alert>  alerts ;

			if ( ViewContext . HttpContext . Session . TryGetValue ( Constants . Alerts , out byte [ ] buffer ) )
			{
				MemoryStream stream = new MemoryStream ( buffer ) ;
				alerts = ( formatter . Deserialize ( stream ) as AlertGroup ) ? . Alerts ?? new List <Alert> ( ) ;
			}
			else
			{
				alerts = new List <Alert> ( ) ;
			}

			return alerts ;
		}

		private void ClearAlerts ( ) { ViewContext . HttpContext . Session . Remove ( Constants . Alerts ) ; }

		public override void Process ( TagHelperContext context , TagHelperOutput output )
		{
			StringBuilder htmlString = new StringBuilder ( ) ;
			List <Alert>  alerts     = GetAlerts ( ) ;

			foreach ( Alert alert in alerts )
			{
				if ( alert . Dismissible )
				{
					const string dismissible = " alert-dismissible fade show" ;
					const string button = @"
                <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
                <span aria-hidden=""true"">&times;</span>
                </button>" ;

					htmlString . AppendLine (
											$"<div class=\"alert alert-{alert . Variation . ToString ( ) . ToLower ( )}{dismissible}\" role=\"alert\">\n{alert . Content}{button}\n</div>" ) ;
				}

				htmlString . AppendLine (
										$"<div class=\"alert alert-{alert . Variation . ToString ( ) . ToLower ( )}\" role=\"alert\">{alert . Content}</div>" ) ;
			}

			output . TagName = @"div" ;
			output . TagMode = TagMode . StartTagAndEndTag ;
			output . Content . SetHtmlContent ( htmlString . ToString ( ) ) ;

			ClearAlerts ( ) ;
		}

	}

}

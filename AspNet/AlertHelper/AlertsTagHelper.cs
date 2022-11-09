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

		private void ClearAlerts ( ) { ViewContext . HttpContext . Session . Remove ( Constants . Alerts ) ; }

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

		public override void Process ( TagHelperContext context , TagHelperOutput output )
		{
			StringBuilder htmlString = new StringBuilder ( ) ;
			List <Alert>  alerts     = GetAlerts ( ) ;

			foreach ( Alert alert in alerts )
			{
				htmlString . AppendLine ( alert . ToHtmlString ( ) ) ;
			}

			output . TagName = @"div" ;
			output . TagMode = TagMode . StartTagAndEndTag ;
			output . Content . SetHtmlContent ( htmlString . ToString ( ) ) ;

			ClearAlerts ( ) ;
		}

	}

}

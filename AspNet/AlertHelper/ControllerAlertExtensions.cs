using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using Microsoft . AspNetCore . Mvc ;

namespace DreamRecorder . ToolBox . AspNet . AlertHelper
{

	[PublicAPI]
	public static class ControllerAlertExtensions
	{

		public static List <Alert> GetAlerts ( [NotNull] this Controller controller )
		{
			List <Alert> alerts =
				controller . ViewData [ StringConst . Alerts ] as List <Alert> ?? new List <Alert> ( ) ;

			controller . ViewData [ StringConst . Alerts ] = alerts ;

			return alerts ;
		}

		public static void AddAlert ( [NotNull] this Controller controller , [NotNull] Alert alert )
		{
			if ( controller == null )
			{
				throw new ArgumentNullException ( nameof(controller) ) ;
			}

			if ( alert == null )
			{
				throw new ArgumentNullException ( nameof(alert) ) ;
			}

			List <Alert> alerts = GetAlerts ( controller ) ;

			alerts . Add ( alert ) ;
		}

		public static void AlertError ( [NotNull] this Controller controller , string message )
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Danger , message ) ) ;
		}

		public static void AlertInfo ( [NotNull] this Controller controller , string message )
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Info , message ) ) ;
		}

		public static void AlertWarning ( [NotNull] this Controller controller , string message )
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Warning , message ) ) ;
		}

		public static void AlertSuccess ( [NotNull] this Controller controller , string message )
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Success , message ) ) ;
		}

		public static void AlertPrimary ( [NotNull] this Controller controller , string message )
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Primary , message ) ) ;
		}

		public static void AlertSecondary ( [NotNull] this Controller controller , string message )
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Secondary , message ) ) ;
		}

	}

}

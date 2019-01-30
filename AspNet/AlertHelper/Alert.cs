using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using Microsoft . AspNetCore . Mvc ;

namespace DreamRecorder . ToolBox . AlertHelper
{

	public static class StringConst
	{

		public const string Alerts = nameof(Alerts);

	}

	[PublicAPI]
	public static class ControllerAlertExtensions
	{

		public static void AddAlert ( [NotNull] this Controller controller , [NotNull] Alert alert )
		{
			if (controller == null)
			{
				throw new ArgumentNullException(nameof(controller));
			}

			if ( alert == null )
			{
				throw new ArgumentNullException ( nameof(alert) ) ;
			}

			List<Alert> alerts = (controller.ViewData[StringConst.Alerts] as List<Alert> ?? new List<Alert>());

			alerts . Add ( alert ) ;

			controller.ViewData[StringConst.Alerts] = alerts;
		}

		public static void AlertError( [NotNull] this Controller controller, string message)
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Danger , message ) ) ;
		}

		public static void AlertInfo([NotNull] this Controller controller, string message)
		{
			AddAlert(controller, new Alert(BootstrapVariation.Info, message));
		}

		public static void AlertWarning([NotNull] this Controller controller, string message)
		{
			AddAlert(controller, new Alert(BootstrapVariation.Warning, message));
		}

		public static void AlertSuccess([NotNull] this Controller controller, string message)
		{
			AddAlert(controller, new Alert(BootstrapVariation.Success, message));
		}

		public static void AlertPrimary([NotNull] this Controller controller, string message)
		{
			AddAlert(controller, new Alert(BootstrapVariation.Primary, message));
		}

		public static void AlertSecondary([NotNull] this Controller controller, string message)
		{
			AddAlert(controller, new Alert(BootstrapVariation.Secondary, message));
		}

	}

	public class Alert
	{

		public Alert ( BootstrapVariation variation , string message )
		{
			Variation = variation ;
			Message = message ;
		}

		public BootstrapVariation Variation { get ; set ; }

		public string Message { get; set; }

	}

}

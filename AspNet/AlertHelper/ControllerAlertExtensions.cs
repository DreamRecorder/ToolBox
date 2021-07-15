using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;
using System . Xml . Serialization ;

using DreamRecorder . ToolBox . AspNet . General ;

using JetBrains . Annotations ;

using Microsoft . AspNetCore . Mvc ;

namespace DreamRecorder . ToolBox . AspNet . AlertHelper
{

	[PublicAPI]
	public static class ControllerAlertExtensions
	{

		public static void SetAlerts (
			[NotNull]
			this Controller controller ,
			List <Alert> alerts )
		{
			XmlSerializer formatter = new XmlSerializer ( typeof ( AlertGroup ) ) ;
			MemoryStream  stream    = new MemoryStream ( ) ;
			formatter . Serialize ( stream , new AlertGroup { Alerts = alerts } ) ;

			controller . HttpContext . Session . Set (
													Constants . Alerts ,
													stream . GetBuffer ( ) ) ;
		}

		public static List <Alert> GetAlerts (
			[NotNull]
			this Controller controller )
		{
			XmlSerializer formatter = new XmlSerializer ( typeof ( AlertGroup ) ) ;
			List <Alert>  alerts ;

			if ( controller . HttpContext . Session . TryGetValue (
			Constants . Alerts ,
			out byte [ ] buffer ) )
			{
				MemoryStream stream = new MemoryStream ( buffer ) ;
				alerts = ( formatter . Deserialize ( stream ) as AlertGroup ) ? . Alerts
					?? new List <Alert> ( ) ;
			}
			else
			{
				alerts = new List <Alert> ( ) ;
			}

			return alerts ;
		}

		public static void AddAlert (
			[NotNull]
			this Controller controller ,
			[NotNull]
			Alert alert )
		{
			if ( controller == null )
			{
				throw new ArgumentNullException ( nameof ( controller ) ) ;
			}

			List <Alert> alerts = GetAlerts ( controller ) ;

			alerts . Add ( alert ) ;

			SetAlerts ( controller , alerts ) ;
		}

		public static void AlertError (
			[NotNull]
			this Controller controller ,
			string message )
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Danger , message ) ) ;
		}

		public static void AlertInfo (
			[NotNull]
			this Controller controller ,
			string message )
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Info , message ) ) ;
		}

		public static void AlertWarning (
			[NotNull]
			this Controller controller ,
			string message )
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Warning , message ) ) ;
		}

		public static void AlertSuccess (
			[NotNull]
			this Controller controller ,
			string message )
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Success , message ) ) ;
		}

		public static void AlertPrimary (
			[NotNull]
			this Controller controller ,
			string message )
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Primary , message ) ) ;
		}

		public static void AlertSecondary (
			[NotNull]
			this Controller controller ,
			string message )
		{
			AddAlert ( controller , new Alert ( BootstrapVariation . Secondary , message ) ) ;
		}

	}

}

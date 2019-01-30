using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . AspNet . AlertHelper
{

	public class Alert
	{

		public BootstrapVariation Variation { get ; set ; }

		public string Message { get ; set ; }

		public Alert ( BootstrapVariation variation , string message )
		{
			Variation = variation ;
			Message = message ;
		}

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public static class ExceptionMessages
	{

		public static string XmlNameMismatch ( string argumentName , Type type )
		{
			return $"{argumentName} do not perform a {type . FullName}" ;
		}

	}

}

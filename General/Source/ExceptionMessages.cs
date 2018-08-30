using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public static class ExceptionMessages
	{

		public static string XmlNameMismatch ( string argumentName , Type type )
		{
			return $"{argumentName} do not perform a {type . FullName}." ;
		}

		public static string XmlWrongData ( string argumentName )
		{
			return $"{argumentName} has wrong data or lack of data." ;
		}

		public static string NecessaryValueNotFound ( XElement element , string name )
		{
			return $"{element} should have property {name}." ;
		}

	}

}

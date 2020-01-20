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
			=> $"{argumentName} do not perform a {type . FullName}." ;

		public static string XmlWrongData ( string argumentName )
			=> $"{argumentName} has wrong data or lack of data." ;

		public static string NecessaryValueNotFound ( XElement element , string name )
			=> $"{element} should have property {name}." ;


		public static string NotPrepared ( ) => "this assembly is not prepared." ;

	}

}

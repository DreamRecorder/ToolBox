using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public static class ExceptionHelper
	{

		public static ArgumentException XmlNameMismatch ( string argumentName , Type type )
		{
			return new ArgumentException ( ExceptionMessages . XmlNameMismatch ( argumentName , type ) ,
											argumentName ) ;
		}

	}

}
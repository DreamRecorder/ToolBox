using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public static class ExceptionHelper
	{

		public static bool Success ( this Action action )
		{
			try
			{
				action ( ) ;
				return true ;
			}
			catch
			{
				return false ;
			}
		}

		public static T IgnoreException <T> ( this Func <T> func , T onError = default )
		{
			try
			{
				return func ( ) ;
			}
			catch
			{
				return onError ;
			}
		}

		public static ArgumentException XmlNameMismatch ( string argumentName , Type type )
			=> new ArgumentException ( ExceptionMessages . XmlNameMismatch ( argumentName , type ) , argumentName ) ;

	}

}

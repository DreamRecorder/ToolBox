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

		public static T IgnoreException <T> ( this Func <T> func , T onError = default ) where T : class
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

		public static T ? IgnoreException <T> ( this Func <T> func , T ? onError = default ) where T : struct
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

		public static bool Try <T> ( this Func <T> func , out T result )
		{
			try
			{
				result = func ( ) ;
				return true ;
			}
			catch
			{
				result = default ;
				return false ;
			}
		}

		public static ArgumentException XmlNameMismatch ( string argumentName , Type type )
			=> new ArgumentException ( ExceptionMessages . XmlNameMismatch ( argumentName , type ) , argumentName ) ;

	}

}

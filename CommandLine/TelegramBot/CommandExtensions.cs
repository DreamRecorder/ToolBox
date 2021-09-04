using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public static class CommandExtensions
	{

		public static string GetCommandName ( [NotNull] this string argument )
		{
			if ( string . IsNullOrWhiteSpace ( argument ) )
			{
				throw new ArgumentNullException ( nameof ( argument ) ) ;
			}

			return argument . Split ( '@' , StringSplitOptions . RemoveEmptyEntries ) . First ( ) ;
		}

	}

}

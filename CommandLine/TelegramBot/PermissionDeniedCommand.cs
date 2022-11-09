using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using Telegram . Bot ;
using Telegram . Bot . Types ;
using Telegram . Bot . Types . Enums ;
using Telegram . Bot . Types . ReplyMarkups ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public class PermissionDeniedCommand <TUser> : TelegramCommand <TUser> where TUser : IUser
	{

		public static PermissionDeniedCommand <TUser> Current { get ; private set ; }

		public override string HelpInformation => string . Empty ;

		public override CommandPermissionGroup PermissionGroup => null ;

		public override TimeSpan Timeout => TimeSpan . FromMinutes ( 1 ) ;

		public override bool CanBeRouteTarget ( Session <TUser> session ) => false ;

		[Prepare]
		public static void Prepare ( ) { Current = new PermissionDeniedCommand <TUser> ( ) ; }

		public override bool Process (
			Message         message ,
			string [ ]      args ,
			Session <TUser> session ,
			bool            isExactlyMatched ,
			object          tag = null )
		{
			if ( tag is ICommand <TUser> command )
			{
				session . BotClient . SendTextMessageAsync (
															session . PrivateChatId ,
															$"Command `{command . DisplayName}` do not have permission to read your personal info." ,
															ParseMode . Markdown ,
															replyToMessageId : message . MessageId ,
															replyMarkup : new InlineKeyboardMarkup (
															 InlineKeyboardButton . WithCallbackData (
															  "Grant permission" ,
															  $"RegisterCommandGroup {command . PermissionGroup . Guid}" ) ) ) .
						  Wait ( ) ;
			}

			return true ;
		}

		public override void Process (
			CallbackQuery   callbackQuery ,
			string [ ]      args ,
			Session <TUser> session ,
			object          tag = null )
		{
			if ( tag is ICommand <TUser> command )
			{
				session . ReplyText (
									 callbackQuery . Message ,
									 $"Command `{command ? . PermissionGroup ? . DisplayName}{command . DisplayName}` do not have permission to read your personal info." ,
									 ParseMode . Markdown ,
									 replyMarkup : new InlineKeyboardMarkup (
																			 InlineKeyboardButton . WithCallbackData (
																			  "Grant permission" ,
																			  $"RegisterCommandGroup {command . PermissionGroup . Guid}" ) ) ) ;
			}
		}

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading ;

using JetBrains . Annotations ;

using Telegram . Bot ;
using Telegram . Bot . Types ;
using Telegram . Bot . Types . Enums ;
using Telegram . Bot . Types . ReplyMarkups ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public class Session <TUser> where TUser : IUser
	{

		[CanBeNull]
		public TUser User { get ; set ; }

		[CanBeNull]
		public ChatId PrivateChatId { get ; set ; }

		[CanBeNull]
		public ICommand <TUser> RouteBind { get ; set ; }

		public DateTime LastAccessTime { get ; set ; }

		public TimeSpan TimeToLive { get ; set ; }

		public Dictionary <string , object> Properties { get ; set ; } = new Dictionary <string , object> ( ) ;

		public ITelegramBotClient BotClient { get ; set ; }

		public void ReplyText (
			[CanBeNull] Message message ,
			[NotNull]   string  text ,
			ParseMode           parseMode             = ParseMode . Default ,
			bool                disableWebPagePreview = false ,
			bool                disableNotification   = false ,
			IReplyMarkup        replyMarkup           = null ,
			CancellationToken   cancellationToken     = default )
		{
			BotClient . SendTextMessageAsync (
											PrivateChatId ,
											text ,
											parseMode ,
											default ,
											disableWebPagePreview ,
											disableNotification ,
											message ? . MessageId ?? default ,
											true ,
											replyMarkup ,
											cancellationToken ) .
						Wait ( cancellationToken ) ;
		}

	}

}

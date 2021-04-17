using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;

using DreamRecorder . ToolBox . General ;

using JetBrains . Annotations ;

using Microsoft . Extensions . DependencyInjection ;

using Telegram . Bot . Types ;
using Telegram . Bot . Types . Enums ;
using Telegram . Bot . Types . ReplyMarkups ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public class CreateUserCommand <TUser> : TelegramCommand <TUser> where TUser : IUser
	{

		private IUserServiceProvider <TUser> ServiceProvider
			=> StaticServiceProvider . Provider . GetService <IUserServiceProvider <TUser>> ( ) ;

		public override TimeSpan Timeout => TimeSpan . FromMinutes ( 1 ) ;

		public override CommandPermissionGroup PermissionGroup => null ;

		public static List <InlineKeyboardButton> CreateUserKeyboard { get ; } =
			new List <InlineKeyboardButton>
			{
				new InlineKeyboardButton
				{
					Text = "Do create New User and Bind it" , CallbackData = $"{nameof ( CreateUserCommand <TUser> )}"
				}
			} ;

		public override string HelpInformation
			=> $"Create new user and bind on it.{Environment . NewLine}```{Environment . NewLine}/CreateUser```" ;

		public override bool CanBeRouteTarget ( Session <TUser> session ) => session . User is null ;

		public override bool Process (
			Message         message ,
			string [ ]      args ,
			Session <TUser> session ,
			bool            isExactlyMatched ,
			object          tag = null )
		{
			if ( isExactlyMatched )
			{
				CreateUser ( message . From , message , session ) ;
			}
			else
			{
				session . ReplyText (
									message ,
									"Issue the following inline keyboard button to create a new user." ,
									replyMarkup : new InlineKeyboardMarkup ( CreateUserKeyboard ) ) ;
			}

			return true ;
		}

		private void CreateUser (
			User requester ,
			[CanBeNull]
			Message message ,
			Session <TUser> session )
		{
			TUser user = ServiceProvider . CreateUser ( ) ;

			user = ServiceProvider . BindUser ( requester . Id , user ) ;

			StringBuilder builder = new StringBuilder ( ) ;

			builder . AppendLine ( "Your user has been created." ) ;
			builder . AppendLine ( "You can bind this user to any telegram account by using following command:" ) ;
			builder . AppendLine ( ) ;
			builder . AppendLine ( "```" ) ;
			builder . AppendLine ( $"/BindToUser {user . Guid} {ServiceProvider . GetContinuationCode ( user )}" ) ;
			builder . AppendLine ( "```" ) ;

			// ReSharper disable once ArgumentsStyleNamedExpression
			session . ReplyText ( message , builder . ToString ( ) , parseMode : ParseMode . Markdown ) ;
		}

		public override void Process (
			CallbackQuery   callbackQuery ,
			string [ ]      args ,
			Session <TUser> session ,
			object          tag = null )
		{
			CreateUser ( callbackQuery . From , null , session ) ;

			session . BotClient . EditMessageReplyMarkupAsync (
																callbackQuery . Message . Chat . Id ,
																callbackQuery . Message . MessageId ) .
					Wait ( ) ;
		}

	}

}

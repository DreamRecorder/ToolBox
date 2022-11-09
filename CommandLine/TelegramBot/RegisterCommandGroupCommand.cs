using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using Microsoft . Extensions . DependencyInjection ;

using Telegram . Bot ;
using Telegram . Bot . Types ;
using Telegram . Bot . Types . Enums ;
using Telegram . Bot . Types . ReplyMarkups ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public class RegisterCommandGroupCommand <TUser> : TelegramCommand <TUser> where TUser : IUser
	{

		public ICommandProvider <TUser> CommandProvider
			=> StaticServiceProvider . Provider . GetService <ICommandProvider <TUser>> ( ) ;

		public override string HelpInformation
			=> $"Register command group.{Environment . NewLine}```{Environment . NewLine}/RegisterCommandGroup guid{Environment . NewLine}```{Environment . NewLine}	 `guid`:	the guid of commandGroup" ;

		public override CommandPermissionGroup PermissionGroup => null ;

		public IUserServiceProvider <TUser> ServiceProvider
			=> StaticServiceProvider . Provider . GetService <IUserServiceProvider <TUser>> ( ) ;

		public override TimeSpan Timeout => TimeSpan . FromMinutes ( 1 ) ;

		public override bool CanBeRouteTarget ( Session <TUser> session ) => ! ( session . User is null ) ;

		public override bool Process (
			Message         message ,
			string [ ]      args ,
			Session <TUser> session ,
			bool            isExactlyMatched ,
			object          tag = null )
		{
			if ( args . Length == 2 )
			{
				if ( Guid . TryParse ( args [ 1 ] , out Guid guid ) )
				{
					CommandPermissionGroup permissionGroup = CommandProvider . GetCommands ( ) .
																			   FirstOrDefault (
																				command
																					=> command ? .
																							PermissionGroup ? . Guid
																						== guid ) ? .
																			   PermissionGroup ;

					if ( permissionGroup != null )
					{
						if ( ServiceProvider . CheckCommandPermissionGroup ( session . User , permissionGroup ) )
						{
							session . ReplyText (
												 message ,
												 $"You have already bound to {permissionGroup . DisplayName}" ) ;
						}
						else
						{
							if ( isExactlyMatched )
							{
								ServiceProvider . BindCommandPermissionGroup ( session . User , permissionGroup ) ;

								session . ReplyText (
													 message ,
													 $"You have successfully bound to {permissionGroup . DisplayName}" ) ;
							}
							else
							{
								session . ReplyText (
													 message ,
													 $"Issue the following inline keyboard button to bind to {permissionGroup . DisplayName}." ,
													 replyMarkup : new InlineKeyboardMarkup (
													  new List <InlineKeyboardButton>
													  {
														  InlineKeyboardButton . WithCallbackData (
														   $"Do register {permissionGroup . DisplayName}" ,
														   $"{nameof ( CreateUserCommand <TUser> )} {permissionGroup . Guid}" ) ,
													  } ) ) ;
							}
						}
					}
					else
					{
						session . ReplyText ( message , "We can not found the command group that you referenced." ) ;
					}
				}
				else
				{
					session . ReplyText ( message , "We can not parse the command group guid you provided." ) ;
				}
			}
			else
			{
				session . ReplyText ( message , HelpInformation , ParseMode . Markdown ) ;
			}

			return true ;
		}

		public override void Process (
			CallbackQuery   callbackQuery ,
			string [ ]      args ,
			Session <TUser> session ,
			object          tag = null )
		{
			Process ( callbackQuery . Message , args , session , true , tag ) ;

			session . BotClient . EditMessageReplyMarkupAsync (
															   callbackQuery . Message . Chat . Id ,
															   callbackQuery . Message . MessageId ) .
					  Wait ( ) ;
		}

	}

}

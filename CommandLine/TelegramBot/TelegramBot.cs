using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;
using System . Text ;
using System . Threading . Tasks ;

using DreamRecorder . ToolBox . General ;

using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . Logging ;

using Telegram . Bot ;
using Telegram . Bot . Args ;
using Telegram . Bot . Types ;
using Telegram . Bot . Types . Enums ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public class TelegramBot <TUser> where TUser : IUser
	{

		protected ILogger Logger { get ; }

		public string BotToken { get ; set ; }

		public WebProxy WebProxy { get ; set ; }

		public ITelegramBotClient BotClient { get ; private set ; }

		public ISessionProvider <TUser> SessionProvider { get ; private set ; }

		public ICommandProvider <TUser> CommandProvider { get ; private set ; }

		public ITelegramIdUserProvider <TUser> UserProvider { get ; private set ; }

		public IUserPermissionProvider <TUser> PermissionProvider { get ; private set ; }

		public ITaskDispatcher TaskDispatcher { get ; set ; }

		public async Task Start ( string [ ] args )
		{
			IServiceProvider provider = StaticServiceProvider . Provider ;

			SessionProvider    = provider . GetService <ISessionProvider <TUser>> ( ) ;
			CommandProvider    = provider . GetService <ICommandProvider <TUser>> ( ) ;
			UserProvider       = provider . GetService <ITelegramIdUserProvider <TUser>> ( ) ;
			PermissionProvider = provider . GetService <IUserPermissionProvider <TUser>> ( ) ;

			TaskDispatcher = provider . GetService <ITaskDispatcher> ( ) ;

			TaskDispatcher . Start ( ) ;

			BotClient = new TelegramBotClient ( BotToken , WebProxy ) ;

			Logger . LogInformation ( "Connecting..." ) ;

			User me = await BotClient . GetMeAsync ( ) ;
			Logger . LogInformation ( "Use Bot {0}" , me . Username ) ;
			Console . Title = me . Username ;

			BotClient . OnMessage       += BotClient_OnMessage ;
			BotClient . OnCallbackQuery += BotClient_OnCallbackQuery ;
			BotClient . OnInlineQuery   += BotClient_OnInlineQuery ;

			BotClient . StartReceiving ( ) ;
		}

		private void BotClient_OnMessage ( object sender , MessageEventArgs e )
		{
			try
			{
				Message message = e ? . Message ;

				if ( message is null )
				{
					return ;
				}

				TUser           user = UserProvider . GetUser ( message . From . Id ) ;
				Session <TUser> currentSession ;
				object          tag = null ;

				if ( user is null )
				{
					if ( message . Chat . Type == ChatType . Private )
					{
						currentSession                 = SessionProvider . GetSession ( message . From . Id ) ;
						currentSession . PrivateChatId = message . Chat . Id ;
					}
					else
					{
						return ;
					}
				}
				else
				{
					currentSession = SessionProvider . GetSession ( user ) ;
					if ( message . Chat . Type == ChatType . Private )
					{
						currentSession . PrivateChatId = message . Chat . Id ;
					}
				}

				currentSession . BotClient = BotClient ;

				ICommand <TUser> routeTarget      = currentSession . RouteBind ;
				string [ ]       args             = default ;
				bool             isExactlyMatched = false ;

				string text = message . Text ? . Normalize ( NormalizationForm . FormKD ) ? . Trim ( ) ;

				if ( routeTarget is null )
				{
					if ( string . IsNullOrWhiteSpace ( text ) )
					{
						return ;
					}

					if ( text . First ( ) == '/' )
					{
						text = text . TrimStart ( '/' ) ;

						args = text . Split ( ' ' , StringSplitOptions . RemoveEmptyEntries ) ;

						if ( args . Length > 0 )
						{
							string commandName = args . First ( ) . GetCommandName ( ) ;

							routeTarget = CommandProvider . GetCommand ( commandName , currentSession ) ;

							if ( routeTarget is null )
							{
								routeTarget      = CommandProvider . GetCommandFuzzy ( commandName , currentSession ) ;
								isExactlyMatched = false ;
							}
							else
							{
								isExactlyMatched = true ;
							}
						}
						else
						{
							routeTarget      = EmptyCommand <TUser> . Current ;
							isExactlyMatched = false ;
						}
					}
					else
					{
						//no command 
						//
						if ( message . Chat . Type == ChatType . Private )
						{
							routeTarget      = EmptyCommand <TUser> . Current ;
							isExactlyMatched = false ;
						}
					}
				}
				else
				{
					args = text ? . Split ( ' ' , StringSplitOptions . RemoveEmptyEntries ) ?? new string [ ] { } ;

					isExactlyMatched = true ;
				}

				if ( ! ( routeTarget is null ) )
				{
					if ( ! PermissionProvider . IsAllowedToInvoke ( user , routeTarget . PermissionGroup ) )
					{
						tag         = routeTarget ;
						routeTarget = PermissionDeniedCommand <TUser> . Current ;
					}

					TaskDispatcher . Dispatch (
												new OnetimeTask (
																( )
																	=> routeTarget . Process (
																	message ,
																	args ?? new string [ ] { } ,
																	currentSession ,
																	isExactlyMatched ,
																	tag ) ,
																routeTarget . Timeout ) ) ;
				}
			}
			catch ( Exception exception )
			{
				Console . WriteLine ( exception ) ;
			}
		}

		private void BotClient_OnInlineQuery ( object sender , InlineQueryEventArgs e )
		{
			InlineQuery inlineQuery = e ? . InlineQuery ;

			if ( ! ( inlineQuery is null ) )
			{
				string req = inlineQuery . Query ;
			}
		}

		private void BotClient_OnCallbackQuery ( object sender , CallbackQueryEventArgs e )
		{
			try
			{
				CallbackQuery callbackQuery = e ? . CallbackQuery ;

				if ( callbackQuery is null )
				{
					return ;
				}

				string requestData = callbackQuery . Data ;
				if ( string . IsNullOrWhiteSpace ( requestData ) )
				{
					return ;
				}

				requestData = requestData . Normalize ( NormalizationForm . FormKD ) . Trim ( ) ;
				string [ ] args = requestData . Split ( ' ' , StringSplitOptions . RemoveEmptyEntries ) ;

				TUser           user = UserProvider . GetUser ( callbackQuery . From . Id ) ;
				Session <TUser> currentSession ;
				object          tag = null ;

				if ( user is null )
				{
					if ( callbackQuery . Message . Chat . Type == ChatType . Private )
					{
						currentSession = SessionProvider . GetSession ( callbackQuery . Message . From . Id ) ;
						currentSession . PrivateChatId = callbackQuery . Message . Chat . Id ;
					}
					else
					{
						return ;
					}
				}
				else
				{
					currentSession = SessionProvider . GetSession ( user ) ;
					if ( callbackQuery . Message . Chat . Type == ChatType . Private )
					{
						currentSession . PrivateChatId = callbackQuery . Message . Chat . Id ;
					}
				}

				currentSession . BotClient = BotClient ;

				ICommand <TUser> routeTarget = currentSession . RouteBind
												?? CommandProvider . GetCommand (
												args . First ( ) . TrimEndPattern ( "Command" ) ,
												currentSession ) ;

				if ( routeTarget is null )
				{
					Logger . LogWarning ( $"CallbackQuery {e . CallbackQuery} can not be routed." ) ;

					//Wrong Callback?
				}
				else
				{
					if ( ! PermissionProvider . IsAllowedToInvoke ( user , routeTarget . PermissionGroup ) )
					{
						tag         = routeTarget ;
						routeTarget = PermissionDeniedCommand <TUser> . Current ;
					}

					TaskDispatcher . Dispatch (
												new OnetimeTask (
																( )
																	=> routeTarget . Process (
																	callbackQuery ,
																	args ,
																	currentSession ,
																	tag ) ,
																routeTarget . Timeout ) ) ;
				}
			}
			catch ( Exception exception )
			{
				Console . WriteLine ( exception ) ;
			}
		}

		public void Stop ( )
		{
			BotClient . StopReceiving ( ) ;
			TaskDispatcher . Stop ( ) ;
		}

	}

}

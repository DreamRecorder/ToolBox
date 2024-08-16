using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DreamRecorder.ToolBox.General;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DreamRecorder.ToolBox.TelegramBot;

//Todo: Test
public class TelegramBot <TUser> : IStartStop where TUser : IUser
{

	public ITelegramBotClient BotClient { get; private set; }

	public string BotToken { get; set; }

	public ICommandProvider <TUser> CommandProvider { get; private set; }

	public HttpClient HttpClient { get; set; }

	protected ILogger Logger { get; }

	public IUserPermissionProvider <TUser> PermissionProvider { get; private set; }

	private CancellationTokenSource ReceivingCancellationSource { get; } = new CancellationTokenSource ( );

	public ISessionProvider <TUser> SessionProvider { get; private set; }

	public ITaskDispatcher TaskDispatcher { get; set; }

	public ITelegramIdUserProvider <TUser> UserProvider { get; private set; }

	public bool IsRunning { get; private set; }

	public void Start ( )
	{
		lock ( this )
		{
			if ( IsRunning )
			{
				return;
			}

			IServiceProvider provider = StaticServiceProvider.Provider;

			SessionProvider    = provider.GetService <ISessionProvider <TUser>> ( );
			CommandProvider    = provider.GetService <ICommandProvider <TUser>> ( );
			UserProvider       = provider.GetService <ITelegramIdUserProvider <TUser>> ( );
			PermissionProvider = provider.GetService <IUserPermissionProvider <TUser>> ( );

			TaskDispatcher = provider.GetService <ITaskDispatcher> ( );

			TaskDispatcher.Start ( );

			BotClient = new TelegramBotClient ( BotToken , HttpClient );

			Logger.LogInformation ( "Connecting..." );

			User me = BotClient.GetMeAsync ( ).Result;
			Logger.LogInformation ( "Use Bot {0}" , me.Username );
			Console.Title = me.Username;

			BotClient.StartReceiving (
									  HandleUpdateAsync ,
									  HandleErrorAsync ,
									  cancellationToken : ReceivingCancellationSource.Token );

			IsRunning = true;
		}
	}

	public void Stop ( )
	{
		lock ( this )
		{
			if ( ! IsRunning )
			{
				return;
			}

			ReceivingCancellationSource.Cancel ( );
			TaskDispatcher.Stop ( );
			IsRunning = false;
		}
	}


	private Task HandleErrorAsync (
		ITelegramBotClient botClient ,
		Exception          exception ,
		CancellationToken  cancellationToken )
	{
		string errorMessage;
		if ( exception is ApiRequestException apiRequestException )
		{
			errorMessage = $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}";
		}
		else
		{
			errorMessage = exception.ToString ( );
		}

		Console.WriteLine ( errorMessage );
		return Task.CompletedTask;
	}

	private async Task HandleUpdateAsync (
		ITelegramBotClient botClient ,
		Update             update ,
		CancellationToken  cancellationToken )
	{
		try
		{
			if ( update.Message is Message message )
			{
				TUser           user = UserProvider.GetUser ( message.From.Id );
				Session <TUser> currentSession;
				object          tag = null;

				if ( user is null )
				{
					if ( message.Chat.Type == ChatType.Private )
					{
						currentSession               = SessionProvider.GetSession ( message.From.Id );
						currentSession.PrivateChatId = message.Chat.Id;
					}
					else
					{
						return;
					}
				}
				else
				{
					currentSession = SessionProvider.GetSession ( user );
					if ( message.Chat.Type == ChatType.Private )
					{
						currentSession.PrivateChatId = message.Chat.Id;
					}
				}

				currentSession.BotClient = BotClient;

				ICommand <TUser> routeTarget      = currentSession.RouteBind;
				string [ ]       args             = default;
				bool             isExactlyMatched = false;

				string text = message.Text?.Normalize ( NormalizationForm.FormKD )?.Trim ( );

				if ( routeTarget is null )
				{
					if ( string.IsNullOrWhiteSpace ( text ) )
					{
						return;
					}

					if ( text.First ( ) == '/' )
					{
						text = text.TrimStart ( '/' );

						args = text.Split ( ' ' , StringSplitOptions.RemoveEmptyEntries );

						if ( args.Length > 0 )
						{
							string commandName = args.First ( ).GetCommandName ( );

							routeTarget = CommandProvider.GetCommand ( commandName , currentSession );

							if ( routeTarget is null )
							{
								routeTarget      = CommandProvider.GetCommandFuzzy ( commandName , currentSession );
								isExactlyMatched = false;
							}
							else
							{
								isExactlyMatched = true;
							}
						}
						else
						{
							routeTarget      = EmptyCommand <TUser>.Current;
							isExactlyMatched = false;
						}
					}
					else
					{
						//no command 
						//
						if ( message.Chat.Type == ChatType.Private )
						{
							routeTarget      = EmptyCommand <TUser>.Current;
							isExactlyMatched = false;
						}
					}
				}
				else
				{
					args = text?.Split ( ' ' , StringSplitOptions.RemoveEmptyEntries ) ?? new string [ ] { };

					isExactlyMatched = true;
				}

				if ( ! ( routeTarget is null ) )
				{
					if ( ! PermissionProvider.IsAllowedToInvoke ( user , routeTarget.PermissionGroup ) )
					{
						tag         = routeTarget;
						routeTarget = PermissionDeniedCommand <TUser>.Current;
					}

					TaskDispatcher.Dispatch (
											 new OnetimeTask (
															  ( ) => routeTarget.Process (
															   message ,
															   args ?? new string [ ] { } ,
															   currentSession ,
															   isExactlyMatched ,
															   tag ) ,
															  routeTarget.Timeout ) );
				}
			}

			if ( update.InlineQuery is InlineQuery inlineQuery )
			{
				string req = inlineQuery.Query;
			}

			if ( update.CallbackQuery is CallbackQuery callbackQuery )
			{
				string requestData = callbackQuery.Data;
				if ( string.IsNullOrWhiteSpace ( requestData ) )
				{
					return;
				}

				requestData = requestData.Normalize ( NormalizationForm.FormKD ).Trim ( );
				string [ ] args = requestData.Split ( ' ' , StringSplitOptions.RemoveEmptyEntries );

				TUser           user = UserProvider.GetUser ( callbackQuery.From.Id );
				Session <TUser> currentSession;
				object          tag = null;

				if ( user is null )
				{
					if ( callbackQuery.Message.Chat.Type == ChatType.Private )
					{
						currentSession               = SessionProvider.GetSession ( callbackQuery.Message.From.Id );
						currentSession.PrivateChatId = callbackQuery.Message.Chat.Id;
					}
					else
					{
						return;
					}
				}
				else
				{
					currentSession = SessionProvider.GetSession ( user );
					if ( callbackQuery.Message.Chat.Type == ChatType.Private )
					{
						currentSession.PrivateChatId = callbackQuery.Message.Chat.Id;
					}
				}

				currentSession.BotClient = BotClient;

				ICommand <TUser> routeTarget = currentSession.RouteBind
											   ?? CommandProvider.GetCommand (
																			  args.First ( ).
																				  TrimEndPattern ( "Command" ) ,
																			  currentSession );

				if ( routeTarget is null )
				{
					Logger.LogWarning ( $"CallbackQuery {callbackQuery} can not be routed." );

					//Wrong Callback?
				}
				else
				{
					if ( ! PermissionProvider.IsAllowedToInvoke ( user , routeTarget.PermissionGroup ) )
					{
						tag         = routeTarget;
						routeTarget = PermissionDeniedCommand <TUser>.Current;
					}

					TaskDispatcher.Dispatch (
											 new OnetimeTask (
															  ( ) => routeTarget.Process (
															   callbackQuery ,
															   args ,
															   currentSession ,
															   tag ) ,
															  routeTarget.Timeout ) );
				}
			}
		}
		catch ( Exception exception )
		{
			Console.WriteLine ( exception );
		}
	}

}

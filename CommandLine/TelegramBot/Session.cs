using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;

using JetBrains.Annotations;

using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace DreamRecorder.ToolBox.TelegramBot;

public class Session <TUser> where TUser : IUser
{

	public ITelegramBotClient BotClient { get; set; }

	public DateTime LastAccessTime { get; set; }

	[CanBeNull]
	public ChatId PrivateChatId { get; set; }

	public Dictionary <string , object> Properties { get; set; } = new Dictionary <string , object> ( );

	[CanBeNull]
	public ICommand <TUser> RouteBind { get; set; }

	public TimeSpan TimeToLive { get; set; }

	[CanBeNull]
	public TUser User { get; set; }

	[SuppressMessage ( "ReSharper" , "ArgumentsStyleOther" )]
	public void ReplyText (
		[CanBeNull]                     Message message ,
		[JetBrains.Annotations.NotNull] string  text ,
		ParseMode                               parseMode             = ParseMode.MarkdownV2 ,
		bool                                    disableWebPagePreview = false ,
		bool                                    disableNotification   = false ,
		ReplyMarkup                            replyMarkup           = null ,
		CancellationToken                       cancellationToken     = default )
	{
		BotClient.SendMessage (
							   PrivateChatId ,
							   text ,
							   parseMode ,
							   replyParameters : new ReplyParameters { ChatId = message?.MessageId ?? default , } ,
							   linkPreviewOptions : new LinkPreviewOptions { IsDisabled = disableWebPagePreview , } ,
							   disableNotification : disableNotification ,
							   replyMarkup : replyMarkup ,
							   cancellationToken : cancellationToken ).
				  Wait ( cancellationToken );
	}

}

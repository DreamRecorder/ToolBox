using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Linq ;

using Telegram . Bot . Types ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public class EmptyCommand<TUser> : TelegramCommand<TUser> where TUser : IUser
	{

		public override TimeSpan Timeout => TimeSpan.MaxValue;

		public override CommandPermissionGroup PermissionGroup => null;

		public static EmptyCommand<TUser> Current { get; private set; }

		public override string HelpInformation => string.Empty;

		public EmptyCommand() => Current = this;

		public override bool Process(
			Message        message,
			string[]       args,
			Session<TUser> session,
			bool           isExactlyMatched,
			object         tag = null)
		{
			if (isExactlyMatched)
			{
				session.ReplyText(message, "This command does nothing.");
			}
			else
			{
				session.ReplyText(message, "This message can't be routed to a proper command.");
			}

			return true;
		}

		public override void Process(
			CallbackQuery  callbackQuery,
			string[]       args,
			Session<TUser> session,
			object         tag = null)
		{
		}

		public override bool CanBeRouteTarget(Session<TUser> session) => false;

	}

}
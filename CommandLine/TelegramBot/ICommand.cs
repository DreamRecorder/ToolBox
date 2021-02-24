using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Linq ;

using JetBrains . Annotations ;

using Telegram . Bot . Types ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public interface ICommand<TUser> where TUser : IUser
	{

		[NotNull]
		string Name { get; }

		string DisplayName { get; }

		string Introduction { get; }

		string HelpInformation { get; }

		TimeSpan Timeout { get; }

		[CanBeNull]
		CommandPermissionGroup PermissionGroup { get; }

		bool Process(
			[NotNull]              Message        message,
			[NotNull][ItemNotNull] string[]       args,
			[NotNull]              Session<TUser> session,
			bool                                  isExactlyMatched,
			[CanBeNull] object                    tag);

		void Process(
			[NotNull]              CallbackQuery  callbackQuery,
			[NotNull][ItemNotNull] string[]       args,
			[NotNull]              Session<TUser> session,
			[CanBeNull]            object         tag);

		bool CanBeRouteTarget(Session<TUser> session);

	}

}
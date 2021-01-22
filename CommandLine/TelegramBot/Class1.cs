using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DreamRecorder.ToolBox.CommandLine;

using JetBrains.Annotations;

using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace DreamRecorder.ToolBox.TelegramBot
{
	public interface IUser : IEquatable<IUser>
	{

		public abstract Guid Guid { get; }

		public T GetProperty <T> ( string name ) ;

		public void SetProperty <T> ( string name , T value ) ;



	}


	public interface ISessionProvider<TUser> where TUser : IUser
	{

		Session<TUser> GetSession(TUser user);

		Session<TUser> GetSession(int telegramId);

	}

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
			[NotNull] Message message,
			[NotNull][ItemNotNull] string[] args,
			[NotNull] Session<TUser> session,
			bool isExactlyMatched,
			[CanBeNull] object tag);

		void Process(
			[NotNull] CallbackQuery callbackQuery,
			[NotNull][ItemNotNull] string[] args,
			[NotNull] Session<TUser> session,
			[CanBeNull] object tag);

		bool CanBeRouteTarget(Session<TUser> session);

	}
	public class CommandPermissionGroup : IEquatable<CommandPermissionGroup>
	{

		public string DisplayName { get; set; }

		public Guid Guid { get;}

		public CommandPermissionGroup(string displayName, Guid guid)
		{
			DisplayName = displayName;
			Guid        = guid;
		}

		public bool Equals(CommandPermissionGroup other)
		{
			if (other is null)
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return Guid.Equals(other.Guid);
		}

		public override bool Equals(object obj)
		{
			if (obj is null)
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != GetType())
			{
				return false;
			}

			return Equals((CommandPermissionGroup)obj);
		}

		public override int GetHashCode() => Guid.GetHashCode();

		public static bool operator ==(CommandPermissionGroup left, CommandPermissionGroup right)
			=> Equals(left, right);

		public static bool operator !=(CommandPermissionGroup left, CommandPermissionGroup right)
			=> !Equals(left, right);

	}


	public class Session<TUser> where TUser : IUser
	{

		[CanBeNull]
		public IUser User { get; set; }

		[CanBeNull]
		public ChatId PrivateChatId { get; set; }

		[CanBeNull]
		public ICommand<TUser> RouteBind { get; set; }

		public DateTime LastAccessTime { get; set; }

		public TimeSpan TimeToLive { get; set; }

		public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

		public ITelegramBotClient BotClient { get; set; }

		public void ReplyText(
			[CanBeNull] Message message,
			[NotNull] string text,
			ParseMode parseMode = ParseMode.Default,
			bool disableWebPagePreview = false,
			bool disableNotification = false,
			IReplyMarkup replyMarkup = null,
			CancellationToken cancellationToken = default)
		{
			BotClient.SendTextMessageAsync(
											PrivateChatId,
											text,
											parseMode,
											disableWebPagePreview,
											disableNotification,
											message?.MessageId ?? default,
											replyMarkup,
											cancellationToken).
					Wait(cancellationToken);
		}

	}

	public interface ICommandProvider<TUser> where TUser : IUser
	{

		[NotNull] [ItemNotNull] IEnumerable<ICommand<TUser>> GetCommands();

		[CanBeNull] ICommand<TUser> GetCommand(string name, Session<TUser> session);

		[NotNull] ICommand<TUser> GetCommandFuzzy(string name, Session<TUser> session);

	}

	public interface ITelegramIdUserProvider<TUser> where TUser : IUser
	{

		TUser GetUser(int telegramId);

	}

	public class TelegramBot<TUser> where TUser : IUser
	{

		public ITelegramBotClient BotClient { get; set; }

		public ISessionProvider<TUser> SessionProvider { get; private set; }

		public ICommandProvider<TUser> CommandProvider { get; private set; }

		public ITelegramIdUserProvider<TUser> UserProvider { get; set; }

		public IUserPermissionProvider<TUser> PermissionProvider { get; set; }

	}

	public interface IUserPermissionProvider<TUser> where TUser : IUser
	{

		bool IsAllowedToInvoke([CanBeNull] TUser user, [CanBeNull] CommandPermissionGroup commandPermissionGroup);

	}

	public abstract class TelegramBotProgramBase
		<T, TUser, TExitCode, TSetting, TSettingCategory> : ProgramBase<T, TExitCode, TSetting, TSettingCategory>
		where T : TelegramBotProgramBase<T, TUser, TExitCode, TSetting, TSettingCategory>
		where TExitCode : ProgramExitCode<TExitCode>, new()
		where TSetting : SettingBase<TSetting, TSettingCategory>, new()
		where TSettingCategory : Enum, IConvertible
	where TUser : IUser
	{

		public WebProxy webProxy { get; set; }


		public TelegramBot<TUser> Bot { get; set; }
	}

}

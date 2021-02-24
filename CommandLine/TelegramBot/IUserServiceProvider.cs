using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Linq ;
using System . Threading . Tasks ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public interface IUserServiceProvider<TUser> where TUser : IUser
	{

		Task<TUser> GetUserAsync(int telegramUserId);

		Task<bool> CheckUserAsync(Guid user);

		Task<TUser> BindUserAsync(int telegramUserId, TUser user);

		Task<TUser> UnbindUserAsync(int telegramUserId, TUser user);

		Task<TUser> CreateUserAsync();

		Task<bool> CheckCommandPermissionGroupAsync(TUser user, CommandPermissionGroup commandPermissionGroup);

		Task<TUser> BindCommandPermissionGroupAsync(TUser user, CommandPermissionGroup commandPermissionGroup);

		Task<Guid> GetContinuationCodeAsync(TUser user);

		TUser GetUser(int telegramUserId);

		bool CheckUser(Guid user);

		TUser BindUser(int telegramUserId, TUser user);

		TUser CreateUser();

		bool CheckCommandPermissionGroup(TUser user, CommandPermissionGroup commandPermissionGroup);

		TUser BindCommandPermissionGroup(TUser user, CommandPermissionGroup commandPermissionGroup);

		Guid GetContinuationCode(TUser user);

	}

}
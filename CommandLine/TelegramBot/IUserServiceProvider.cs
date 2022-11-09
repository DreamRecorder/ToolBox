using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public interface IUserServiceProvider <TUser> where TUser : IUser
	{

		TUser BindCommandPermissionGroup ( TUser user , CommandPermissionGroup commandPermissionGroup ) ;

		Task <TUser> BindCommandPermissionGroupAsync ( TUser user , CommandPermissionGroup commandPermissionGroup ) ;

		TUser BindUser ( long telegramUserId , TUser user ) ;

		Task <TUser> BindUserAsync ( int telegramUserId , TUser user ) ;

		bool CheckCommandPermissionGroup ( TUser user , CommandPermissionGroup commandPermissionGroup ) ;

		Task <bool> CheckCommandPermissionGroupAsync ( TUser user , CommandPermissionGroup commandPermissionGroup ) ;

		bool CheckUser ( Guid user ) ;

		Task <bool> CheckUserAsync ( Guid user ) ;

		TUser CreateUser ( ) ;

		Task <TUser> CreateUserAsync ( ) ;

		Guid GetContinuationCode ( TUser user ) ;

		Task <Guid> GetContinuationCodeAsync ( TUser user ) ;

		TUser GetUser ( int telegramUserId ) ;

		Task <TUser> GetUserAsync ( int telegramUserId ) ;

		Task <TUser> UnbindUserAsync ( int telegramUserId , TUser user ) ;

	}

}

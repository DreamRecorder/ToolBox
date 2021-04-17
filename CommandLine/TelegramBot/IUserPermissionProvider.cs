using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public interface IUserPermissionProvider <TUser> where TUser : IUser
	{

		bool IsAllowedToInvoke (
			[CanBeNull]
			TUser user ,
			[CanBeNull]
			CommandPermissionGroup commandPermissionGroup ) ;

	}

}

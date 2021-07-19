using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public interface ISessionProvider <TUser> where TUser : IUser
	{

		Session <TUser> GetSession ( TUser user ) ;

		Session <TUser> GetSession ( long telegramId ) ;

	}

}

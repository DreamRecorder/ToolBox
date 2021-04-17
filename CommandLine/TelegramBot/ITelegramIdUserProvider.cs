using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public interface ITelegramIdUserProvider <TUser> where TUser : IUser
	{

		TUser GetUser ( int telegramId ) ;

	}

}

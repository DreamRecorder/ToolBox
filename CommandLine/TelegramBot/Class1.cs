using System ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;
using System . Threading . Tasks ;

using DreamRecorder . ToolBox . CommandLine ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public class TelegramBot
	{

		//public ITelegramBotClient BotClient { get; set; }

		//public ISessionProvider SessionProvider { get; private set; }

		//public ICommandProvider CommandProvider { get; private set; }

		//public IUserDataProvider UserDataProvider { get; set; }

		//public ITelegramIdUserProvider UserProvider { get; set; }

		//public IUserPermissionProvider PermissionProvider { get; set; }

	}

	public abstract class TelegramBotProgramBase
		<T , TExitCode , TSetting , TSettingCategory> : ProgramBase <T , TExitCode , TSetting , TSettingCategory>
		where T : TelegramBotProgramBase <T , TExitCode , TSetting , TSettingCategory>
		where TExitCode : ProgramExitCode <TExitCode> , new ( )
		where TSetting : SettingBase <TSetting , TSettingCategory> , new ( )
		where TSettingCategory : Enum , IConvertible
	{

	}

}

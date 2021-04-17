using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;

using DreamRecorder . ToolBox . CommandLine ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public abstract class TelegramBotProgramBase
		<T , TUser , TExitCode , TSetting , TSettingCategory>
		: ProgramBase <T , TExitCode , TSetting , TSettingCategory>
		where T : TelegramBotProgramBase <T , TUser , TExitCode , TSetting , TSettingCategory>
		where TExitCode : ProgramExitCode <TExitCode> , new ( )
		where TSetting : SettingBase <TSetting , TSettingCategory> , new ( )
		where TSettingCategory : Enum , IConvertible
		where TUser : IUser
	{

		public WebProxy webProxy { get ; set ; }


		public TelegramBot <TUser> Bot { get ; set ; }

	}

}

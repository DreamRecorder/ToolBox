using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . CommandLine . Example . Telegram
{

	public class ProgramSetting : SettingBase <ProgramSetting , ProgramSettingCatalog>
	{

		[SettingItem ( ( int )ProgramSettingCatalog . General , nameof ( BotToken ) , "" , true , "" )]
		public string BotToken { get ; set ; }

		[SettingItem ( ( int )ProgramSettingCatalog . General , nameof ( DatabaseConnection ) , "" , true , "" )]
		public string DatabaseConnection { get ; set ; }

		[SettingItem ( ( int )ProgramSettingCatalog . General , nameof ( HttpProxy ) , "" , true , null )]
		public string HttpProxy { get ; set ; }

	}

}

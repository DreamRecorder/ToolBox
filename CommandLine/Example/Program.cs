using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading ;

using DreamRecorder . ToolBox . CommandLine ;
using DreamRecorder . ToolBox . General ;

using Microsoft . Extensions . Logging ;

namespace Example
{

	public class ProgramExitCode : ProgramExitCode <ProgramExitCode>
	{

	}

	public enum ProgramSettingCatalog
	{

		General = 0

	}

	public class ProgramSetting : SettingBase <ProgramSetting , ProgramSettingCatalog>
	{

		[SettingItem ( ( int ) ProgramSettingCatalog . General , nameof(BotToken) , "" , true , "" )]
		public string BotToken { get ; set ; }

		[SettingItem ( ( int ) ProgramSettingCatalog . General , nameof(DatabaseConnection) , "" , true , "" )]
		public string DatabaseConnection { get ; set ; }

		[SettingItem ( ( int ) ProgramSettingCatalog . General , nameof(HttpProxy) , "" , true , null )]
		public string HttpProxy { get ; set ; }

	}

	public class Program : ProgramBase <Program , ProgramExitCode , ProgramSetting , ProgramSettingCatalog>
	{

		public override bool WaitForExit => true ;

		public override string License => "agpl" ;

		public override bool CanExit => true ;

		public override bool HandleInput => false ;

		public override bool LoadSetting => true ;

		public override bool AutoSaveSetting => true ;

		public static void Main ( string [ ] args )
		{
			StaticLoggerFactory . LoggerFactory =
				new LoggerFactory ( ) . AddConsole ( LogLevel . Information ) . AddDebug ( ) ;
			new Program ( ) . RunMain ( args ) ;
		}

		public void DoSth ( )
		{
			while ( IsRunning )
			{
				Thread . Sleep ( 100 ) ;
			}
		}

		public override void Start ( string [ ] args )
		{
			Thread thread = new Thread ( DoSth ) ;
			thread . Start ( ) ;
		}

		public override void ShowLogo ( ) { Console . WriteLine ( "Logo" ) ; }

		public override void ShowCopyright ( ) { Console . WriteLine ( "Copyright" ) ; }

		public override void OnExit ( ProgramExitCode code ) { }

	}

}

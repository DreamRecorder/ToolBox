using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . CommandLine ;
using DreamRecorder . ToolBox . General ;

using Microsoft . AspNetCore . Hosting ;
using Microsoft . Extensions . Hosting ;
using Microsoft . Extensions . Logging ;

namespace DreamRecorder . ToolBox . AspNet . Example
{

	public class Program
		: ProgramBase <Program , Program . ProgramExitCode , Program . ProgramSetting , Program . ProgramSettingCatalog>
	{

		public enum ProgramSettingCatalog
		{

		}

		public override bool CheckLicense => false ;

		public override bool WriteLicenseFile => false ;

		public override bool WaitForExit => false ;

		public override bool LoadPlugin => false ;

		public override string License => string . Empty ;

		public override bool CanExit => true ;

		public override bool HandleInput => true ;

		public override bool LoadSetting => false ;

		public override bool AutoSaveSetting => false ;

		public static void Main ( string [ ] args ) { new Program ( ) . RunMain ( args ) ; }

		public static IHostBuilder CreateHostBuilder ( string [ ] args )
			=> Host . CreateDefaultBuilder ( args ) .
					UseServiceProviderFactory ( new StaticServiceProviderFactory ( ) ) .
					ConfigureWebHostDefaults ( webBuilder => { webBuilder . UseStartup <Startup> ( ) ; } ) ;

		public override void Start ( string [ ] args ) { CreateHostBuilder ( args ) . Build ( ) . Run ( ) ; }

		public override void ConfigureLogger ( ILoggingBuilder builder ) { builder . AddDebug ( ) ; }

		public override void ShowLogo ( ) { }

		public override void ShowCopyright ( ) { }

		public override void OnExit ( ProgramExitCode code ) { }

		public class ProgramSetting : SettingBase <ProgramSetting , ProgramSettingCatalog>
		{

		}

		public class ProgramExitCode : ProgramExitCode <ProgramExitCode>
		{

		}

	}

}

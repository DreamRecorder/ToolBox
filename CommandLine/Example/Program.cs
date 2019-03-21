using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Threading ;

using DreamRecorder . ToolBox . CommandLine ;
using DreamRecorder . ToolBox . General ;

using Microsoft . Extensions . Logging ;
using Microsoft . Extensions . Logging . Console ;

namespace Example
{

	public class Program : ProgramBase <Program , ProgramExitCode , ProgramSetting , ProgramSettingCatalog>
	{

		public override bool WaitForExit => true ;

		public override string License => "AGPL" ;

		public override bool CanExit => true ;

		public override bool HandleInput => false ;

		public override bool LoadSetting => true ;

		public override bool AutoSaveSetting => true ;

		public static void Main ( string [ ] args ) { new Program ( ) . RunMain ( args ) ; }

		public void DoSth ( )
		{
			ReadOnlyDictionary <string , string> a = Emojis . EmojisList ;
			Console . WriteLine ( a ) ;

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

		public override void ConfigureLogger ( ILoggingBuilder builder )
		{
			builder . AddDebug ( ) ;
			builder . AddFilter <ConsoleLoggerProvider> ( "Default" , LogLevel . Information ) . AddConsole ( ) ;
		}

		public override void ShowLogo ( ) { Console . WriteLine ( "Logo" ) ; }

		public override void ShowCopyright ( ) { Console . WriteLine ( "Copyright" ) ; }

		public override void OnExit ( ProgramExitCode code ) { }

	}

}

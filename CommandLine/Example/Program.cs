using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Threading ;

using DreamRecorder . ToolBox . CommandLine ;
using DreamRecorder . ToolBox . General ;

using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . Logging ;
using Microsoft . Extensions . Logging . Console ;

namespace Example
{

	public class Program
		: ProgramBase <Program , ProgramExitCode , ProgramSetting , ProgramSettingCatalog>
	{

		public override bool WaitForExit => true ;

		public override string License => "AGPL" ;

		public override bool CanExit => true ;

		public override bool HandleInput => true ;

		public override bool LoadSetting => true ;

		public override bool AutoSaveSetting => true ;

		public static void Main ( string [ ] args ) { new Program ( ) . RunMain ( args ) ; }

		public void DoSth ( )
		{
			ISettingProvider settingProvider =
				StaticServiceProvider . Provider . GetService <ISettingProvider> ( ) ;

			Console . WriteLine (
								settingProvider . GetValue <string> (
																	nameof ( ProgramSetting .
																				DatabaseConnection
																	) ) ) ;

			ReadOnlyDictionary <string , string> a = Emojis . EmojisList ;

			foreach ( KeyValuePair <string , string> pair in a )
			{
				Console . WriteLine ( $"{pair . Key}	{pair . Value}" ) ;
			}
		}

		public override void Start ( string [ ] args )
		{
			Console . ReadLine ( ) ;
			Thread thread = new Thread ( DoSth ) ;
			thread . Start ( ) ;
		}

		public override void ConfigureLogger ( ILoggingBuilder builder )
		{
			builder . AddDebug ( ) ;
			builder . AddFilter <ConsoleLoggerProvider> ( "Default" , LogLevel . Information ) .
					AddConsole ( ) ;
		}

		public override void ShowLogo ( ) { Console . WriteLine ( "Logo" ) ; }

		public override void ShowCopyright ( ) { Console . WriteLine ( "Copyright" ) ; }

		public override void OnExit ( ProgramExitCode code ) { }

	}

}

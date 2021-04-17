using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;
using System . Threading ;

using DreamRecorder . ToolBox . General ;

using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . Logging ;
using Microsoft . Extensions . Logging . Console ;

namespace DreamRecorder . ToolBox . CommandLine . Example
{

	public class Program : ProgramBase <Program , ProgramExitCode , ProgramSetting , ProgramSettingCatalog>
	{

		public override bool WaitForExit => true ;

		public override string License => "AGPL" ;

		public override bool CanExit => true ;

		public override bool HandleInput => false ;

		public override bool LoadSetting => true ;

		public override bool AutoSaveSetting => true ;

		private ITaskDispatcher Dispatcher { get ; set ; }

		public override bool LoadPlugin => true ;

		public static void Main ( string [ ] args ) { new Program ( ) . RunMain ( args ) ; }

		public void DoSth ( )
		{
			Console . ReadLine ( ) ;

			ISettingProvider settingProvider = StaticServiceProvider . Provider . GetService <ISettingProvider> ( ) ;

			Console . WriteLine (
								settingProvider . GetValue <string> (
																	nameof ( ProgramSetting . DatabaseConnection ) ) ) ;

			ReadOnlyDictionary <string , string> a = Emojis . EmojisList ;

			foreach ( KeyValuePair <string , string> pair in a )
			{
				Console . WriteLine ( $"{pair . Key}	{pair . Value}" ) ;
			}
		}


		public override void Start ( string [ ] args )
		{
			PerformanceCounterProvider provider = new PerformanceCounterProvider ( ) ;

			provider . GetPerformanceCounter ( "a" ) ;

			(string SourceCodeVersion , string Builder , DateTimeOffset ? BuildTime) ? a =
				typeof ( ProgramBase <Program , ProgramExitCode , ProgramSetting , ProgramSettingCatalog> ) . Assembly .
					GetInformationalVersion ( ) ;

			Thread thread = new Thread ( DoSth ) ;
			thread . Start ( ) ;

			Dispatcher = StaticServiceProvider . Provider . GetService <ITaskDispatcher> ( ) ;

			Dispatcher . Start ( ) ;

			OnetimeTask task1 = new OnetimeTask ( PrintTime1 , default ) ;
			Dispatcher . Dispatch ( task1 ) ;

			IntervalTask task2 = new IntervalTask (
													PrintTime2 ,
													TimeSpan . FromSeconds ( 1 ) ,
													priority : TaskPriority . Background ) ;

			Dispatcher . Dispatch ( task2 ) ;
		}

		public void PrintTime1 ( )
		{
			Console . WriteLine ( $"1:{DateTimeOffset . Now}" ) ;
			Thread . Sleep ( 1000 ) ;
		}

		public void PrintTime2 ( ) { Console . WriteLine ( $"2:{DateTimeOffset . Now}" ) ; }

		public override void ConfigureLogger ( ILoggingBuilder builder )
		{
			builder . AddDebug ( ) ;
			builder . AddFilter <ConsoleLoggerProvider> ( "Default" , LogLevel . Information ) . AddConsole ( ) ;
		}

		public override void ShowLogo ( ) { Console . WriteLine ( "Logo" ) ; }

		public override void ShowCopyright ( ) { Console . WriteLine ( "Copyright" ) ; }

		public override void OnExit ( ProgramExitCode code ) { Dispatcher ? . Stop ( ) ; }

	}

}

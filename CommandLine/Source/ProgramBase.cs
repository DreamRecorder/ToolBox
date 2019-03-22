using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . IO ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using JetBrains . Annotations ;

using Microsoft . Extensions . CommandLineUtils ;
using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . Logging ;

namespace DreamRecorder . ToolBox . CommandLine
{

	[PublicAPI]
	public abstract class ProgramBase <T , TExitCode , TSetting , TSettingCategory>
		where T : ProgramBase <T , TExitCode , TSetting , TSettingCategory>
		where TExitCode : ProgramExitCode <TExitCode> , new ( )
		where TSetting : SettingBase <TSetting , TSettingCategory> , new ( )
		where TSettingCategory : Enum , IConvertible
	{

		protected ILogger Logger { get ; private set ; }

		public static T Current { get ; set ; }

		public virtual bool IsRunning { get ; set ; }

		public bool IsVerbose { get ; set ; }

		public abstract bool WaitForExit { get ; }

		public abstract string License { get ; }

		public bool IsDebug { get ; private set ; }

		public TSetting Setting { get ; set ; }

		public abstract bool CanExit { get ; }

		public abstract bool HandleInput { get ; }

		public abstract bool LoadSetting { get ; }

		public abstract bool AutoSaveSetting { get ; }

		/// <summary>
		///     This override should create a foreground thread before return or program will exit directly
		/// </summary>
		/// <param name="args"></param>
		public abstract void Start ( string [ ] args ) ;

		public virtual void RegisterArgument ( CommandLineApplication application ) { }

		public abstract void ConfigureLogger ( ILoggingBuilder builder ) ;

		public void SaveSettingFile ( )
		{
			string       config      = Setting ? . Save ( ) ;
			FileStream   settingFile = File . OpenWrite ( FileNameConst . SettingFile ) ;
			StreamWriter writer      = new StreamWriter ( settingFile ) ;
			writer . Write ( config ) ;
			writer . Dispose ( ) ;
		}

		public void Exit ( TExitCode exitCode )
		{
			if ( exitCode == ProgramExitCode <TExitCode> . Success )
			{
				if ( AutoSaveSetting )
				{
					SaveSettingFile ( ) ;
				}
			}

			ShowExit ( ) ;

			IsRunning = false ;

			OnExit ( exitCode ) ;

			if ( ! WaitForExit )
			{
				Environment . Exit ( exitCode . Code ) ;
			}
		}

		public abstract void ShowLogo ( ) ;

		public abstract void ShowCopyright ( ) ;

		private void ShowExit ( )
		{
			Logger . LogInformation ( "Exiting" ) ;
			Console . WriteLine ( ) ;
			Console . WriteLine ( @"Exiting..." ) ;
			Console . WriteLine ( ) ;
		}

		public abstract void OnExit ( TExitCode code ) ;

		/// <summary>
		/// </summary>
		public virtual void GenerateLicenseFile ( )
		{
			Logger . LogInformation ( "Generating License File." ) ;
			FileStream licenseFile = File . Open ( FileNameConst . LicenseFile , FileMode . Create ) ;

			using ( StreamWriter writer = new StreamWriter ( licenseFile ) )
			{
				writer . WriteLine ( License ) ;
				writer . WriteLine ( ) ;
				writer . WriteLine ( "To accept this license, you should write \"I accept this License.\" at the end of this file." ) ;
			}
		}

		public virtual bool CheckLicenseFile ( )
		{
			if ( ! File . Exists ( FileNameConst . LicenseFile ) )
			{
				Logger . LogInformation ( "License file not found." ) ;
				GenerateLicenseFile ( ) ;

				return false ;
			}

			FileStream licenseFile = File . OpenRead ( FileNameConst . LicenseFile ) ;
			string     licenseFileContent ;

			using ( StreamReader reader = new StreamReader ( licenseFile ) )
			{
				Logger . LogInformation ( "License file found, reading it." ) ;
				licenseFileContent = reader . ReadToEnd ( ) . TrimEnd ( ) ;
			}

			if ( ! licenseFileContent . EndsWith ( "I accept this License." ) )
			{
				Logger . LogInformation ( "License check error." ) ;

				Console . WriteLine ( @"You should read the License.txt and accept it before use this program." ) ;

				return false ;
			}

			Logger . LogInformation ( "License check pass." ) ;

			return true ;
		}

		/// <summary>
		///     Call this after Create StaticLoggerFactory
		/// </summary>
		/// <param name="args"></param>
		public virtual void RunMain ( string [ ] args )
		{
			Current = ( T ) this ;

			CommandLineApplication commandLineApplication = new CommandLineApplication ( ) ;

			commandLineApplication . HelpOption ( "-?|-h|--help" ) ;

			CommandOption noLogoOption =
				commandLineApplication . Option ( @"-noLogo|--noLogo" , "Show no logo" , CommandOptionType . NoValue ) ;

			CommandOption acceptLicenseOption =
				commandLineApplication . Option ( @"-acceptLicense|--acceptLicense" ,
												"Accept License" ,
												CommandOptionType . NoValue ) ;

			CommandOption debugOption =
				commandLineApplication . Option ( @"-debug|--debug" ,
												"Launch in Debug mode" ,
												CommandOptionType . NoValue ) ;

			CommandOption verboseOption =
				commandLineApplication . Option ( "-v|--verbose" , "Verbose Log" , CommandOptionType . NoValue ) ;

			RegisterArgument ( commandLineApplication ) ;

			IsRunning = true ;

			int Execution ( )
			{
				IsDebug =
					#if DEBUG

					// ReSharper disable once ConditionIsAlwaysTrueOrFalse
					true
					||
					#endif
					debugOption . HasValue ( )
					|| Debugger . IsAttached ;


				IsVerbose = verboseOption . HasValue ( ) ;

				#region CreateLogger

				StaticServiceProvider . ServiceCollection . AddLogging ( ConfigureLogger ) ;

				StaticServiceProvider . Update ( ) ;

				Logger = StaticServiceProvider . Provider . GetService <ILoggerFactory> ( ) . CreateLogger <T> ( ) ;

				Logger . LogInformation ( "Start with argument: {0}" , string . Join ( " " , args ) ) ;

				#endregion


				if ( ! noLogoOption . HasValue ( ) )
				{
					ShowLogo ( ) ;
					ShowCopyright ( ) ;
				}

				#region Check License

				if ( IsDebug )
				{
					Logger . LogInformation ( "Debug version, skip license check and you are assumed to accept license." ) ;
				}
				else
				{
					if ( ! acceptLicenseOption . HasValue ( ) )
					{
						if ( ! CheckLicenseFile ( ) )
						{
							Logger . LogInformation ( "License check failed." ) ;
							Exit ( ProgramExitCode <TExitCode> . LicenseNotAccepted ) ;
						}
						else
						{
							Logger . LogInformation ( "License file check passed." ) ;
						}
					}
					else
					{
						Logger . LogInformation ( "License Accepted by command line argument." ) ;
					}
				}

				#endregion

				#region StartUp

				AppDomainExtensions . PrepareCurrentDomain ( ) ;

				#endregion

				#region Load Setting

				if ( LoadSetting )
				{
					Logger . LogInformation ( "Loading setting file." ) ;

					if ( File . Exists ( FileNameConst . SettingFile ) )
					{
						Logger . LogInformation ( "Setting file exists, Reading." ) ;

						try
						{
							using ( FileStream stream = File . OpenRead ( FileNameConst . SettingFile ) )
							{
								Setting = SettingBase <TSetting , TSettingCategory> . Load ( stream ) ;
							}

							Logger . LogInformation ( "Setting file loaded." ) ;
						}
						catch ( Exception )
						{
							Logger . LogInformation ( "Setting file error, will use default value." ) ;
							Setting = SettingBase <TSetting , TSettingCategory> . GenerateNew ( ) ;
						}
					}
					else
					{
						Logger . LogInformation ( "Setting file doesn't exists, generating new." ) ;
						Setting = SettingBase <TSetting , TSettingCategory> . GenerateNew ( ) ;
						SaveSettingFile ( ) ;
					}
				}

				#endregion

				Start ( args ) ;

				return 0 ;
			}

			commandLineApplication . OnExecute ( Execution ) ;

			commandLineApplication . Execute ( args ) ;

			if ( ! HandleInput )
			{
				while ( IsRunning )
				{
					if ( ( Console . ReadLine ( ) ? . Trim ( ) . ToLower ( ) == "exit" ) && CanExit )
					{
						Exit ( ProgramExitCode <TExitCode> . Success ) ;
					}
				}
			}
		}

	}

}

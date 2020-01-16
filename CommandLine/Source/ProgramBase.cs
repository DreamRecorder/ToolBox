using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . IO ;
using System . Linq ;
using System . Threading ;

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

		public static T Current { get ;private set ; }

		public virtual bool IsRunning { get ; set ; }

		public bool IsVerbose { get ; set ; }

		public virtual bool WaitForExit { get ; }

		public abstract string License { get ; }

		public bool IsDebug { get ; private set ; }

		public TSetting Setting { get ; set ; }

		/// <summary>
		///     If Program do not handle Input
		/// </summary>
		public abstract bool CanExit { get ; }

		/// <summary>
		/// </summary>
		public abstract bool HandleInput { get ; }

		public abstract bool LoadSetting { get ; }

		public abstract bool AutoSaveSetting { get ; }

		public virtual string SettingFilePathOverride => null ;

		public virtual string AcceptLicenseDeclare => "I accept this License." ;

		public virtual string AcceptLicenseGuide
			=> $"To accept this license, you should write \"{AcceptLicenseDeclare}\" at the end of this file." ;

		public virtual bool CheckLicense => true ;

		public virtual bool MainThreadWait { get ; }

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
			FileStream   settingFile = File . OpenWrite ( SettingFilePathOverride ?? FileNameConst . SettingFileName ) ;
			StreamWriter writer      = new StreamWriter ( settingFile ) ;
			writer . Write ( config ) ;
			writer . Dispose ( ) ;
		}

		public virtual bool OnStartupExceptions ( Exception e ) => false ;

		public virtual bool OnUnhandledExceptions ( Exception e ) => false ;

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
			else
			{
				Environment.ExitCode = exitCode.Code;
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
			FileStream licenseFile = File . Open ( FileNameConst . LicenseFileName , FileMode . Create ) ;

			using ( StreamWriter writer = new StreamWriter ( licenseFile ) )
			{
				writer . WriteLine ( License ) ;
				writer . WriteLine ( ) ;
				writer . WriteLine ( AcceptLicenseGuide ) ;
			}
		}

		public virtual bool CheckLicenseFile ( )
		{
			if ( ! File . Exists ( FileNameConst . LicenseFileName ) )
			{
				Logger . LogInformation ( "License file not found." ) ;
				GenerateLicenseFile ( ) ;

				return false ;
			}

			FileStream licenseFile = File . OpenRead ( FileNameConst . LicenseFileName ) ;
			string     licenseFileContent ;

			using ( StreamReader reader = new StreamReader ( licenseFile ) )
			{
				Logger . LogInformation ( "License file found, reading it." ) ;
				licenseFileContent = reader . ReadToEnd ( ) . Trim ( ) ;
			}

			if ( licenseFileContent . StartsWith ( License ) )
			{
				licenseFileContent = licenseFileContent . TrimStartPattern ( License ) ;

				if ( ! licenseFileContent . EndsWith ( AcceptLicenseDeclare ) )
				{
					Logger . LogInformation ( "License check failed." ) ;

					licenseFileContent = licenseFileContent . TrimEndPattern ( AcceptLicenseGuide ) ;

					if ( string . IsNullOrWhiteSpace ( licenseFileContent ) )
					{
						Console . WriteLine (
											@"You should read the License.txt and accept it before use this program." ) ;
						return false ;
					}
				}
				else
				{
					licenseFileContent = licenseFileContent . TrimEndPattern ( AcceptLicenseDeclare ) ;

					licenseFileContent = licenseFileContent . Trim ( ) ;

					licenseFileContent = licenseFileContent . TrimEndPattern ( AcceptLicenseGuide ) ;

					if ( string . IsNullOrWhiteSpace ( licenseFileContent ) )
					{
						Logger . LogInformation ( "License check pass." ) ;
						return true ;
					}
				}
			}

			Console . WriteLine ( @"License File is now broken." ) ;

			GenerateLicenseFile ( ) ;

			return false ;
		}

		public virtual void BeforePrepare ( ) { }

		public virtual void AfterPrepare ( ) { }

		/// <summary>
		///     Call this after Create StaticLoggerFactory
		/// </summary>
		/// <param name="args"></param>
		public virtual void RunMain ( string [ ] args )
		{
			Current = ( T ) this ;

			CommandLineApplication commandLineApplication = new CommandLineApplication ( ) ;

			commandLineApplication . HelpOption ( "-?|-h|--help|-help" ) ;

			CommandOption noLogoOption = commandLineApplication . Option (
																		@"-noLogo|--noLogo" ,
																		"Show no logo" ,
																		CommandOptionType . NoValue ) ;

			CommandOption acceptLicenseOption = commandLineApplication . Option (
																				@"-acceptLicense|--acceptLicense" ,
																				"Accept License" ,
																				CommandOptionType . NoValue ) ;

			CommandOption debugOption = commandLineApplication . Option (
																		@"-debug|--debug" ,
																		"Launch in Debug mode" ,
																		CommandOptionType . NoValue ) ;

			CommandOption verboseOption = commandLineApplication . Option (
																			"-v|--verbose|-verbose" ,
																			"Verbose Log" ,
																			CommandOptionType . NoValue ) ;

			RegisterArgument ( commandLineApplication ) ;

			int Execution ( )
			{
				IsDebug = debugOption . HasValue ( ) || Debugger . IsAttached ;

#if DEBUG
				IsDebug = true ;

#endif

				IsVerbose = verboseOption . HasValue ( ) ;

				#region Create Logger

				lock ( StaticServiceProvider . ServiceCollection )
				{
					StaticServiceProvider . ServiceCollection . AddLogging ( ConfigureLogger ) ;

					StaticServiceProvider . Update ( ) ;
				}

				Logger = StaticServiceProvider . Provider . GetService <ILoggerFactory> ( ) . CreateLogger <T> ( ) ;

				Logger . LogDebug ( "Logger has been configured." ) ;

				#endregion

				Logger . LogInformation ( "Start with argument: {0}" , string . Join ( " " , args ) ) ;

				#region Check Debug

				if ( IsDebug )
				{
					Logger . LogWarning ( "This program is being debugging." ) ;
				}

				#endregion

				if ( ! noLogoOption . HasValue ( ) )
				{
					ShowLogo ( ) ;
					ShowCopyright ( ) ;
				}

				#region Check License

				if ( CheckLicense )
				{
					if ( IsDebug )
					{
						Logger . LogInformation (
												"Debug version, skip license check and you are assumed to accept license." ) ;
					}
					else
					{
						if ( ! acceptLicenseOption . HasValue ( ) )
						{
							if ( ! CheckLicenseFile ( ) )
							{
								Logger . LogInformation ( "License check failed." ) ;
								Logger . LogCritical (
													string . Format (
																	"You should READ and ACCEPT {0} first." ,
																	FileNameConst . LicenseFileName ) ) ;

								Exit ( ProgramExitCode <TExitCode> . LicenseNotAccepted ) ;
								return ProgramExitCode <TExitCode> . LicenseNotAccepted ;
							}

							Logger . LogInformation ( "License file check passed." ) ;
						}
						else
						{
							Logger . LogInformation ( "License Accepted by command line argument." ) ;
						}
					}
				}

				#endregion

				#region Load Setting

				BeforeLoadSetting ( ) ;

				if ( LoadSetting )
				{
					Logger . LogInformation ( "Loading setting file." ) ;

					if ( File . Exists ( SettingFilePathOverride ?? FileNameConst . SettingFileName ) )
					{
						Logger . LogInformation ( "Setting file exists, Reading." ) ;

						try
						{
							using ( FileStream stream =
								File . OpenRead ( SettingFilePathOverride ?? FileNameConst . SettingFileName ) )
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

					StaticServiceProvider . ServiceCollection . AddSingleton <ISettingProvider> ( Setting ) ;
				}

				AfterLoadSetting ( ) ;

				#endregion

				#region StartUp

				BeforePrepare ( ) ;

				lock ( StaticServiceProvider . ServiceCollection )
				{
					AppDomainExtensions . PrepareCurrentDomain ( ) ;

					StaticServiceProvider . Update ( ) ;
				}

				AfterPrepare ( ) ;

				#endregion

				try
				{
					Start ( args ) ;
				}
				catch ( Exception e )
				{
					if ( ! OnUnhandledExceptions ( e ) )
					{
						Exit ( ProgramExitCode <TExitCode> . ExceptionUnhandled ) ;
						return ProgramExitCode <TExitCode> . ExceptionUnhandled ;
					}
				}

				if ( ! HandleInput )
				{
					while ( IsRunning )
					{
						if ( Console . ReadLine ( ) ? . Trim ( ) . ToLower ( ) == "exit" && CanExit )
						{
							Exit ( ProgramExitCode <TExitCode> . Success ) ;
						}
					}
				}

				if ( MainThreadWait )
				{
					while ( IsRunning )
					{
						Thread . Yield ( ) ;
						Thread . Sleep ( 1 ) ;
					}
				}

				return ProgramExitCode <TExitCode> . Success ;
			}

			IsRunning = true ;

			commandLineApplication . OnExecute ( Execution ) ;

			try
			{
				commandLineApplication . Execute ( args ) ;
			}
			catch ( Exception e )
			{
				if ( ! OnStartupExceptions ( e ) )
				{
					throw ;
				}
			}
		}

		protected virtual void BeforeLoadSetting ( ) { }

		protected virtual void AfterLoadSetting ( ) { }

	}

}

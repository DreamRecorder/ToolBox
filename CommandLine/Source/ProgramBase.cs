﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . IO ;
using System . Linq ;
using System . Text ;
using System . Threading ;

using DreamRecorder . ToolBox . General ;

using JetBrains . Annotations ;

using Microsoft . Extensions . CommandLineUtils ;
using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . Logging ;

namespace DreamRecorder . ToolBox . CommandLine
{

	[PublicAPI]
	public abstract class ProgramBase
	{

		public static ProgramBase Current { get ; protected set ; }

	}

	[PublicAPI]
	public abstract class ProgramBase <T , TExitCode , TSetting , TSettingCategory> : ProgramBase
		where T : ProgramBase <T , TExitCode , TSetting , TSettingCategory>
		where TExitCode : ProgramExitCode <TExitCode> , new ( )
		where TSetting : SettingBase <TSetting , TSettingCategory> , new ( )
		where TSettingCategory : Enum , IConvertible
	{

		private volatile bool _isExiting ;

		private volatile bool _isRunning ;

		public bool IsExiting { get => _isExiting ; set => _isExiting = value ; }

		protected ILogger Logger { get ; private set ; }

		public new static T Current
		{
			get => ( T ) ProgramBase . Current ;
			private set => ProgramBase . Current = value ;
		}

		public virtual bool IsRunning { get => _isRunning ; private set => _isRunning = value ; }

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

		public string SettingFilePath => SettingFilePathOverride ?? FileNameConst . SettingFilePath ;

		public string LicenseFilePath => LicenseFilePathOverride ?? FileNameConst . LicenseFilePath ;

		public string PluginDirectoryPath => PluginDirectoryPathOverride ?? FileNameConst . PluginDirectoryPath ;

		protected virtual string SettingFilePathOverride => null ;

		protected virtual string LicenseFilePathOverride => null ;

		protected virtual string PluginDirectoryPathOverride => null ;

		public virtual string AcceptLicenseDeclare => "I accept this License." ;

		public virtual string AcceptLicenseGuide
			=> $"To accept this license, you should write \"{AcceptLicenseDeclare}\" at the end of this file." ;

		public virtual bool CheckLicense => true ;

		private AutoResetEvent ExitEvent { get ; } = new AutoResetEvent ( false ) ;

		protected CommandLineApplication CommandLineApplication { get ; set ; }

		public virtual bool LoadPlugin => false ;

		public virtual string PluginSearchPattern => "*.dll" ;

		public virtual bool WriteLicenseFile => true ;

		public virtual bool ThrowOnUnexpectedArg => false ;

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
			FileStream   settingFile = File . OpenWrite ( SettingFilePath ) ;
			StreamWriter writer      = new StreamWriter ( settingFile ) ;
			writer . Write ( config ) ;
			writer . Dispose ( ) ;
		}

		public virtual bool OnStartupExceptions ( Exception e )
		{
			Logger . LogCritical ( e , "Application failed to start." ) ;
			return false ;
		}

		public virtual bool OnUnhandledExceptions ( Exception e )
		{
			Logger . LogCritical ( e , "Exception is unhandled." ) ;
			return false ;
		}

		public void Exit ( TExitCode exitCode = null )
		{
			exitCode ??= ProgramExitCode <TExitCode> . Success ;

			if ( IsRunning && ! IsExiting )
			{
				IsExiting = true ;

				ShowExit ( ) ;

				OnExit ( exitCode ) ;

				IsRunning = false ;


				if ( exitCode == ProgramExitCode <TExitCode> . Success )
				{
					if ( AutoSaveSetting )
					{
						SaveSettingFile ( ) ;
					}
				}
			}

			if ( ! WaitForExit )
			{
				Environment . Exit ( exitCode . Code ) ;
			}
			else
			{
				Environment . ExitCode = exitCode . Code ;
				ExitEvent . Set ( ) ;
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

		public virtual void RequestExit ( TExitCode programExitCode = default )
		{
			if ( CanExit )
			{
				Exit ( programExitCode ) ;
			}
			else
			{
				if ( ! HandleInput )
				{
					Console . WriteLine ( "Cannot exit at this time." ) ;
				}
			}
		}

		public abstract void OnExit ( TExitCode code ) ;

		/// <summary>
		/// </summary>
		public virtual void GenerateLicenseFile ( )
		{
			Logger . LogInformation ( "Generating License File." ) ;
			FileStream licenseFile = File . Open ( LicenseFilePath , FileMode . Create ) ;

			using ( StreamWriter writer = new StreamWriter ( licenseFile ) )
			{
				writer . WriteLine ( License ) ;
				if ( CheckLicense )
				{
					writer . WriteLine ( ) ;
					writer . WriteLine ( AcceptLicenseGuide ) ;
				}
			}
		}

		public virtual bool CheckLicenseFile ( )
		{
			if ( ! File . Exists ( LicenseFilePath ) )
			{
				Logger . LogInformation ( "License file not found." ) ;
				GenerateLicenseFile ( ) ;

				return false ;
			}

			FileStream licenseFile = File . OpenRead ( LicenseFilePath ) ;
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

		public void ShowVersion ( )
		{
			StringBuilder builder = new StringBuilder ( ) ;
			AssemblyExtensions . GetAssemblyInfo <T> ( builder ) ;

			Logger . LogInformation ( builder . ToString ( ) ) ;
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

			CommandLineApplication = new CommandLineApplication ( ThrowOnUnexpectedArg ) ;

			CommandLineApplication . HelpOption ( "-?|-h|--help|-help" ) ;

			CommandOption noLogoOption = CommandLineApplication . Option (
																		@"-noLogo|--noLogo" ,
																		"Show no logo" ,
																		CommandOptionType . NoValue ) ;

			CommandOption acceptLicenseOption = CommandLineApplication . Option (
			@"-acceptLicense|--acceptLicense" ,
			"Accept License" ,
			CommandOptionType . NoValue ) ;

			CommandOption debugOption = CommandLineApplication . Option (
																		@"-debug|--debug" ,
																		"Launch in Debug mode" ,
																		CommandOptionType . NoValue ) ;

			CommandOption verboseOption = CommandLineApplication . Option (
																			"-v|-verbose|--verbose" ,
																			"Verbose Log" ,
																			CommandOptionType . NoValue ) ;

			RegisterArgument ( CommandLineApplication ) ;

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
					Logger . LogWarning ( "This program is considered as being debugging." ) ;
				}

				#endregion

				if ( ! noLogoOption . HasValue ( ) )
				{
					ShowLogo ( ) ;
					ShowCopyright ( ) ;
				}

				ShowVersion ( ) ;

				#region Check License

				BeforeCheckLicense ( ) ;

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
								Logger . LogCritical ( $"You should READ and ACCEPT {LicenseFilePath} first." ) ;

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
				else
				{
					if ( WriteLicenseFile )
					{
						if ( ! File . Exists ( LicenseFilePath ) )
						{
							Logger . LogInformation (
													$"You can found license of this program at \"{LicenseFilePath}\"." ) ;
							GenerateLicenseFile ( ) ;
						}
					}
				}

				AfterCheckLicense ( ) ;

				#endregion

				#region Load Setting

				LoadSettings ( ) ;

				#endregion

				#region Load Plugin

				LoadPlugins ( ) ;

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

				Console . CancelKeyPress += Console_CancelKeyPress ;

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
					ConsoleReader . Start ( ) ;
					while ( IsRunning )
					{
						if ( ConsoleReader . ReadLine ( 1000 / 60 ) ? . Trim ( ) ? . ToLower ( ) == "exit" )
						{
							RequestExit ( ) ;
						}
					}
				}

				while ( IsRunning )
				{
					ExitEvent . WaitOne ( ) ;
				}

				Exit ( ) ;

				return ProgramExitCode <TExitCode> . Success ;
			}

			IsRunning = true ;

			CommandLineApplication . OnExecute ( Execution ) ;

			try
			{
				CommandLineApplication . Execute ( args ) ;
			}
			catch ( Exception e )
			{
				if ( ! OnStartupExceptions ( e ) )
				{
					throw ;
				}
			}
		}

		protected void LoadPlugins ( )
		{
			BeforeLoadPlugin ( ) ;

			if ( LoadPlugin )
			{
				Logger . LogInformation ( "Finding plugin directory: {0}" , PluginDirectoryPath ) ;

				if ( Directory . Exists ( PluginDirectoryPath ) )
				{
					Logger . LogInformation ( "Found plugin directory." ) ;

					PluginHelper . LoadPlugin ( PluginDirectoryPath , PluginSearchPattern ) ;
				}
				else
				{
					Logger . LogWarning ( "Cannot found plugin directory." ) ;

					Directory . CreateDirectory ( PluginDirectoryPath ) ;

					Logger . LogInformation ( "Plugin directory created." ) ;
				}
			}

			AfterLoadPlugin ( ) ;
		}

		protected void LoadSettings ( )
		{
			BeforeLoadSetting ( ) ;

			if ( LoadSetting )
			{
				Logger . LogInformation ( "Loading setting file." ) ;

				if ( File . Exists ( SettingFilePath ) )
				{
					Logger . LogInformation ( "Setting file exists, Reading." ) ;

					try
					{
						using ( FileStream stream = File . OpenRead ( SettingFilePath ) )
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
		}

		protected virtual bool ConsoleCancelKeyPress ( )
		{
			RequestExit ( ProgramExitCode <TExitCode> . SignalInterrupt ) ;

			return true ;
		}

		private void Console_CancelKeyPress ( object sender , ConsoleCancelEventArgs e )
		{
			e . Cancel = true ;

			e . Cancel = ConsoleCancelKeyPress ( ) ;
		}

		protected virtual void BeforeCheckLicense ( ) { }

		protected virtual void AfterLoadPlugin ( ) { }

		protected virtual void BeforeLoadPlugin ( ) { }

		protected virtual void AfterCheckLicense ( ) { }

		protected virtual void BeforeLoadSetting ( ) { }

		protected virtual void AfterLoadSetting ( ) { }

	}

}

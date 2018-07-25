﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

using DreamRecorder.ToolBox.General;

using JetBrains.Annotations;

using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Logging;

namespace DreamRecorder.ToolBox.CommandLine
{

	[PublicAPI]
	public class ProgramExitCode<T> where T : ProgramExitCode<T>
	{

		public int Code { get; }

		protected ProgramExitCode(int code) { Code = code; }

		public static implicit operator int(ProgramExitCode<T> item) => item.Code;

		public static implicit operator ProgramExitCode<T>(int item) => new ProgramExitCode<T>(item);

		public static readonly T Success = (T)0;

		public static readonly T LicenseNotAccepted = (T)1;

		public static readonly T ExceptionUnhandled = (T)2;

	}


	public abstract class ProgramBase<T, TExitCode>
		where T : ProgramBase<T, TExitCode> where TExitCode : ProgramExitCode<TExitCode>
	{

		protected ILogger Logger { get; private set; }

		public static T Current { get; set; }

		public virtual bool IsRunning { get; set; }

		/// <summary>
		/// This override should create a foreground thread before return or program will exit directly
		/// </summary>
		/// <param name="args"></param>
		public abstract void Start(string[] args);

		public virtual void RegisterArgument(CommandLineApplication application) { }

		public void Exit(TExitCode exitCode)
		{
			if (exitCode == ProgramExitCode<TExitCode>.Success)
			{
				string config = Setting?.Save();
				FileStream settingFile = File.OpenWrite(FileNameConst.SettingFile);
				StreamWriter writer = new StreamWriter(settingFile);
				writer.Write(config);
				writer.Dispose();
			}

			ShowExit();

			IsRunning = false;

			OnExit(exitCode);

			if (!WaitForExit)
			{
				Environment.Exit(exitCode.Code);
			}
		}

		public abstract bool WaitForExit { get; }

		public abstract void ShowLogo();

		public abstract void ShowCopyright();

		public abstract string License { get; }

		private void ShowExit()
		{
			Logger.LogInformation("Exiting");
			Console.WriteLine();
			Console.WriteLine(@"Exiting...");
			Console.WriteLine();
		}

		public bool IsDebug { get; private set; }

		public abstract void OnExit(TExitCode code);

		/// <summary>
		/// 
		/// </summary>
		public virtual void GenerateLicenseFile()
		{
			Logger.LogInformation("Generating License File.");
			FileStream licenseFile = File.Open(FileNameConst.LicenseFile, FileMode.Create);
			using (StreamWriter writer = new StreamWriter(licenseFile))
			{
				writer.WriteLine(License);
				writer.WriteLine();
				writer.WriteLine(
					"To accept this license, you should write \"I accept this License.\" at the end of this file.");
			}
		}

		public virtual bool CheckLicenseFile()
		{
			if (!File.Exists(FileNameConst.LicenseFile))
			{
				Logger.LogInformation("License file not found.");
				GenerateLicenseFile();
				return false;
			}
			else
			{
				FileStream licenseFile = File.OpenRead(FileNameConst.LicenseFile);
				string licenseFileContent;
				using (StreamReader reader = new StreamReader(licenseFile))
				{
					Logger.LogInformation("License file found, reading it.");
					licenseFileContent = reader.ReadToEnd();
				}

				if (!licenseFileContent.EndsWith("I accept this License."))
				{
					Logger.LogInformation("License check error.");

					//Console.WriteLine(@"You should read the License.txt and accept it before use this program.");
					return false;
				}
				else
				{
					Logger.LogInformation("License check pass.");
					return true;
				}
			}
		}


		/// <summary>
		/// Call this after Create StaticLoggerFactory
		/// </summary>
		/// <param name="args"></param>
		public virtual void Main(string[] args)
		{
			Current = (T)this;

			#region StartUp

			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

			foreach (Assembly assembly in assemblies)
			{
				assembly.Startup();
			}

			#endregion

			#region CreateLogger

			Logger = StaticLoggerFactory.LoggerFactory.CreateLogger<T>();

			Logger.LogInformation("Start with argument: {0}", string.Join(" ", args));
			
			#endregion

			CommandLineApplication commandLineApplication = new CommandLineApplication();

			commandLineApplication.HelpOption("-?|-h|--help");

			CommandOption noLogoOption =
				commandLineApplication.Option(@"-noLogo|--noLogo", "Show no logo", CommandOptionType.NoValue);

			CommandOption acceptLicenseOption =
				commandLineApplication.Option(@"-acceptLicense|--acceptLicense",
												"Accept License",
												CommandOptionType.NoValue);

			CommandOption debugOption =
				commandLineApplication.Option(@"-debug|--debug",
												"Launch in Debug mode",
												CommandOptionType.NoValue);


			RegisterArgument(commandLineApplication);

			IsRunning = true;

			commandLineApplication.OnExecute(() =>
											{

												IsDebug = debugOption . HasValue ( ) ;

												if (!noLogoOption.HasValue())
												{
													ShowLogo();
													ShowCopyright();
												}

#if false
												Logger.LogInformation("Debug version, skip license check.");
#else

												if (!acceptLicenseOption.HasValue())
												{
													if (!CheckLicenseFile())
													{
														Logger.LogInformation("Licese check failed.");
														Exit(ProgramExitCode<TExitCode>.LicenseNotAccepted);
													}
												}
												else
												{
													Logger . LogInformation ( "" ) ;
												}
#endif

												Start(args);
												return 0;
											});
		}

	}

}

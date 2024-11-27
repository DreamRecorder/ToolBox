using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

using DreamRecorder.ToolBox.CommandLine.PackageVersionGenerator.Xml;
using DreamRecorder.ToolBox.General;

using McMaster.Extensions.CommandLineUtils;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

using NuGet.Common;
using NuGet.Configuration;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

using ILogger = NuGet.Common.ILogger;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace DreamRecorder.ToolBox.CommandLine.PackageVersionGenerator;

public class Program
	: ProgramBase <Program , Program.ProgramExitCode , Program.ProgramSetting , Program.ProgramSettingCatalog>
{

	public enum ProgramSettingCatalog
	{

	}

	public CommandArgument Arguments { get; set; }

	public override bool AutoSaveSetting => false;

	public override bool CanExit => true;

	public override bool CheckLicense => false;

	private ITaskDispatcher Dispatcher { get; set; }

	public override bool HandleInput => false;

	public override string License => "AGPL";

	public override bool LoadPlugin => false;

	public override bool LoadSetting => false;

	public Dictionary <string , NuGetVersion> Versions { get; } = new Dictionary <string , NuGetVersion> ( );

	public override bool WaitForExit => true;

	public override bool WriteLicenseFile => false;

	public override void ConfigureLogger ( ILoggingBuilder builder )
	{
		builder.AddDebug ( );
		builder.AddFilter <ConsoleLoggerProvider> ( "Default" , LogLevel.Information ).AddConsole ( );
	}

	public static void Main ( string [ ] args ) { new Program ( ).RunMain ( args ); }

	public override void OnExit ( ProgramExitCode code ) { Dispatcher?.Stop ( ); }

	public override void RegisterArgument ( CommandLineApplication application )
	{
		Arguments = application.Argument ( "configFiles" , "Config files" , true );

		base.RegisterArgument ( application );
	}

	public override void ShowCopyright ( )
	{
		Console.WriteLine ( $"Copyright (C) 2018 - {DateTime.Now.Year} Wencey Wang" );

		Console.WriteLine ( @"This program comes with ABSOLUTELY NO WARRANTY." );

		Console.WriteLine (
						   @"This is free software, and you are welcome to redistribute it under certain conditions; read License.txt for details." );
	}

	public override void ShowLogo ( ) { Console.WriteLine ( nameof ( PackageVersionGenerator ) ); }

	public override async void Start ( string [ ] args )
	{
		XmlSerializer serializer = new XmlSerializer ( typeof ( Project ) );

		foreach ( string file in Arguments.Values )
		{
			if ( string.IsNullOrWhiteSpace ( file ) )
			{
				continue;
			}

			Logger.LogInformation ( $"Reading File {file}" );

			await using FileStream fileStream = File.OpenRead ( file );


			Project project = serializer.Deserialize ( fileStream ) as Project;

			foreach ( ProjectPackageVersion packageVersion in project.ItemGroup )
			{
				Versions.TryGetValue ( packageVersion.Include , out NuGetVersion oldVersion );
				NuGetVersion newVersion = new NuGetVersion ( packageVersion.Version );
				if ( oldVersion    == null
					 || newVersion > oldVersion )
				{
					Logger.LogInformation ( $"Adding Package {packageVersion.Include} {newVersion}" );

					Versions [ packageVersion.Include ] = newVersion;
				}
			}
		}

		ISettings setting = Settings.LoadDefaultSettings ( null );

		// get sources 
		PackageSourceProvider       packageSourceProvider = new PackageSourceProvider ( setting );
		IEnumerable <PackageSource> sources               = packageSourceProvider.LoadPackageSources ( );

		foreach ( PackageSource source in sources )
		{
			Logger.LogInformation ( $"Upgrading using {source.Name}" );

			ILogger           logger            = NullLogger.Instance;
			CancellationToken cancellationToken = CancellationToken.None;

			SourceCacheContext cache      = new SourceCacheContext ( );
			SourceRepository   repository = Repository.Factory.GetCoreV3 ( source );
			FindPackageByIdResource resource =
				await repository.GetResourceAsync <FindPackageByIdResource> ( cancellationToken );

			foreach ( KeyValuePair <string , NuGetVersion> pair in Versions )
			{
				IEnumerable <NuGetVersion> versions = await resource.GetAllVersionsAsync (
													   pair.Key ,
													   cache ,
													   logger ,
													   cancellationToken );

				Versions.TryGetValue ( pair.Key , out NuGetVersion oldVersion );

				NuGetVersion newVersion = versions.Where ( version => ! version.IsPrerelease ).Max ( );

				if ( oldVersion    == null
					 || newVersion > oldVersion )
				{
					Logger.LogInformation ( $"Upgrading Package {pair.Key} to {newVersion}" );
					Versions [ pair.Key ] = newVersion;
				}
			}
		}


		Project result = new Project
						 {
							 ItemGroup =
								 Versions.Select (
												  pair => new ProjectPackageVersion
														  {
															  Include = pair.Key , Version = pair.Value.ToString ( ) ,
														  } ).
										  ToArray ( ) ,
							 PropertyGroup = new ProjectPropertyGroup
											 {
												 ManagePackageVersionsCentrally         = true ,
												 CentralPackageTransitivePinningEnabled = true ,
											 } ,
						 };

		using MemoryStream memoryStream = new MemoryStream ( );

		await using XmlWriter writer = XmlWriter.Create (
														 memoryStream ,
														 new XmlWriterSettings
														 {
															 OmitXmlDeclaration  = true ,
															 Async               = true ,
															 Indent              = true ,
															 NewLineOnAttributes = false ,
														 } );

		serializer.Serialize ( writer , result );

		foreach ( string file in Arguments.Values )
		{
			if ( string.IsNullOrWhiteSpace ( file ) )
			{
				continue;
			}

			Logger.LogInformation ( $"Writing to file {file}" );

			await File.WriteAllBytesAsync ( file , memoryStream.ToArray ( ) );
		}

		Exit ( ProgramExitCode.Success );
	}


	public class ProgramExitCode : ProgramExitCode <ProgramExitCode>
	{

	}

	public class ProgramSetting : SettingBase <ProgramSetting , ProgramSettingCatalog>
	{

	}

}

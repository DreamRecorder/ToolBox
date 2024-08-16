using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DreamRecorder.ToolBox.TelegramBot;

using Microsoft.Extensions.Logging;

namespace DreamRecorder.ToolBox.CommandLine.Example.Telegram;

public class Program
	: TelegramBotProgramBase <Program , User , ProgramExitCode , ProgramSetting , ProgramSettingCatalog>
{

	public override bool AutoSaveSetting { get; }

	public override bool CanExit { get; }

	public override bool HandleInput { get; }

	public override string License { get; }

	public override bool LoadSetting { get; }

	public override void ConfigureLogger ( ILoggingBuilder builder ) { throw new NotImplementedException ( ); }

	public static void Main ( string [ ] args ) { new Program ( ).RunMain ( args ); }

	public override void OnExit ( ProgramExitCode code ) { throw new NotImplementedException ( ); }

	public override void ShowCopyright ( ) { throw new NotImplementedException ( ); }

	public override void ShowLogo ( ) { throw new NotImplementedException ( ); }

	public override void Start ( string [ ] args ) { throw new NotImplementedException ( ); }

}

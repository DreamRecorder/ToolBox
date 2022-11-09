using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . CommandLine
{

	/// <summary>
	///     Provide file name const
	/// </summary>
	[PublicAPI]
	public static class FileNameConst
	{

		public static string LicenseFilePath => AppDomain . CurrentDomain . BaseDirectory + LicenseFile ;

		public static string PluginDirectory => "Plugins" ;

		public static string PluginDirectoryPath => AppDomain . CurrentDomain . BaseDirectory + PluginDirectory ;

		public static string SettingFilePath => AppDomain . CurrentDomain . BaseDirectory + SettingFile ;

		public const string LicenseFile = "License.txt" ;

		public const string SettingFile = "Settings.ini" ;

	}

}

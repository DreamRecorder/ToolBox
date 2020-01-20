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

		public static string LicenseFileName
			=> AppDomain . CurrentDomain . BaseDirectory + LicenseFile ;

		public static string SettingFileName
			=> AppDomain . CurrentDomain . BaseDirectory + SettingFile ;

		public const string LicenseFile = "License.txt" ;

		public const string SettingFile = "Settings.ini" ;

	}

}

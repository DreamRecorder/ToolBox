using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;

namespace DreamRecorder . ToolBox . CommandLine
{

	public class SettingItemAttribute : Attribute
	{

		public int SettingCategory { get ; set ; }

		public string DisplayName { get ; set ; }

		public string Introduction { get ; set ; }

		public bool RestartRequired { get ; set ; }

		public object DefultValue { get ; set ; }

		public SettingItemAttribute ( int settingCategory ,
									string displayName ,
									string introduction ,
									bool restartRequired ,
									object defultValue )
		{
			SettingCategory = settingCategory ;
			DisplayName = displayName ?? throw new ArgumentNullException ( nameof(displayName) ) ;
			Introduction = introduction ?? throw new ArgumentNullException ( nameof(introduction) ) ;
			RestartRequired = restartRequired ;
			DefultValue = defultValue ;
		}

		public override string ToString ( )
		{
			StringBuilder builder = new StringBuilder ( ) ;

			builder . AppendLine ( $"#	{DisplayName}" ) ;

			builder . AppendLine ( $"#	{Introduction}" ) ;

			if ( RestartRequired )
			{
				builder . AppendLine ( "#	This setting will be applied after restart." ) ;
			}

			builder . AppendLine ( $"#	Defult Value: {Introduction}" ) ;
			return builder . ToString ( ) ;
		}

	}

}

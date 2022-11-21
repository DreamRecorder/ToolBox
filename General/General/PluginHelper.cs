using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Text ;

using JetBrains . Annotations ;

using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . Logging ;

namespace DreamRecorder . ToolBox . General
{

	public class PluginHelper
	{

		public static void LoadPlugin ( [NotNull] string pluginDirectoryPath , [NotNull] string searchPattern )
		{
			if ( string . IsNullOrWhiteSpace ( pluginDirectoryPath ) )
			{
				throw new ArgumentException ( "Value cannot be null or whitespace." , nameof ( pluginDirectoryPath ) ) ;
			}

			if ( string . IsNullOrWhiteSpace ( searchPattern ) )
			{
				throw new ArgumentException ( "Value cannot be null or whitespace." , nameof ( searchPattern ) ) ;
			}

			string [ ] fileNames = Directory . GetFiles (
														 pluginDirectoryPath ,
														 searchPattern ,
														 SearchOption . AllDirectories ) ;

			foreach ( string fileName in fileNames )
			{
				FileInfo file = new FileInfo ( fileName ) ;


				Logger . LogDebug ( "Found file {0}." , file . Name ) ;

				try
				{
					//{
					//    if (file.Length > int.MaxValue)
					//    {
					//        Logger.LogError("Plugin file {0} is too large to be loaded.");
					//        continue;
					//    }

					//    int fileLength = (int)file.Length;

					//    byte[] contents = new byte[fileLength];

					//    file.OpenRead().Read(contents, 0, fileLength);

					//    AppDomain.CurrentDomain.Load(contents);
					//}

					Assembly assembly = Assembly . LoadFile ( file . FullName ) ;
					Logger . LogInformation ( "Loaded plugin {0}." , assembly . GetDisplayName ( ) ) ;

					StringBuilder builder = new StringBuilder ( ) ;
					assembly . GetAssemblyInfo ( builder ) ;
					Logger . LogInformation ( builder . ToString ( ) ) ;
				}
				catch ( Exception e )
				{
					Logger . LogError ( e , "Error loading plugin {0}." , file . Name ) ;
				}
			}
		}

		#region Logger

		private static ILogger Logger
			=> _logger ??= StaticServiceProvider . Provider . GetService <ILoggerFactory> ( ) .
												   CreateLogger <PluginHelper> ( ) ;


		private static ILogger _logger ;

		#endregion

	}

}

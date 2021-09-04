using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics . CodeAnalysis ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Runtime . InteropServices ;
using System . Xml . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public static class DllMapper
	{

		public static Dictionary <Assembly , Dictionary <string , string>> DllMaps { get ; } =
			new Dictionary <Assembly , Dictionary <string , string>> ( ) ;

		public static void Register (
			[JetBrains . Annotations . NotNull] this Assembly assembly ,
			XDocument                                         config = null )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			ReadConfig ( assembly , config ) ;
			NativeLibrary . SetDllImportResolver ( assembly , MapAndLoad ) ;
		}

		// The callback: which loads the mapped library in place of the original
		private static IntPtr MapAndLoad (
			string                libraryName ,
			Assembly              assembly ,
			DllImportSearchPath ? dllImportSearchPath )
		{
			if ( ! MapLibraryName ( assembly , libraryName , out string mappedName ) )
			{
				mappedName = libraryName ;
			}

			return NativeLibrary . Load ( mappedName , assembly , dllImportSearchPath ) ;
		}

		// Parse the assembly.xml file, and map the old name to the new name of a library.
		private static bool MapLibraryName (
			Assembly                             assembly ,
			string                               originalLibName ,
			[MaybeNullWhen ( false )] out string mappedLibName )
		{
			while ( true )
			{
				if ( DllMaps . TryGetValue ( assembly , out Dictionary <string , string> dllMap ) )
				{
					if ( dllMap . TryGetValue ( originalLibName , out mappedLibName ) )
					{
						return true ;
					}
					else
					{
						return false ;
					}
				}
				else
				{
					ReadConfig ( assembly ) ;
				}
			}
		}

		public static bool CheckOS ( string os ) => os == null || OperatingSystem . IsOSPlatform ( os ) ;

		public static bool CheckWordSize ( [NotNull] string wordSize )
		{
			if ( wordSize == null )
			{
				return true ;
			}

			if ( int . Parse ( wordSize ) == 64 )
			{
				return Environment . Is64BitProcess ;
			}
			else
			{
				return ! Environment . Is64BitProcess ;
			}
		}

		private static void ReadConfig ( Assembly assembly , XDocument document = null )
		{
			if ( ! DllMaps . TryGetValue ( assembly , out Dictionary <string , string> dllMapsList ) )
			{
				dllMapsList = new Dictionary <string , string> ( ) ;
				DllMaps . Add ( assembly , dllMapsList ) ;
			}

			try
			{
				if ( document is null )
				{
					string assemblyLocation = assembly . Location ;

					if ( string . IsNullOrWhiteSpace ( assemblyLocation ) )
					{
						return ;
					}

					string configPath = Path . Combine (
														Path . GetDirectoryName ( assemblyLocation ) ,
														Path . GetFileName ( assemblyLocation ) + ".config" ) ;

					document = XDocument . Load ( configPath ) ;
				}

				XElement configurationNode = document . Root ;

				if ( configurationNode ? . Name == "configuration" )
				{
					IEnumerable <XElement> dllMaps = configurationNode . Elements ( "dllmap" ) ;

					foreach ( XElement dllMap in dllMaps )
					{
						string name = dllMap . ReadNecessaryValue <string> ( "dll" ) ;

						string os = dllMap . ReadUnnecessaryValue <string> ( "os" ) ;

						if ( ! CheckOS ( os ) )
						{
							continue ;
						}

						string cpu = dllMap . ReadUnnecessaryValue <string> ( "cpu" ) ;

						//No way check cpu.

						string wordSize = dllMap . ReadUnnecessaryValue <string> ( "wordsize" ) ;

						if ( ! CheckWordSize ( wordSize ) )
						{
							continue ;
						}

						string target = dllMap . ReadUnnecessaryValue <string> ( "target" ) ;

						if ( target == null )
						{
							foreach ( XElement dllEntry in dllMap . Elements ( "dllentry" ) )
							{
								os = dllEntry . ReadUnnecessaryValue <string> ( "os" ) ;

								if ( ! CheckOS ( os ) )
								{
									continue ;
								}

								cpu = dllEntry . ReadUnnecessaryValue <string> ( "cpu" ) ;

								//No way check cpu.

								wordSize = dllEntry . ReadUnnecessaryValue <string> ( "wordsize" ) ;

								if ( ! CheckWordSize ( wordSize ) )
								{
									continue ;
								}

								target ??= dllEntry . ReadNecessaryValue <string> ( "dll" ) ;

								if ( target != null )
								{
									break ;
								}
							}
						}

						if ( target != null )
						{
							dllMapsList . Add ( name , target ) ;
						}
					}
				}
			}
			catch ( Exception e )
			{
				Console . WriteLine ( e ) ;
			}
		}

	}

}

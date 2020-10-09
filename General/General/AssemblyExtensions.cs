﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Runtime . InteropServices ;
using System . Text ;
using System . Text . RegularExpressions ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class AssemblyExtensions
	{

		public static readonly string CommaWithNewline = $",{Environment . NewLine}" ;

		public static Regex InformationalVersionRegex = new Regex (
																	"Code version \"([^\"]+)\" build by \"([^\"]+)\" at \"([^\"]+)\"" ,
																	RegexOptions . Compiled ) ;

		public static string GetAssemblyFullName ( this Type type )
			=> type . GetTypeInfo ( ) . Assembly . GetName ( ) . FullName . Replace ( ", " , CommaWithNewline ) ;

		public static void GetAssemblyInfo (
			[NotNull]
			this Assembly assembly ,
			[NotNull]
			StringBuilder builder )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			if ( builder == null )
			{
				throw new ArgumentNullException ( nameof ( builder ) ) ;
			}

			builder . AppendLine ( assembly . GetName ( ) . Name ) ;

			builder . AppendLine ( assembly . GetName ( ) . Version . ToString ( ) ) ;

			builder . AppendLine (
								assembly . GetCustomAttribute <AssemblyInformationalVersionAttribute> ( ) ? .
											InformationalVersion ) ;

			builder . AppendLine ( assembly . GetCustomAttribute <AssemblyCopyrightAttribute> ( ) ? . Copyright ) ;
		}

		public static void GetAssemblyInfo <T> (
			[NotNull]
			StringBuilder builder )
		{
			if ( builder == null )
			{
				throw new ArgumentNullException ( nameof ( builder ) ) ;
			}

			GetAssemblyInfo ( typeof ( T ) . Assembly , builder ) ;
		}

		public static string GetResourceFile <T> ( this Assembly assembly , string fileName )
		{
			Stream stream = assembly . GetManifestResourceStream ( typeof ( T ) , fileName ) ;
			if ( stream != null )
			{
				using StreamReader reader  = new StreamReader ( stream ) ;
				string             license = reader . ReadToEnd ( ) ;

				return license ;
			}

			return null ;
		}

		public static void Prepare ( this Assembly assembly )
		{
			PrepareAttribute attribute = assembly . GetCustomAttribute <PrepareAttribute> ( ) ;

			if ( attribute != null )
			{
				foreach ( TypeInfo type in assembly . DefinedTypes )
				{
					foreach ( MethodInfo method in type . DeclaredMethods )
					{
						if ( method . GetCustomAttributes ( typeof ( PrepareAttribute ) ) . Any ( ) )
						{
							method . Invoke ( null , new object [ ] { } ) ;
						}
					}
				}
			}
		}

		public static string GetDisplayName (
			[NotNull]
			this Assembly assembly )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			AssemblyDisplayNameAttribute attribute = assembly . GetCustomAttribute <AssemblyDisplayNameAttribute> ( ) ;

			return attribute ? . Name ?? assembly . GetName ( ) . Name ;
		}

		public static Guid ? GetGuid (
			[NotNull]
			this Assembly assembly )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			GuidAttribute attribute = assembly . GetCustomAttributes <GuidAttribute> ( ) . FirstOrDefault ( ) ;
			string        guid      = attribute ? . Value ;

			if ( guid is null )
			{
				return null ;
			}

			return Guid . Parse ( guid ) ;
		}

		public static (string SourceCodeVersion , string Builder , DateTimeOffset ? BuildTime) ?
			GetInformationalVersion (
				[NotNull]
				this Assembly assembly )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			AssemblyInformationalVersionAttribute attribute =
				assembly . GetCustomAttribute <AssemblyInformationalVersionAttribute> ( ) ;
			string value = attribute ? . InformationalVersion ;

			if ( value != null )
			{
				Match match = InformationalVersionRegex . Match ( value ) ;

				if ( match . Success )
				{
					return ( match . Captures [ 0 ] . Value , match . Captures [ 1 ] . Value ,
								new DateTimeOffset (
													DateTime . Parse ( match . Captures [ 2 ] . Value ) ,
													TimeSpan . Zero ) ) ;
				}
			}

			return default ;
		}

		public static string GetSourceCodeVersion (
			[NotNull]
			this Assembly assembly )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			return assembly . GetInformationalVersion ( ) ? . SourceCodeVersion ;
		}

		public static string GetBuilder (
			[NotNull]
			this Assembly assembly )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			return assembly . GetInformationalVersion ( ) ? . Builder ;
		}

		public static DateTimeOffset ? GetBuildTime (
			[NotNull]
			this Assembly assembly )
		{
			if ( assembly == null )
			{
				throw new ArgumentNullException ( nameof ( assembly ) ) ;
			}

			return assembly . GetInformationalVersion ( ) ? . BuildTime ;
		}

	}

}

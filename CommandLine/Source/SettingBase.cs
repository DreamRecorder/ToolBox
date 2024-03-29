﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Globalization ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Text ;
using System . Text . RegularExpressions ;

using DreamRecorder . ToolBox . General ;

using JetBrains . Annotations ;

using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . Logging ;

namespace DreamRecorder . ToolBox . CommandLine
{

	[PublicAPI]
	public abstract class SettingBase <T , TSettingCategory> : ISettingProvider
		where T : SettingBase <T , TSettingCategory> , new ( ) where TSettingCategory : Enum , IConvertible
	{

		// ReSharper disable once StaticMemberInGenericType
		// By design
		public static Regex LineValuePattern = new Regex ( "^(?:\\s*)([^=#]+)=(.+)" , RegexOptions . Compiled ) ;

		public TResult GetValue <TResult> ( [NotNull] string name , TResult defaultValue = default )
		{
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) ) ;
			}

			PropertyInfo property = typeof ( T ) . GetProperty (
																name . Trim ( ) ,
																BindingFlags . Instance
																| BindingFlags . IgnoreCase
																| BindingFlags . NonPublic
																| BindingFlags . Public
																| BindingFlags . GetProperty ) ;
			if ( property is null )
			{
				return defaultValue ;
			}

			return ( TResult )property . GetValue ( this ) ;
		}

		public string Save ( )
		{
			StringBuilder [ ] stringBuilders =
				new StringBuilder[ Enum . GetValues ( typeof ( TSettingCategory ) ) . Length ] ;

			foreach ( TSettingCategory type in Enum . GetValues ( typeof ( TSettingCategory ) ) )
			{
				stringBuilders [ type . ToInt32 ( CultureInfo . InvariantCulture ) ] = new StringBuilder ( ) ;
			}

			foreach ( PropertyInfo property in typeof ( T ) . GetProperties ( ) )
			{
				SettingItemAttribute attribute =
					( SettingItemAttribute )property . GetCustomAttribute ( typeof ( SettingItemAttribute ) ) ;

				if ( ! ( attribute is null ) )
				{
					int           index           = attribute . SettingCategory ;
					StringBuilder propertyBuilder = stringBuilders [ index ] ;
					propertyBuilder . AppendLine ( attribute . ToString ( ) ) ;
					propertyBuilder . AppendLine ( $"{property . Name} = {property . GetValue ( this )}" ) ;
					propertyBuilder . AppendLine ( ) ;
				}
			}

			StringBuilder builder = new StringBuilder ( ) ;

			for ( int i = 0 ; i < stringBuilders . Length ; i++ )
			{
				builder . AppendLine (
									  $"##{( TSettingCategory )Enum . ToObject ( typeof ( TSettingCategory ) , i )}" ) ;
				builder . AppendLine ( ) ;
				builder . AppendLine ( stringBuilders [ i ] . ToString ( ) ) ;
				builder . AppendLine ( ) ;
			}

			return builder . ToString ( ) ;
		}

		public static T GenerateNew ( )
		{
			T setting = new T ( ) ;

			foreach ( PropertyInfo property in typeof ( T ) . GetProperties ( ) )
			{
				SettingItemAttribute attribute =
					( SettingItemAttribute )property . GetCustomAttribute ( typeof ( SettingItemAttribute ) ) ;

				if ( ! ( attribute is null ) )
				{
					property . SetValue ( setting , attribute . DefaultValue ) ;
				}
			}

			return setting ;
		}

		public static T Load ( [NotNull] string source )
		{
			if ( source == null )
			{
				throw new ArgumentNullException ( nameof ( source ) ) ;
			}

			T settings = new T ( ) ;

			foreach ( string line in source . Split (
													 new [ ] { Environment . NewLine , } ,
													 StringSplitOptions . RemoveEmptyEntries ) )
			{
				ParseLine ( settings , line ) ;
			}

			return settings ;
		}

		public static T Load ( [NotNull] Stream stream )
		{
			if ( stream == null )
			{
				throw new ArgumentNullException ( nameof ( stream ) ) ;
			}

			T settings = new T ( ) ;

			StreamReader reader = new StreamReader ( stream ) ;

			while ( ! reader . EndOfStream )
			{
				string line = reader . ReadLine ( ) ;
				ParseLine ( settings , line ) ;
			}

			reader . Dispose ( ) ;

			return settings ;
		}

		public static void ParseLine ( T settings , string line )
		{
			if ( ! string . IsNullOrWhiteSpace ( line )
				 && ! line . StartsWith ( "#" ) )
			{
				Match match = LineValuePattern . Match ( line ) ;

				if ( match . Success )
				{
					string propertyName = match . Groups [ 1 ] . Value . Trim ( ) ;

					PropertyInfo property = typeof ( T ) . GetProperty (
																		propertyName ,
																		BindingFlags . Instance
																		| BindingFlags . IgnoreCase
																		| BindingFlags . NonPublic
																		| BindingFlags . Public
																		| BindingFlags . SetProperty ) ;

					if ( property != null )
					{
						object value = match . Groups [ 2 ] . Value . Trim ( ) . ParseTo ( property . PropertyType ) ;

						property . SetValue ( settings , value ) ;
					}
					else
					{
						Logger . LogError ( "Cannot find property with name: {0}" , propertyName ) ;
					}
				}
				else
				{
					Logger . LogError ( "Cannot parse line: {0}" , line ) ;
				}
			}
		}


		#region Logger

		private static ILogger Logger
			=> _logger ??= StaticServiceProvider . Provider . GetService <ILoggerFactory> ( ) ? . CreateLogger <T> ( ) ;

		// ReSharper disable once StaticMemberInGenericType
		// By design
		private static ILogger _logger ;

		#endregion

	}

}

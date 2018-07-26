﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Globalization ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Text ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . CommandLine
{

	public abstract class SettingBase <T , TSettingCategory>
		where T : SettingBase <T , TSettingCategory> , new ( ) where TSettingCategory : Enum , IConvertible
	{

		protected SettingBase ( ) {
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
					( SettingItemAttribute ) property . GetCustomAttribute ( typeof ( SettingItemAttribute ) ) ;
				int index = attribute . SettingCategory ;
				StringBuilder propertyBuilder = stringBuilders [ index ] ;
				propertyBuilder . AppendLine ( attribute . ToString ( ) ) ;
				propertyBuilder . AppendLine ( $"{property . Name} = {property . GetValue ( this )}" ) ;
				propertyBuilder . AppendLine ( ) ;
			}

			StringBuilder builder = new StringBuilder ( ) ;

			for ( int i = 0 ; i < stringBuilders . Length ; i++ )
			{
				builder . AppendLine ( $"##{( TSettingCategory ) Enum . ToObject ( typeof ( TSettingCategory ) , i )}" ) ;
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
					( SettingItemAttribute ) property . GetCustomAttribute ( typeof ( SettingItemAttribute ) ) ;
				property . SetValue ( setting , attribute . DefultValue ) ;
			}

			return setting ;
		}

		public static T Load ( [NotNull] string source )
		{
			if ( source == null )
			{
				throw new ArgumentNullException ( nameof(source) ) ;
			}

			T settings = new T ( ) ;

			foreach ( string line in source . Split ( new [ ] { Environment . NewLine } ,
													StringSplitOptions . RemoveEmptyEntries ) )
			{
				if ( ! string . IsNullOrWhiteSpace ( line )
					&& ! line . StartsWith ( "#" ) )
				{
					string [ ] setCommand = line . Split ( '=' ) ;

					PropertyInfo property = settings . GetType ( ) .
														GetProperty ( setCommand [ 0 ] . Trim ( ) ,
																	BindingFlags . IgnoreCase ) ;
					object value = Convert . ChangeType ( setCommand [ 1 ] . Trim ( ) , property . PropertyType ) ;

					property . SetValue ( settings , value ) ;
				}
			}

			return settings ;
		}

		public static T Load ( [NotNull] Stream stream )
		{
			if ( stream == null )
			{
				throw new ArgumentNullException ( nameof(stream) ) ;
			}

			T settings = new T ( ) ;

			StreamReader reader = new StreamReader ( stream ) ;

			while ( ! reader . EndOfStream )
			{
				string line = reader . ReadLine ( ) ;
			}

			reader . Dispose ( ) ;

			return settings ;
		}


		public void ParseLine ( string line )
		{
			if ( ! string . IsNullOrWhiteSpace ( line )
				&& ! line . StartsWith ( "#" ) )
			{
				string [ ] setCommand = line . Split ( '=' ) ;

				PropertyInfo property =
					GetType ( ) . GetProperty ( setCommand [ 0 ] . Trim ( ) , BindingFlags . IgnoreCase ) ;
				object value = Convert . ChangeType ( setCommand [ 1 ] . Trim ( ) , property . PropertyType ) ;

				property . SetValue ( this , value ) ;
			}
		}

	}

}

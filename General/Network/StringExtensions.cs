using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;
using System . Text . RegularExpressions ;

namespace DreamRecorder . ToolBox . Network
{

	internal static class StringExtensions
	{

		private static readonly Regex _fromStringRepresentationRegex =
			new Regex ( @"\\(?<key>([^0-9]|\d\d\d))" , RegexOptions . Compiled ) ;

		// ReSharper disable once InconsistentNaming
		internal static string Add0x20Bits ( this string s )
		{
			char [ ] res = new char[ s . Length ] ;

			for ( int i = 0 ; i < s . Length ; i++ )
			{
				bool isLower = Random . Shared . Next ( ) > 0x3ffffff ;

				char current = s [ i ] ;

				if ( ! isLower
					 && current is >= 'A' and <= 'Z' )
				{
					current = ( char )( current + 0x20 ) ;
				}
				else if ( isLower && current is >= 'a' and <= 'z' )
				{
					current = ( char )( current - 0x20 ) ;
				}

				res [ i ] = current ;
			}

			return new string ( res ) ;
		}

		internal static string FromMasterfileLabelRepresentation ( this string s )
		{
			if ( s == null )
			{
				return null ;
			}

			return _fromStringRepresentationRegex . Replace (
															 s ,
															 k =>
															 {
																 string key = k . Groups [ "key" ] . Value ;

																 if ( key == "#" )
																 {
																	 return @"\#" ;
																 }
																 else if ( key . Length == 3 )
																 {
																	 return new string (
																	  ( char )byte . Parse ( key ) ,
																	  1 ) ;
																 }
																 else
																 {
																	 return key ;
																 }
															 } ) ;
		}

		internal static string ToMasterfileLabelRepresentation ( this string s , bool encodeDots = false )
		{
			if ( s == null )
			{
				return null ;
			}

			StringBuilder sb = new StringBuilder ( ) ;

			for ( int i = 0 ; i < s . Length ; i++ )
			{
				char c = s [ i ] ;

				if ( c    < 32
					 || c > 126 )
				{
					sb . Append ( @"\" + ( ( int )c ) . ToString ( "000" ) ) ;
				}
				else if ( c == '"' )
				{
					sb . Append ( @"\""" ) ;
				}
				else if ( c == '\\' )
				{
					sb . Append ( @"\\" ) ;
				}
				else if ( c == '.' && encodeDots )
				{
					sb . Append ( @"\." ) ;
				}
				else
				{
					sb . Append ( c ) ;
				}
			}

			return sb . ToString ( ) ;
		}

	}

}

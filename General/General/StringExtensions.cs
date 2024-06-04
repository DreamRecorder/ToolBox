using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . ComponentModel ;
using System . Globalization ;
using System . IO ;
using System . Linq ;
using System . Text ;
using System . Text . RegularExpressions ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class StringExtensions
	{

		public static readonly Regex WordDelimiters = new Regex ( @"[\s—–_]" , RegexOptions . Compiled ) ;

		public static readonly Regex InvalidChars = new Regex ( @"[^a-z0-9\-]" , RegexOptions . Compiled ) ;

		public static readonly Regex MultipleHyphens = new Regex ( @"-{2,}" , RegexOptions . Compiled ) ;

		public static bool CanBeFileName ( this string fileName )
		{
			int indexOfInvalidChar = fileName . IndexOfAny ( Path . GetInvalidFileNameChars ( ) ) ;
			return indexOfInvalidChar == - 1 ;
		}

		public static object ParseTo ( this string value , Type type )
		{
			TypeConverter typeConverter = TypeDescriptor . GetConverter ( type ) ;

			return typeConverter . ConvertFromString ( value ) ;
		}

		public static T ParseTo <T> ( this string value ) => ( T )value . ParseTo ( typeof ( T ) ) ;

		private static string RemoveDiacritics ( string input )
		{
			string normalizedInput = input . Normalize ( NormalizationForm . FormD ) ;

			return new string (
							   normalizedInput . Where (
														c => CharUnicodeInfo . GetUnicodeCategory ( c )
															 != UnicodeCategory . NonSpacingMark ) .
												 ToArray ( ) ) . Normalize ( NormalizationForm . FormC ) ;
		}

		public static string [ ] SplitByCamelCase ( [NotNull] this string value )
		{
			if ( value == null )
			{
				throw new ArgumentNullException ( nameof ( value ) ) ;
			}

			string [ ] words = Regex . Matches ( value , "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)" ) .
									   OfType <Match> ( ) .
									   Select ( m => m . Value ) .
									   ToArray ( ) ;

			return words ;
		}

		public static string ToSlug ( this string name ) => ToUrlSlug ( name ) ;

		private static string ToUrlSlug ( string value )
		{
			value = value . ToLowerInvariant ( ) ;

			value = RemoveDiacritics ( value ) ;

			value = WordDelimiters . Replace ( value , "-" ) ;

			value = InvalidChars . Replace ( value , "" ) ;

			value = MultipleHyphens . Replace ( value , "-" ) ;

			return value . Trim ( '-' ) ;
		}

		public static string TrimEndPattern (
			this string      source ,
			string           suffixToRemove ,
			StringComparison comparisonType = StringComparison . Ordinal )
		{
			while ( ! string . IsNullOrEmpty ( source )
					&& ! string . IsNullOrEmpty ( suffixToRemove )
					&& source . EndsWith ( suffixToRemove , comparisonType ) )
			{
				source = source . Substring ( 0 , source . Length - suffixToRemove . Length ) ;
			}

			return source ;
		}

		public static string TrimStartPattern (
			this string      source ,
			string           prefixToRemove ,
			StringComparison comparisonType = StringComparison . Ordinal )
		{
			while ( ! string . IsNullOrEmpty ( source )
					&& ! string . IsNullOrEmpty ( prefixToRemove )
					&& source . StartsWith ( prefixToRemove , comparisonType ) )
			{
				source = source . Substring ( prefixToRemove . Length , source . Length - prefixToRemove . Length ) ;
			}

			return source ;
		}

	}

}

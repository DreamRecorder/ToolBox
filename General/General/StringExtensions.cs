﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Globalization ;
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

		private static string ToUrlSlug ( string value )
		{
			value = value . ToLowerInvariant ( ) ;

			value = RemoveDiacritics ( value ) ;

			value = WordDelimiters . Replace ( value , "-" ) ;

			value = InvalidChars . Replace ( value , "" ) ;

			value = MultipleHyphens . Replace ( value , "-" ) ;

			return value . Trim ( '-' ) ;
		}

		private static string RemoveDiacritics ( string input )
		{
			string normalizedInput = input . Normalize ( NormalizationForm . FormD ) ;
			StringBuilder result = new StringBuilder ( ) ;

			foreach ( char t in normalizedInput )
			{
				UnicodeCategory uc = CharUnicodeInfo . GetUnicodeCategory ( t ) ;
				if ( uc != UnicodeCategory . NonSpacingMark )
				{
					result . Append ( t ) ;
				}
			}

			return ( result . ToString ( ) . Normalize ( NormalizationForm . FormC ) ) ;
		}

		public static string ToSlug ( this string name ) { return ToUrlSlug ( name ) ; }

	}

}

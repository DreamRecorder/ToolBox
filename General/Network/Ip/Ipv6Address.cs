using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text ;
using System . Text . RegularExpressions ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network . Ip
{

	public class Ipv6Address : IpAddress
	{

		[Flags]
		public enum AddressStyle
		{

			Compressed = 0 ,

			LeadingZero = 1 << 0 ,

			NoOmitHextets = 1 << 1 ,

			Preferred = LeadingZero | NoOmitHextets ,

		}

		public override AddressType Type => AddressType . Ipv6 ;

		public string ScopeId { get ; set ; }

		public static Regex ShortenRegex { get ; } = new Regex (
																"(?:(?:^|:)0{1,4})+" ,
																RegexOptions . IgnoreCase | RegexOptions . Compiled ) ;

		public Ipv6Address ( ) => AddressBytes = new byte[ 16 ] ;

		public Ipv6Address ( Memory <byte> address )
		{
			if ( address . Length != 16 )
			{
				throw new ArgumentException ( ) ;
			}

			AddressBytes = address ;
		}

		public Ipv6Address ( string address )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof ( address ) ) ;
			}

			if ( address . Contains ( ':' ) )
			{
				unsafe
				{
					int offset = 0 ;

					if ( address [ 0 ] != '[' )
					{
						address += ']' ; //for Uri parser to find the terminator.
					}
					else
					{
						offset = 1 ;
					}

					int end = address . Length ;

					fixed ( char * name = address )
					{
						if ( Ipv6AddressHelper . IsValidStrict ( name , offset , ref end )
							|| end != address . Length )
						{
							ushort [ ] numbers = new ushort[ NumberOfLabels ] ;
							string     scopeId = null ;

							fixed ( ushort * numbPtr = numbers )
							{
								Ipv6AddressHelper . Parse ( address , numbPtr , 0 , ref scopeId ) ;
							}

							//
							// Scope
							//
							if ( string . IsNullOrEmpty ( scopeId ) )
							{
								scopeId = null ;
							}
							else
							{
								scopeId = scopeId . Substring ( 1 ) ;
							}

							int j = 0 ;

							byte [ ] addressBytes = new byte[ 16 ] ;

							for ( int i = 0 ; i < NumberOfLabels ; i++ )
							{
								addressBytes [ j++ ] = ( byte )( ( numbers [ i ] >> 8 ) & 0xFF ) ;
								addressBytes [ j++ ] = ( byte )( numbers [ i ]          & 0xFF ) ;
							}

							AddressBytes = addressBytes ;

							ScopeId = scopeId ;
						}
						else
						{
							throw new FormatException ( ) ;
						}
					}
				}
			}
			else
			{
				throw new ArgumentException ( "" , nameof ( address ) ) ; //todo
			}
		}

		private const int NumberOfLabels = 8 ;

		public static explicit operator Ipv6Address ( [NotNull] string address )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof ( address ) ) ;
			}

			return new Ipv6Address ( address ) ;
		}

		public override object Clone ( ) => new Ipv6Address ( AddressBytes ) ;

		public string ToString ( AddressStyle style )
		{
			StringBuilder builder = new StringBuilder ( ) ;

			for ( int i = 0 ; i < AddressBytes . Length ; i += 2 )
			{
				int segment = ( ushort )( AddressBytes . Span [ i ] << 8 ) | AddressBytes . Span [ i + 1 ] ;

				if ( style . HasFlag ( AddressStyle . LeadingZero ) )
				{
					builder . AppendFormat ( "{0:X4}" , segment ) ;
				}
				else
				{
					builder . AppendFormat ( "{0:X}" , segment ) ;
				}

				if ( i + 2 != AddressBytes . Length )
				{
					builder . Append ( ':' ) ;
				}
			}

			if ( ! style . HasFlag ( AddressStyle . NoOmitHextets ) )
			{
				MatchCollection matchs = ShortenRegex . Matches ( builder . ToString ( ) ) ;


				if ( matchs . MaxBy ( match => match . Length ) is Match longestMatch )
				{
					if ( longestMatch . Index + longestMatch . Length == builder . Length )
					{
						builder . Replace (
											longestMatch . Value ,
											"::" ,
											longestMatch . Index ,
											longestMatch . Length ) ;
					}
					else
					{
						builder . Replace (
											longestMatch . Value ,
											":" ,
											longestMatch . Index ,
											longestMatch . Length ) ;
					}
				}
			}

			return builder . ToString ( ) ;
		}

		public override string ToString ( ) => ToString ( AddressStyle . Compressed ) ;

	}

}

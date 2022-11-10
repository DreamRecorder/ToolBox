using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics . CodeAnalysis ;
using System . Globalization ;
using System . Linq ;
using System . Text . Json . Serialization ;
using System . Text . RegularExpressions ;

using DreamRecorder . ToolBox . General ;
using DreamRecorder . ToolBox . Network . Dns . DnsSec ;

using Org . BouncyCastle . Crypto ;
using Org . BouncyCastle . Crypto . Digests ;

namespace DreamRecorder . ToolBox . Network . Dns
{

	/// <summary>
	///     Represents a domain name
	/// </summary>
	[JsonConverter ( typeof ( CreateFromStringJsonConverter <DomainName> ) )]
	public class DomainName : IEquatable <DomainName> , IComparable <DomainName> , ICreateFrom <DomainName , string>
	{

		private int ? _hashCode ;

		private string _toString ;

		internal static DomainName Asterisk { get ; } = new DomainName ( new [ ] { "*" , } ) ;

		/// <summary>
		///     Gets the count of labels this domain name contains
		/// </summary>
		public int LabelCount => Labels . Length ;

		/// <summary>
		///     Gets the labels of the domain name
		/// </summary>
		public string [ ] Labels { get ; }

		internal int MaximumRecordDataLength { get { return LabelCount + Labels . Sum ( x => x . Length ) ; } }

		/// <summary>
		///     The DNS root name (.)
		/// </summary>
		public static DomainName Root { get ; } = new DomainName ( new string [ ] { } ) ;

		/// <summary>
		///     Creates a new instance of the DomainName class
		/// </summary>
		/// <param name="labels">The labels of the DomainName</param>
		public DomainName ( string [ ] labels ) => Labels = labels ;

		public DomainName ( string label , DomainName parent )
		{
			Labels = new string[ 1 + parent . LabelCount ] ;

			Labels [ 0 ] = label ;
			Array . Copy ( parent . Labels , 0 , Labels , 1 , parent . LabelCount ) ;
		}

		private static readonly IdnMapping _idnParser = new IdnMapping { UseStd3AsciiRules = true , } ;

		private static readonly Regex _asciiNameRegex = new Regex (
																   "^[a-zA-Z0-9_-]+$" ,
																   RegexOptions . Compiled
																   | RegexOptions . CultureInvariant ) ;

		/// <summary>
		///     Compares the current instance with another name and returns an integer that indicates whether the current instance
		///     precedes, follows, or occurs in the same position in the sort order as the other name.
		/// </summary>
		/// <param name="other">A name to compare with this instance.</param>
		/// <returns>A value that indicates the relative order of the objects being compared.</returns>
		public int CompareTo ( DomainName other )
		{
			for ( int i = 1 ; i <= Math . Min ( LabelCount , other . LabelCount ) ; i++ )
			{
				int labelCompare = string . Compare (
													 Labels [ LabelCount                 - i ] . ToLowerInvariant ( ) ,
													 other . Labels [ other . LabelCount - i ] . ToLowerInvariant ( ) ,
													 StringComparison . Ordinal ) ;

				if ( labelCompare != 0 )
				{
					return labelCompare ;
				}
			}

			return LabelCount . CompareTo ( other . LabelCount ) ;
		}

		string IToT <string> . ToT ( ) => ToString ( ) ;

		public static DomainName CreateFrom ( string value ) => Parse ( value ) ;

		/// <summary>
		///     Checks, whether this name is equal to an other name (case insensitive)
		/// </summary>
		/// <param name="other">The other name</param>
		/// <returns>true, if the names are equal</returns>
		public bool Equals ( DomainName other ) => Equals ( other , true ) ;

		// ReSharper disable once InconsistentNaming
		internal DomainName Add0x20Bits ( )
		{
			string [ ] newLabels = new string[ LabelCount ] ;

			for ( int i = 0 ; i < LabelCount ; i++ )
			{
				newLabels [ i ] = Labels [ i ] . Add0x20Bits ( ) ;
			}

			return new DomainName ( newLabels ) { _hashCode = _hashCode , } ;
		}

		/// <summary>
		///     Checks, whether this name is equal to an other object (case insensitive)
		/// </summary>
		/// <param name="obj">The other object</param>
		/// <returns>true, if the names are equal</returns>
		public override bool Equals ( object obj ) => Equals ( obj as DomainName ) ;

		/// <summary>
		///     Checks, whether this name is equal to an other name
		/// </summary>
		/// <param name="other">The other name</param>
		/// <param name="ignoreCase">true, if the case should ignored on checking</param>
		/// <returns>true, if the names are equal</returns>
		public bool Equals ( DomainName other , bool ignoreCase )
		{
			if ( other is null )
			{
				return false ;
			}

			if ( LabelCount != other . LabelCount )
			{
				return false ;
			}

			if ( _hashCode . HasValue
				 && other . _hashCode . HasValue
				 && ( _hashCode != other . _hashCode ) )
			{
				return false ;
			}

			StringComparison comparison =
				ignoreCase ? StringComparison . OrdinalIgnoreCase : StringComparison . Ordinal ;

			for ( int i = 0 ; i < LabelCount ; i++ )
			{
				if ( ! string . Equals ( Labels [ i ] , other . Labels [ i ] , comparison ) )
				{
					return false ;
				}
			}

			return true ;
		}

		/// <summary>
		///     Returns the hash code for this domain name
		/// </summary>
		/// <returns>The hash code for this domain name</returns>
		[SuppressMessage ( "ReSharper" , "NonReadonlyMemberInGetHashCode" )]
		public override int GetHashCode ( )
		{
			if ( _hashCode . HasValue )
			{
				return _hashCode . Value ;
			}

			int hash = LabelCount ;

			for ( int i = 0 ; i < LabelCount ; i++ )
			{
				unchecked
				{
					hash = hash * 17 + Labels [ i ] . ToLowerInvariant ( ) . GetHashCode ( ) ;
				}
			}

			return ( _hashCode = hash ) . Value ;
		}

		internal byte [ ] GetNSec3Hash ( NSec3HashAlgorithm algorithm , int iterations , byte [ ] salt )
		{
			IDigest digest ;

			switch ( algorithm )
			{
				case NSec3HashAlgorithm . Sha1 :
					digest = new Sha1Digest ( ) ;
					break ;

				default :
					throw new NotSupportedException ( ) ;
			}

			byte [ ] buffer = new byte[ Math . Max ( MaximumRecordDataLength + 1 , digest . GetDigestSize ( ) )
										+ salt . Length ] ;

			int length = 0 ;

			DnsMessageBase . EncodeDomainName ( buffer , 0 , ref length , this , null , true ) ;

			for ( int i = 0 ; i <= iterations ; i++ )
			{
				DnsMessageBase . EncodeByteArray ( buffer , ref length , salt ) ;

				digest . BlockUpdate ( buffer , 0 , length ) ;

				digest . DoFinal ( buffer , 0 ) ;
				length = digest . GetDigestSize ( ) ;
			}

			byte [ ] res = new byte[ length ] ;
			Buffer . BlockCopy ( buffer , 0 , res , 0 , length ) ;

			return res ;
		}

		internal DomainName GetNsec3HashName (
			NSec3HashAlgorithm algorithm ,
			int                iterations ,
			byte [ ]           salt ,
			DomainName         zoneApex )
			=> new DomainName ( GetNSec3Hash ( algorithm , iterations , salt ) . ToBase32HexString ( ) , zoneApex ) ;

		/// <summary>
		///     Gets a parent zone of the domain name
		/// </summary>
		/// <param name="removeLabels">The number of labels to be removed</param>
		/// <returns>The DomainName of the parent zone</returns>
		public DomainName GetParentName ( int removeLabels = 1 )
		{
			if ( removeLabels < 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( removeLabels ) ) ;
			}

			if ( removeLabels > LabelCount )
			{
				throw new ArgumentOutOfRangeException ( nameof ( removeLabels ) ) ;
			}

			if ( removeLabels == 0 )
			{
				return this ;
			}

			string [ ] newLabels = new string[ LabelCount - removeLabels ] ;
			Array . Copy ( Labels , removeLabels , newLabels , 0 , newLabels . Length ) ;

			return new DomainName ( newLabels ) ;
		}

		/// <summary>
		///     Returns if with domain name equals an other domain name or is a child of it
		/// </summary>
		/// <param name="domainName">The possible equal or parent domain name</param>
		/// <returns>true, if the domain name equals the other domain name or is a child of it; otherwise, false</returns>
		public bool IsEqualOrSubDomainOf ( DomainName domainName )
		{
			if ( Equals ( domainName ) )
			{
				return true ;
			}

			if ( domainName . LabelCount >= LabelCount )
			{
				return false ;
			}

			return GetParentName ( LabelCount - domainName . LabelCount ) . Equals ( domainName ) ;
		}

		/// <summary>
		///     Returns if with domain name is a child of an other domain name
		/// </summary>
		/// <param name="domainName">The possible parent domain name</param>
		/// <returns>true, if the domain name is a child of the other domain; otherwise, false</returns>
		public bool IsSubDomainOf ( DomainName domainName )
		{
			if ( domainName . LabelCount >= LabelCount )
			{
				return false ;
			}

			return GetParentName ( LabelCount - domainName . LabelCount ) . Equals ( domainName ) ;
		}

		/// <summary>
		///     Concatinates two names
		/// </summary>
		/// <param name="name1">The left name</param>
		/// <param name="name2">The right name</param>
		/// <returns>A new domain name</returns>
		public static DomainName operator + ( DomainName name1 , DomainName name2 )
		{
			string [ ] newLabels = new string[ name1 . LabelCount + name2 . LabelCount ] ;

			Array . Copy ( name1 . Labels , newLabels , name1 . LabelCount ) ;
			Array . Copy ( name2 . Labels , 0 ,         newLabels , name1 . LabelCount , name2 . LabelCount ) ;

			return new DomainName ( newLabels ) ;
		}

		/// <summary>
		///     Checks, whether two names are identical (case sensitive)
		/// </summary>
		/// <param name="name1">The first name</param>
		/// <param name="name2">The second name</param>
		/// <returns>true, if the names are identical</returns>
		public static bool operator == ( DomainName name1 , DomainName name2 )
		{
			if ( ReferenceEquals ( name1 , name2 ) )
			{
				return true ;
			}

			if ( name1 is null )
			{
				return false ;
			}

			return name1 . Equals ( name2 , false ) ;
		}

		/// <summary>
		///     Checks, whether two names are not identical (case sensitive)
		/// </summary>
		/// <param name="name1">The first name</param>
		/// <param name="name2">The second name</param>
		/// <returns>true, if the names are not identical</returns>
		public static bool operator != ( DomainName name1 , DomainName name2 ) => ! ( name1 == name2 ) ;

		/// <summary>
		///     Parses the string representation of a domain name
		/// </summary>
		/// <param name="s">The string representation of the domain name to parse</param>
		/// <returns>A new instance of the DomainName class</returns>
		public static DomainName Parse ( string s )
		{
			if ( TryParse ( s , out DomainName res ) )
			{
				return res ;
			}

			throw new ArgumentException ( "Domain name could not be parsed" , nameof ( s ) ) ;
		}

		internal static DomainName ParseFromMasterFile ( string s )
		{
			if ( s == "." )
			{
				return Root ;
			}

			List <string> labels = new List <string> ( ) ;

			int lastOffset = 0 ;

			for ( int i = 0 ; i < s . Length ; ++i )
			{
				if ( s [ i ] == '.'
					 && ( i == 0 || s [ i - 1 ] != '\\' ) )
				{
					labels . Add (
								  s . Substring ( lastOffset , i - lastOffset ) .
									  FromMasterfileLabelRepresentation ( ) ) ;
					lastOffset = i + 1 ;
				}
			}

			labels . Add (
						  s . Substring ( lastOffset , s . Length - lastOffset ) .
							  FromMasterfileLabelRepresentation ( ) ) ;

			if ( labels [ ^1 ] == string . Empty )
			{
				labels . RemoveAt ( labels . Count - 1 ) ;
			}

			return new DomainName ( labels . ToArray ( ) ) ;
		}

		/// <summary>
		///     Returns the string representation of the domain name
		/// </summary>
		/// <returns>The string representation of the domain name</returns>
		public override string ToString ( )
		{
			if ( _toString != null )
			{
				return _toString ;
			}

			return ( _toString = string . Join (
												"." ,
												Labels . Select ( x => x . ToMasterfileLabelRepresentation ( true ) ) )
								 + "." ) ;
		}

		/// <summary>
		///     Parses the string representation of a domain name
		/// </summary>
		/// <param name="s">The string representation of the domain name to parse</param>
		/// <param name="name">
		///     When this method returns, contains a DomainName instance representing s or null, if s could not be
		///     parsed
		/// </param>
		/// <returns>true, if s was parsed successfully; otherwise, false</returns>
		public static bool TryParse ( string s , out DomainName name )
		{
			if ( s == "." )
			{
				name = Root ;
				return true ;
			}

			List <string> labels = new List <string> ( ) ;

			int lastOffset = 0 ;

			string label ;

			for ( int i = 0 ; i < s . Length ; ++i )
			{
				if ( s [ i ] == '.'
					 && ( i == 0 || s [ i - 1 ] != '\\' ) )
				{
					if ( TryParseLabel ( s . Substring ( lastOffset , i - lastOffset ) , out label ) )
					{
						labels . Add ( label ) ;
						lastOffset = i + 1 ;
					}
					else
					{
						name = null ;
						return false ;
					}
				}
			}

			if ( s . Length == lastOffset )
			{
				// empty label --> name ends with dot
			}
			else if ( TryParseLabel ( s . Substring ( lastOffset , s . Length - lastOffset ) , out label ) )
			{
				labels . Add ( label ) ;
			}
			else
			{
				name = null ;
				return false ;
			}

			name = new DomainName ( labels . ToArray ( ) ) ;
			return true ;
		}

		private static bool TryParseLabel ( string s , out string label )
		{
			try
			{
				if ( _asciiNameRegex . IsMatch ( s ) )
				{
					label = s ;
					return true ;
				}
				else
				{
					label = _idnParser . GetAscii ( s ) ;
					return true ;
				}
			}
			catch
			{
				label = null ;
				return false ;
			}
		}

	}

}

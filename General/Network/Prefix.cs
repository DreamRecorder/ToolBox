using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . ComponentModel . DataAnnotations ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network
{

	[PublicAPI]
	public abstract class Prefix : ICloneable , IEquatable <Prefix> , IPrefix <Address>
	{

		[Key]
		public Memory <byte> AddressBytes { get ; set ; }

		public byte Length { get ; set ; }

		public abstract AddressType Type { get ; }

		public abstract object Clone ( ) ;

		public bool Equals ( Prefix other )
		{
			if ( other is null )
			{
				return false ;
			}

			if ( ReferenceEquals ( this , other ) )
			{
				return true ;
			}

			return Equals ( AddressBytes , other . AddressBytes ) && Length == other . Length && Type == other . Type ;
		}

		public virtual bool Contains ( [NotNull] Address address )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof ( address ) ) ;
			}

			if ( address . Type == Type )
			{
				bool [ ] prefixArray  = AddressBytes . ToArray ( ) . ToBooleanArray ( ) ;
				bool [ ] addressArray = address . AddressBytes . ToArray ( ) . ToBooleanArray ( ) ;

				bool result = true ;

				for ( int i = 0 ; i < Length ; i++ )
				{
					result &= prefixArray [ i ] == addressArray [ i ] ;
					if ( ! result )
					{
						return false ;
					}
				}

				return true ;
			}

			return false ;
		}

		public static explicit operator string ( Prefix prefix ) => prefix . ToString ( ) ;

		public override bool Equals ( object obj )
		{
			if ( obj is null )
			{
				return false ;
			}

			if ( ReferenceEquals ( this , obj ) )
			{
				return true ;
			}

			if ( obj . GetType ( ) != GetType ( ) )
			{
				return false ;
			}

			return Equals ( ( Prefix )obj ) ;
		}

		public override int GetHashCode ( )
		{
			unchecked
			{
				return ( AddressBytes . GetHashCode ( ) * 397 ) ^ Length . GetHashCode ( ) ;
			}
		}

		public static bool operator == ( Prefix left , Prefix right ) => Equals ( left , right ) ;

		public static bool operator != ( Prefix left , Prefix right ) => ! Equals ( left , right ) ;

	}

}

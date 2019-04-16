using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . ComponentModel . DataAnnotations ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network
{

	public interface IPrefix <TAddress> where TAddress : IAddress
	{

		bool Contains ( TAddress address ) ;

	}

	public interface IAddress
	{

	}

	[PublicAPI]
	public abstract class Prefix : ICloneable , IEquatable <Prefix>
	{

		[Key]
		public byte [ ] AddressBytes { get ; set ; }

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

			return Equals ( AddressBytes , other . AddressBytes )
					&& ( Length == other . Length )
					&& ( Type   == other . Type ) ;
		}

		public static explicit operator string ( Prefix prefix ) => prefix . ToString ( ) ;

		public virtual bool IsInPrefix ( [NotNull] Address address )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof(address) ) ;
			}

			if ( address . Type == Type )
			{
				bool [ ] prefixArray  = AddressBytes . ToBooleanArray ( ) ;
				bool [ ] addressArray = address . AddressBytes . ToBooleanArray ( ) ;

				bool isSame = true ;

				for ( int i = 0 ; i < Length ; i++ )
				{
					isSame &= prefixArray [ i ] == addressArray [ i ] ;
				}

				return isSame ;
			}

			return false ;
		}

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

			return Equals ( ( Prefix ) obj ) ;
		}

		public override int GetHashCode ( )
		{
			unchecked
			{
				return ( ( AddressBytes != null ? AddressBytes . GetHashCode ( ): 0 ) * 397 )
						^ Length . GetHashCode ( ) ;
			}
		}

		public static bool operator == ( Prefix left , Prefix right ) => Equals ( left , right ) ;

		public static bool operator != ( Prefix left , Prefix right ) => ! Equals ( left , right ) ;

	}

}

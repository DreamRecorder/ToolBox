using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . ComponentModel . DataAnnotations ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network
{

	[PublicAPI]
	public abstract class Address : ICloneable , IEquatable <Address> , IAddress
	{

		[Key]
		public byte [ ] AddressBytes { get ; set ; }

		public abstract AddressType Type { get ; }

		public abstract object Clone ( ) ;

		public virtual bool Equals ( Address other )
		{
			if ( other is null )
			{
				return false ;
			}

			if ( ReferenceEquals ( this , other ) )
			{
				return true ;
			}

			return Equals ( AddressBytes , other . AddressBytes ) && ( Type == other . Type ) ;
		}

		public static implicit operator byte [ ] ( Address address ) => address . AddressBytes ;

		public static explicit operator string ( Address address ) => address . ToString ( ) ;

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

			return Equals ( ( Address ) obj ) ;
		}

		public override int GetHashCode ( ) => AddressBytes != null ? AddressBytes . GetHashCode ( ) : 0 ;

		public static bool operator == ( Address left , Address right ) => Equals ( left , right ) ;

		public static bool operator != ( Address left , Address right ) => ! Equals ( left , right ) ;

	}

}

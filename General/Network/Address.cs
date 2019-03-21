using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . ComponentModel . DataAnnotations ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network
{

	[PublicAPI]
	public abstract class Address : ICloneable , IEquatable <Address>
	{

		[Key]
		public byte [ ] AddressBytes { get ; set ; }

		public abstract AddressType Type { get ; }

		public abstract object Clone ( ) ;

		public virtual bool Equals ( Address other )
		{
			if ( ReferenceEquals ( null , other ) )
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
			if ( ReferenceEquals ( null , obj ) )
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

		public override int GetHashCode ( ) => AddressBytes != null ? AddressBytes . GetHashCode ( ): 0 ;

		public static bool operator == ( Address left , Address right ) => Equals ( left , right ) ;

		public static bool operator != ( Address left , Address right ) => ! Equals ( left , right ) ;

	}

}

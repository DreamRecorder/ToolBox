using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network
{

	public abstract class Address : ICloneable , IEquatable <Address>
	{

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

			return Equals ( AddressBytes , other . AddressBytes ) && Type == other . Type ;
		}

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

		public override int GetHashCode ( ) { return ( AddressBytes != null ? AddressBytes . GetHashCode ( ): 0 ) ; }

		public static bool operator == ( Address left , Address right ) { return Equals ( left , right ) ; }

		public static bool operator != ( Address left , Address right ) { return ! Equals ( left , right ) ; }

	}

}

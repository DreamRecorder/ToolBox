using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public class MarkedValue
		<TValue , TMark> : ICloneable , IEquatable <MarkedValue <TValue , TMark>>
		where TValue : IEquatable <TValue>
	{

		public TValue Value { get ; }

		public TMark Mark { get ; set ; }

		public MarkedValue ( TValue value , TMark mark )
		{
			Value = value ;
			Mark  = mark ;
		}

		public object Clone ( ) => new MarkedValue <TValue , TMark> ( Value , Mark ) ;

		public bool Equals ( MarkedValue <TValue , TMark> other )
		{
			if ( other is null )
			{
				return false ;
			}

			return ReferenceEquals ( this , other )
				|| EqualityComparer <TValue> . Default . Equals ( Value , other . Value ) ;
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

			return obj . GetType ( ) == GetType ( )
				&& Equals ( ( MarkedValue <TValue , TMark> ) obj ) ;
		}

		public override int GetHashCode ( )
			=> EqualityComparer <TValue> . Default . GetHashCode ( Value ) ;

		public static bool operator == (
			MarkedValue <TValue , TMark> left ,
			MarkedValue <TValue , TMark> right )
			=> Equals ( left , right ) ;

		public static bool operator != (
			MarkedValue <TValue , TMark> left ,
			MarkedValue <TValue , TMark> right )
			=> ! Equals ( left , right ) ;

		public static implicit operator TValue ( MarkedValue <TValue , TMark> value )
			=> value . Value ;

		public static implicit operator MarkedValue <TValue , TMark> ( TValue value )
			=> new MarkedValue <TValue , TMark> ( value , default ) ;

	}

}

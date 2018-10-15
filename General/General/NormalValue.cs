using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Globalization ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	/// <summary>
	///     表示可能性和变换.
	/// </summary>
	public struct NormalValue : IEquatable <NormalValue>
	{

		public int Value { get ; }

		public static implicit operator int ( NormalValue value ) { return value . Value ; }

		public override bool Equals ( object obj ) { return Value . Equals ( obj ) ; }

		public override int GetHashCode ( ) { return Value . GetHashCode ( ) ; }

		public static NormalValue MaxValue { get ; } = 10000 ;

		public static NormalValue MinValue { get ; } = 0 ;

		public override string ToString ( ) { return Value . ToString ( CultureInfo . InvariantCulture ) ; }

		public bool Equals ( NormalValue other ) { return Value == other . Value ; }

		public static bool operator == ( NormalValue left , NormalValue right ) { return left . Equals ( right ) ; }

		public static bool operator != ( NormalValue left , NormalValue right ) { return ! left . Equals ( right ) ; }

		public static NormalValue operator * ( NormalValue left , NormalValue right )
		{
			return left . Value * right . Value / MaxValue ;
		}

		public static explicit operator NormalValue ( decimal value )
		{
			return new NormalValue ( Convert . ToInt32 ( value * MaxValue ) ) ;
		}

		public static explicit operator NormalValue ( double value )
		{
			return new NormalValue ( Convert . ToInt32 ( value * MaxValue ) ) ;
		}

		public static explicit operator double ( NormalValue value )
		{
			return Convert . ToDouble ( value . Value ) / MaxValue ;
		}

		private sealed class ValueEqualityComparer : IEqualityComparer <NormalValue>
		{

			public bool Equals ( NormalValue x , NormalValue y ) { return x . Value == y . Value ; }

			public int GetHashCode ( NormalValue obj ) { return obj . Value ; }

		}

		public static IEqualityComparer <NormalValue> ValueComparer { get ; } = new ValueEqualityComparer ( ) ;

		public int ToInt32 ( ) { return this ; }

		public NormalValue ( int value ) { Value = Math . Min ( Math . Max ( value , 0 ) , 10000 ) ; }

		public static implicit operator NormalValue ( int value ) { return new NormalValue ( value ) ; }

	}

}

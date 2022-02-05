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
	public readonly struct NormalValue : IEquatable <NormalValue>
	{

		public int Value { get ; }

		public static implicit operator int ( NormalValue value ) => value . Value ;

		public override bool Equals ( object obj ) => Value . Equals ( obj ) ;

		public override int GetHashCode ( ) => Value . GetHashCode ( ) ;

		public static NormalValue MaxValue { get ; } = short.MaxValue ;

		public static NormalValue MinValue { get ; } = 0 ;

		public override string ToString ( ) => Value . ToString ( CultureInfo . InvariantCulture ) ;

		public bool Equals ( NormalValue other ) => Value == other . Value ;

		public static bool operator == ( NormalValue left , NormalValue right ) => left . Equals ( right ) ;

		public static bool operator != ( NormalValue left , NormalValue right ) => ! left . Equals ( right ) ;

		public static NormalValue operator * ( NormalValue left , NormalValue right )
			=> left . Value * right . Value / MaxValue ;

		public static explicit operator NormalValue ( decimal value )
			=> new NormalValue ( Convert . ToInt32 ( value * MaxValue ) ) ;

		public static explicit operator NormalValue ( double value )
			=> new NormalValue ( Convert . ToInt32 ( value * MaxValue ) ) ;

		public static explicit operator double ( NormalValue value )
			=> Convert . ToDouble ( value . Value ) / MaxValue ;

		private sealed class ValueEqualityComparer : IEqualityComparer <NormalValue>
		{

			public bool Equals ( NormalValue x , NormalValue y ) => x . Value == y . Value ;

			public int GetHashCode ( NormalValue obj ) => obj . Value ;

		}

		public static IEqualityComparer <NormalValue> ValueComparer { get ; } = new ValueEqualityComparer ( ) ;

		public int ToInt32 ( ) => this ;

		public NormalValue ( int value ) => Value = Math . Min ( Math . Max ( value , MinValue) , MaxValue) ;

		public static implicit operator NormalValue ( int value ) => new NormalValue ( value ) ;

	}

}

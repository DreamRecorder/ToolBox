using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public struct Angle : IEquatable <Angle>
	{

		public static implicit operator Angle ( double degree ) => new Angle ( degree ) ;

		public static implicit operator double ( Angle angle ) => angle . Degree ;

		public double Degree { get ; }

		public bool Equals ( Angle other ) => Degree . Equals ( other . Degree ) ;

		public override bool Equals ( object obj )
		{
			if ( obj is null )
			{
				return false ;
			}

			return obj is Angle angle && Equals ( angle ) ;
		}

		public override int GetHashCode ( ) => Degree . GetHashCode ( ) ;

		public static bool operator == ( Angle left , Angle right ) => left . Equals ( right ) ;

		public static bool operator != ( Angle left , Angle right ) => ! left . Equals ( right ) ;

		public double Radius => ( Degree / 180 ) * Math . PI ;

		public Angle ( double degree ) => Degree = degree ;

		public double Grad => ( Degree / 9 ) * 10 ;

		public static explicit operator Angle ( string value )
		{
			if ( value . EndsWith ( "°" ) )
			{
				return new Angle ( Convert . ToDouble ( value . TrimEnd ( '°' ) ) ) ;
			}

			if ( value . EndsWith ( "ᵍ" )
				|| value . EndsWith ( "gon" ) )
			{
				return new Angle ( Convert . ToDouble ( value . TrimEnd ( ( "ᵍ" + "gon" ) . ToCharArray ( ) ) ) ) ;
			}

			return new Angle ( ( Convert . ToDouble ( value ) / Math . PI ) * 180 ) ;
		}


		public static Angle FromDegree ( double degree ) => new Angle ( degree ) ;

		public static Angle FromRadius ( double radius ) => new Angle ( ( radius / Math . PI ) * 180 ) ;

		public static Angle FromGrad ( double grad ) => new Angle ( ( grad / 10 ) * 9 ) ;

		public override string ToString ( ) => $"{Degree}°" ;

	}

}

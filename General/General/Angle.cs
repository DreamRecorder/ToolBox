using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Runtime . Serialization ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	[DataContract]
	public struct Angle : IEquatable <Angle>
	{

		public Angle InRound => new Angle ( Radius % ( 2 * Math . PI ) ) ;

		public static double DegreeToRadius ( double degree ) => degree / 180 * Math . PI ;

		public static double RadiusToDegree ( double radius ) => radius / Math . PI * 180 ;

		public static double DegreeToGrad ( double degree ) => degree / 9 * 10 ;

		public static double GradToDegree ( double grad ) => grad / 10 * 9 ;

		[DataMember]
		public double Radius { get ; }

		public double Degree => RadiusToDegree ( Radius ) ;

		public double Grad => DegreeToGrad ( Degree ) ;

		public Angle ( double radius ) => Radius = radius ;

		public static Angle FromRadius ( double radius ) => new Angle ( radius ) ;

		public static Angle FromDegree ( double degree ) => new Angle ( DegreeToRadius ( degree ) ) ;

		public static Angle FromGrad ( double grad ) => new Angle ( DegreeToRadius ( GradToDegree ( grad ) ) ) ;

		public static implicit operator Angle ( double radius ) => FromRadius ( radius ) ;

		public static implicit operator double ( Angle angle ) => angle . Radius ;


		public bool Equals ( Angle other ) => Radius . Equals ( other . Radius ) ;

		public static bool operator == ( Angle left , Angle right ) => left . Equals ( right ) ;

		public static bool operator != ( Angle left , Angle right ) => ! left . Equals ( right ) ;

		public override bool Equals ( object obj )
		{
			if ( obj is null )
			{
				return false ;
			}

			return obj is Angle angle && Equals ( angle ) ;
		}

		public override int GetHashCode ( ) => Degree . GetHashCode ( ) ;

		public static explicit operator Angle ( string value )
		{
			if ( value . EndsWith ( "°" ) )
			{
				return FromDegree ( Convert . ToDouble ( value . TrimEnd ( '°' ) ) ) ;
			}

			if ( value . EndsWith ( "ᵍ" )
				|| value . EndsWith ( "gon" ) )
			{
				return FromGrad ( Convert . ToDouble ( value . TrimEnd ( ( "ᵍ" + "gon" ) . ToCharArray ( ) ) ) ) ;
			}

			return FromRadius ( Convert . ToDouble ( value ) / Math . PI * 180 ) ;
		}

		public override string ToString ( ) => $"{Degree}°" ;

	}

}

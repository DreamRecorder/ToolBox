using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Drawing ;
using System . Linq ;
using System . Runtime . Serialization ;
using System . Xml . Linq ;

using DreamRecorder . ToolBox . General ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Colors
{

	[PublicAPI]
	[Serializable]
	[DataContract]
	public struct HdrColor : IEquatable <HdrColor> , ISelfSerializable
	{

		[DataMember]
		public double R { get ; }

		[DataMember]
		public double G { get ; }

		[DataMember]
		public double B { get ; }

		public HdrColor ( double r , double g , double b )
		{
			R = r ;
			G = g ;
			B = b ;
		}

		public HdrColor ( XElement element )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof(element) ) ;
			}

			if ( element . Name == nameof(HdrColor) )
			{
				throw new ArgumentException ( ExceptionMessages . XmlNameMismatch ( nameof(element) ,
																					typeof ( HdrColor ) ) ) ;
			}

			R = element . ReadNecessaryValue <double> ( nameof(R) ) ;
			G = element . ReadNecessaryValue <double> ( nameof(G) ) ;
			B = element . ReadNecessaryValue <double> ( nameof(B) ) ;
		}

		/// <summary>
		///     Returns the vector (0,0,0).
		/// </summary>
		public static HdrColor Black => new HdrColor ( ) ;

		/// <summary>
		///     Returns the vector (1,1,1).
		/// </summary>
		public static HdrColor White => new HdrColor ( 1.0d , 1.0d , 1.0d ) ;

		/// <summary>
		///     Returns the vector (1,0,0).
		/// </summary>
		public static HdrColor Red => new HdrColor ( 1.0d , 0.0d , 0.0d ) ;

		/// <summary>
		///     Returns the vector (0,1,0).
		/// </summary>
		public static HdrColor Green => new HdrColor ( 0.0d , 1.0d , 0.0d ) ;

		/// <summary>
		///     Returns the vector (0,0,1).
		/// </summary>
		public static HdrColor Blue => new HdrColor ( 0.0d , 0.0d , 1.0d ) ;

		public bool Equals ( HdrColor other )
		{
			return R . Equals ( other . R ) && G . Equals ( other . G ) && B . Equals ( other . B ) ;
		}

		public override bool Equals ( object obj )
		{
			if ( ReferenceEquals ( null , obj ) )
			{
				return false ;
			}

			return obj is HdrColor color && Equals ( color ) ;
		}

		public override int GetHashCode ( )
		{
			unchecked
			{
				int hashCode = R . GetHashCode ( ) ;
				hashCode = ( hashCode * 397 ) ^ G . GetHashCode ( ) ;
				hashCode = ( hashCode * 397 ) ^ B . GetHashCode ( ) ;
				return hashCode ;
			}
		}

		public XElement ToXElement ( )
		{
			XElement result = new XElement ( nameof(HdrColor) ) ;

			result . SetAttributeValue ( nameof(R) , R ) ;
			result . SetAttributeValue ( nameof(G) , G ) ;
			result . SetAttributeValue ( nameof(B) , B ) ;

			return result ;
		}


		public static bool operator == ( HdrColor left , HdrColor right ) { return Equals ( left , right ) ; }

		public static bool operator != ( HdrColor left , HdrColor right ) { return ! Equals ( left , right ) ; }


		/// <summary>
		///     Returns a vector whose elements are the minimum of each of the pairs of elements in the two source vectors.
		/// </summary>
		/// <param name="value1">The first source vector.</param>
		/// <param name="value2">The second source vector.</param>
		/// <returns>The minimized vector.</returns>
		public static HdrColor Min ( HdrColor value1 , HdrColor value2 )
		{
			return new HdrColor ( value1 . R < value2 . R ? value1 . R: value2 . R ,
								value1 . G < value2 . G ? value1 . G: value2 . G ,
								value1 . B < value2 . B ? value1 . B: value2 . B ) ;
		}

		/// <summary>
		///     Returns a vector whose elements are the maximum of each of the pairs of elements in the two source vectors.
		/// </summary>
		/// <param name="value1">The first source vector.</param>
		/// <param name="value2">The second source vector.</param>
		/// <returns>The maximized vector.</returns>
		public static HdrColor Max ( HdrColor value1 , HdrColor value2 )
		{
			return new HdrColor ( value1 . R > value2 . R ? value1 . R: value2 . R ,
								value1 . G > value2 . G ? value1 . G: value2 . G ,
								value1 . B > value2 . B ? value1 . B: value2 . B ) ;
		}

		/// <summary>
		///     Adds two vectors together.
		/// </summary>
		/// <param name="left">The first source vector.</param>
		/// <param name="right">The second source vector.</param>
		/// <returns>The summed vector.</returns>
		public static HdrColor operator + ( HdrColor left , HdrColor right )
		{
			return new HdrColor ( left . R + right . R , left . G + right . G , left . B + right . B ) ;
		}

		public static HdrColor operator + ( HdrColor left , double right )
		{
			return new HdrColor ( left . R + right , left . G + right , left . B + right ) ;
		}

		/// <summary>
		///     Subtracts the second vector from the first.
		/// </summary>
		/// <param name="left">The first source vector.</param>
		/// <param name="right">The second source vector.</param>
		/// <returns>The difference vector.</returns>
		public static HdrColor operator - ( HdrColor left , HdrColor right )
		{
			return new HdrColor ( left . R - right . R , left . G - right . G , left . B - right . B ) ;
		}

		public static HdrColor operator - ( HdrColor left , double right )
		{
			return new HdrColor ( left . R - right , left . G - right , left . B - right ) ;
		}

		/// <summary>
		///     Multiplies two vectors together.
		/// </summary>
		/// <param name="left">The first source vector.</param>
		/// <param name="right">The second source vector.</param>
		/// <returns>The product vector.</returns>
		public static HdrColor operator * ( HdrColor left , HdrColor right )
		{
			return new HdrColor ( left . R * right . R , left . G * right . G , left . B * right . B ) ;
		}

		/// <summary>
		///     Multiplies a vector by the given scalar.
		/// </summary>
		/// <param name="left">The source vector.</param>
		/// <param name="right">The scalar value.</param>
		/// <returns>The scaled vector.</returns>
		public static HdrColor operator * ( HdrColor left , double right ) { return left * new HdrColor ( right ) ; }

		/// <summary>
		///     Multiplies a vector by the given scalar.
		/// </summary>
		/// <param name="left">The scalar value.</param>
		/// <param name="right">The source vector.</param>
		/// <returns>The scaled vector.</returns>
		public static HdrColor operator * ( double left , HdrColor right ) { return new HdrColor ( left ) * right ; }

		public HdrColor ( double value ) : this ( value , value , value ) { }

		/// <summary>
		///     Divides the first vector by the second.
		/// </summary>
		/// <param name="left">The first source vector.</param>
		/// <param name="right">The second source vector.</param>
		/// <returns>The vector resulting from the division.</returns>
		public static HdrColor operator / ( HdrColor left , HdrColor right )
		{
			return new HdrColor ( left . R / right . R , left . G / right . G , left . B / right . B ) ;
		}

		/// <summary>
		///     Divides the vector by the given scalar.
		/// </summary>
		/// <param name="value1">The source vector.</param>
		/// <param name="value2">The scalar value.</param>
		/// <returns>The result of the division.</returns>
		public static HdrColor operator / ( HdrColor value1 , double value2 )
		{
			double invDiv = 1.0f / value2 ;

			return new HdrColor ( value1 . R * invDiv , value1 . G * invDiv , value1 . B * invDiv ) ;
		}


		public static implicit operator HdrColor ( (double R , double G , double B) value )
		{
			return new HdrColor ( value . R , value . G , value . B ) ;
		}

		public double Brightness => ( R + G + B ) / 3 ;

		public HdrColor SetBrightness ( double brightness ) { return this * ( brightness / Brightness ) ; }

		public double Saturation
		{
			get
			{
				double maxValue = Math . Max ( Math . Max ( R , G ) , B ) ;
				double minValue = Math . Min ( Math . Min ( R , G ) , B ) ;
				return maxValue - minValue ;
			}
		}

		public HdrColor SetSaturation ( double saturation )
		{
			HdrColor different = this - Brightness ;

			return different * ( saturation / Saturation ) + Brightness ;
		}

		public Color ToDrawingColor ( ToneMappingAlgorithm mappingAlgorithm = null )
		{
			mappingAlgorithm = mappingAlgorithm ?? KnowToneMapping . Drop ;
			return Color . FromArgb ( byte . MaxValue ,
									mappingAlgorithm ( R ) ,
									mappingAlgorithm ( G ) ,
									mappingAlgorithm ( B ) ) ;
		}

		public static implicit operator HdrColor ( Color color )
		{
			return new HdrColor ( color . R / 255d , color . G / 255d , color . B / 255d ) ;
		}

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Drawing ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public class LinearInterpolationLookupTable : ISelfSerializable
	{

		public ReadOnlyCollection <PointF> Points { get ; }

		private List <PointF> PointsList { get ; }

		public double this [ double x ] => Find ( x ) ;

		public LinearInterpolationLookupTable ( )
		{
			PointsList = new List <PointF> ( ) ;
			Points     = new ReadOnlyCollection <PointF> ( PointsList ) ;
			Sort ( ) ;
		}

		public LinearInterpolationLookupTable ( [NotNull] IEnumerable <PointF> init )
		{
			if ( init == null )
			{
				throw new ArgumentNullException ( nameof ( init ) ) ;
			}

			PointsList = new List <PointF> ( init ) ;
			Points     = new ReadOnlyCollection <PointF> ( PointsList ) ;
		}

		public LinearInterpolationLookupTable ( [NotNull] XElement element )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof ( element ) ) ;
			}

			if ( element . Name != nameof ( LinearInterpolationLookupTable ) )
			{
				throw new ArgumentException (
											ExceptionMessages . XmlNameMismatch (
																				nameof ( element ) ,
																				typeof ( LinearInterpolationLookupTable
																				) ) ) ;
			}

			foreach ( XElement pointData in element . Elements ( ) )
			{
				PointF point = new PointF (
											pointData . ReadNecessaryValue <float> ( nameof ( point . X ) ) ,
											pointData . ReadNecessaryValue <float> ( nameof ( point . Y ) ) ) ;

				PointsList . Add ( point ) ;
			}

			Sort ( ) ;
		}

		public XElement ToXElement ( )
		{
			XElement result = new XElement ( nameof ( LinearInterpolationLookupTable ) ) ;

			foreach ( PointF point in Points )
			{
				XElement pointElement = new XElement ( nameof ( point ) ) ;

				pointElement . SetAttributeValue ( nameof ( point . X ) , point . X ) ;
				pointElement . SetAttributeValue ( nameof ( point . Y ) , point . Y ) ;

				result . Add ( pointElement ) ;
			}

			return result ;
		}

		/// <summary>
		///     Fits a line to a collection of (x,y) points.
		/// </summary>
		/// <param name="xValues">The x-axis values.</param>
		/// <param name="yValues">The y-axis values.</param>
		/// <param name="rSquared">The r^2 value of the line.</param>
		/// <param name="yIntercept">The y-intercept value of the line (i.e. y = ax + b, yIntercept is b).</param>
		/// <param name="slope">The slop of the line (i.e. y = ax + b, slope is a).</param>
		public static void LinearRegression (
			double [ ] xValues ,
			double [ ] yValues ,
			out double rSquared ,
			out double yIntercept ,
			out double slope )
		{
			if ( xValues . Length != yValues . Length )
			{
				throw new Exception ( "Input values should be with the same length." ) ;
			}

			double sumOfX        = 0 ;
			double sumOfY        = 0 ;
			double sumOfXSq      = 0 ;
			double sumOfYSq      = 0 ;
			double sumCodeviates = 0 ;

			for ( int i = 0 ; i < xValues . Length ; i++ )
			{
				double x = xValues [ i ] ;
				double y = yValues [ i ] ;
				sumCodeviates += x * y ;
				sumOfX        += x ;
				sumOfY        += y ;
				sumOfXSq      += x * x ;
				sumOfYSq      += y * y ;
			}

			int    count = xValues . Length ;
			double ssX   = sumOfXSq - ( ( sumOfX * sumOfX ) / count ) ;
			double ssY   = sumOfYSq - ( ( sumOfY * sumOfY ) / count ) ;

			double rNumerator = ( count * sumCodeviates ) - ( sumOfX * sumOfY ) ;
			double rDenom =
				( count * sumOfXSq - ( sumOfX * sumOfX ) ) * ( count * sumOfYSq - ( sumOfY * sumOfY ) ) ;
			double sCo = sumCodeviates - ( ( sumOfX * sumOfY ) / count ) ;

			double meanX = sumOfX     / count ;
			double meanY = sumOfY     / count ;
			double dblR  = rNumerator / Math . Sqrt ( rDenom ) ;

			rSquared   = dblR * dblR ;
			yIntercept = meanY - ( ( sCo / ssX ) * meanX ) ;
			slope      = sCo / ssX ;
		}

		public void AddPoint ( PointF point )
		{
			PointsList . Add ( point ) ;
			Sort ( ) ;
		}

		public void Sort ( ) { PointsList . Sort ( ( left , right ) => left . X . CompareTo ( right . X ) ) ; }

		public double Find ( double x )
		{
			for ( int i = 0 ; i < ( Points . Count - 1 ) ; i++ )
			{
				if ( ( Points [ i ] . X <= x )
					&& ( x              < Points [ i + 1 ] . X ) )
				{
					return ( ( ( Points [ i + 1 ] . Y - Points [ i ] . Y ) * ( x - Points [ i ] . X ) )
							/ ( Points [ i + 1 ] . X - Points [ i ] . X ) )
							+ Points [ i ] . Y ;
				}
			}

			return 0 ;
		}

	}

}

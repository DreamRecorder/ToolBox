using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class RandomExtensions
	{

		public static T NextEnum <T> ( [NotNull] this IRandom random ) where T : struct , Enum
			=> Enum . GetValues <T> ( ) . RandomItem ( random ) ;

		/// <summary>
		///     Generates normally distributed numbers. Each operation makes two Gaussian for the price of one, and apparently
		///     they can be cached or something for better performance, but who cares.
		/// </summary>
		/// <param name="random"></param>
		/// <param name="mu">Mean of the distribution</param>
		/// <param name="sigma">Standard deviation</param>
		/// <returns></returns>
		public static double NextGaussian ( [NotNull] this IRandom random , double mu = 0 , double sigma = 1 )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof ( random ) ) ;
			}

			if ( sigma <= 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( sigma ) ) ;
			}

			double u1 = random . NextDouble ( ) ;
			double u2 = random . NextDouble ( ) ;

			double randStdNormal = Math . Sqrt ( - 2.0 * Math . Log ( u1 ) ) * Math . Sin ( 2.0 * Math . PI * u2 ) ;

			double randNormal = mu + sigma * randStdNormal ;

			return randNormal ;
		}

		/// <summary>
		///     Returns n unique random numbers in the range [0, n], inclusive.
		///     This is equivalent to getting the first n numbers of some random permutation of the sequential numbers from 0 to
		///     max.
		///     Runs in O(k^2) time.
		/// </summary>
		/// <param name="random"></param>
		/// <param name="maxValue">Maximum number possible.</param>
		/// <param name="count">How many numbers to return.</param>
		/// <returns></returns>
		public static List <int> Permutation ( [NotNull] this IRandom random , int maxValue , int count )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof ( random ) ) ;
			}

			if ( count <= 0 )
			{
				throw new ArgumentOutOfRangeException ( nameof ( count ) ) ;
			}

			if ( maxValue < count )
			{
				throw new ArgumentOutOfRangeException ( nameof ( maxValue ) ) ;
			}

			List <int>      result = new List <int> ( count ) ;
			SortedSet <int> sorted = new SortedSet <int> ( ) ;

			for ( int i = 0 ; i < count ; i++ )
			{
				int r = random . Next ( maxValue + 1 - i ) ;

				foreach ( int q in sorted )
				{
					if ( r >= q )
					{
						r++ ;
					}
				}

				result . Add ( r ) ;
				sorted . Add ( r ) ;
			}

			return result ;
		}


		/// <summary>
		///     Generates values from a triangular distribution.
		/// </summary>
		/// <remarks>
		///     See http://en.wikipedia.org/wiki/Triangular_distribution for a description of the triangular probability
		///     distribution and the algorithm for generating one.
		/// </remarks>
		/// <param name="random"></param>
		/// <param name="a">Minimum</param>
		/// <param name="b">Maximum</param>
		/// <param name="c">Mode (most frequent value)</param>
		/// <returns></returns>
		public static double NextTriangular ( [NotNull] this IRandom random , double a , double b , double c )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof ( random ) ) ;
			}

			if ( ! ( a <= c && c <= b ) )
			{
				throw new ArgumentOutOfRangeException (
														$"It should be {nameof ( a )}<={nameof ( c )}<={nameof ( b )}" ) ;
			}

			double u = random . NextDouble ( ) ;

			if ( u < ( c - a ) / ( b - a ) )
			{
				return a + Math . Sqrt ( u * ( b - a ) * ( c - a ) ) ;
			}

			return b - Math . Sqrt ( ( 1 - u ) * ( b - a ) * ( b - c ) ) ;
		}

		/// <summary>
		///     Equally likely to return true or false. Uses
		///     <see cref="Random.Next()" />
		///     .
		/// </summary>
		/// <returns></returns>
		public static bool NextBoolean ( [NotNull] this Random random )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof ( random ) ) ;
			}

			return random . Next ( 2 ) > 0 ;
		}

		/// <summary>
		///     Shuffles a list in O(n) time by using the Fisher-Yates/Knuth algorithm.
		/// </summary>
		/// <param name="random"></param>
		/// <param name="list"></param>
		public static void Shuffle <T> ( [NotNull] this IRandom random , [NotNull] IList <T> list )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof ( random ) ) ;
			}

			if ( list == null )
			{
				throw new ArgumentNullException ( nameof ( list ) ) ;
			}

			for ( int i = 0 ; i < list . Count ; i++ )
			{
				int j = random . Next ( 0 , i + 1 ) ;

				( list [ j ] , list [ i ] ) = ( list [ i ] , list [ j ] ) ;
			}
		}

		public static double NextDoubleBetween ( [NotNull] this IRandom random , double minValue , double maxValue )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof ( random ) ) ;
			}

			if ( ! ( minValue <= maxValue ) )
			{
				throw new ArgumentException ( ) ;
			}

			return minValue + random . NextDouble ( ) * ( maxValue - minValue ) ;
		}

		public static decimal NextDecimalBetween ( [NotNull] this IRandom random , decimal minValue , decimal maxValue )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof ( random ) ) ;
			}

			if ( ! ( minValue <= maxValue ) )
			{
				throw new ArgumentException ( ) ;
			}

			return minValue + Convert . ToDecimal ( random . NextDouble ( ) ) * ( maxValue - minValue ) ;
		}

	}

}

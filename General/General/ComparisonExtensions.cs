using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

using JetBrains.Annotations;

namespace DreamRecorder.ToolBox.General;

[PublicAPI]
public static class ComparisonExtensions
{

	public static T Clamp <T> ( T value , T min , T max ) where T : IComparable <T>
		=> Max ( min , Min ( max , value ) );

	public static Comparison <T> IgnoreSmallDifference <T> ( this T proportion ) where T : INumber <T>
	{
		return ( ( x , y ) =>
				 {
					 if ( T.Abs ( x - y ) < T.Max ( x , y ) * proportion )
					 {
						 return 0;
					 }
					 else
					 {
						 return Comparer <T>.Default.Compare ( x , y );
					 }
				 } );
	}

	public static Comparison <T> IgnoreSmallDifferenceByAbsoluteValue <T> ( this T absoluteValue ) where T : INumber <T>
	{
		return ( ( x , y ) =>
				 {
					 if ( T.Abs ( x - y ) < absoluteValue )
					 {
						 return 0;
					 }
					 else
					 {
						 return Comparer <T>.Default.Compare ( x , y );
					 }
				 } );
	}

	public static T Max <T> ( T x , T y ) where T : IComparable <T> => x.CompareTo ( y ) > 0 ? x : y;

	public static T Min <T> ( T x , T y ) where T : IComparable <T> => x.CompareTo ( y ) < 0 ? x : y;

	public static Comparison <TSource> Select
		<TSource , TResult> ( Func <TSource , TResult> selector , Comparison <TResult> comparison = null )
	{
		return ( x , y ) => ( comparison ?? Comparer <TResult>.Default.Compare ) ( selector ( x ) , selector ( y ) );
	}

	public static Comparer <T> ToComparer <T> ( this Comparison <T> comparison ) => Comparer <T>.Create ( comparison );

	public static Comparison <T> Union <T> ( this Comparison <T> comparison1 , Comparison <T> comparison2 )
	{
		return ( x , y ) =>
			   {
				   int result = comparison1 ( x , y );

				   if ( result == 0 )
				   {
					   return comparison2 ( x , y );
				   }

				   return result;
			   };
	}

}

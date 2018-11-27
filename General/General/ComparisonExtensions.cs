using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class ComparisonExtensions
	{

		public static Comparison <T> Union <T> ( this Comparison <T> comparison1 , Comparison <T> comparison2 )
		{
			return ( x , y ) =>
					{
						int result = comparison1 ( x , y ) ;
						if ( result == 0 )
						{
							return comparison2 ( x , y ) ;
						}

						return result ;
					} ;
		}

		public static Comparison <T> Union <T> ( this Comparison <T> comparison , Comparer <T> comparer )
		{
			return ( x , y ) =>
					{
						int result = comparison ( x , y ) ;
						if ( result == 0 )
						{
							return comparer . Compare ( x , y ) ;
						}

						return result ;
					} ;
		}

	}

}

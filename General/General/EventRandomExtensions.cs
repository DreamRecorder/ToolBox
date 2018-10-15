using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public static class EventRandomExtensions
	{

		public static bool InvokeEvent ( this Random random , NormalValue possibility )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof(random) ) ;
			}

			return random . NextNormalValue ( ) <= possibility ;
		}

		public static NormalValue NextNormalValue ( this Random random )
		{
			return random . Next ( NormalValue . MaxValue + 1 ) ;
		}

		public static NormalValue NextNormalValue ( this Random random ,
													NormalValue lowerBound ,
													NormalValue higherBound )
		{
			return random . Next ( lowerBound , higherBound + 1 ) ;
		}

		public static NormalValue NextNormalValue ( this Random random , NormalValue lowerBound )
		{
			return random . Next ( lowerBound , NormalValue . MaxValue + 1 ) ;
		}

	}

}

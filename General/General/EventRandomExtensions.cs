using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class EventRandomExtensions
	{

		public static bool InvokeEvent ( this IRandom random , NormalValue possibility )
		{
			if ( random == null )
			{
				throw new ArgumentNullException ( nameof ( random ) ) ;
			}

			return random . NextNormalValue ( ) <= possibility ;
		}

		public static NormalValue NextNormalValue ( this IRandom random )
		{
			return random . Next ( NormalValue . MaxValue + 1 ) ;
		}

		public static NormalValue NextNormalValue (
			this IRandom random ,
			NormalValue  lowerBound ,
			NormalValue  higherBound )
		{
			return random . Next ( lowerBound , higherBound + 1 ) ;
		}

		public static NormalValue NextNormalValue ( this IRandom random , NormalValue lowerBound )
		{
			return random . Next ( lowerBound , NormalValue . MaxValue + 1 ) ;
		}

	}

}

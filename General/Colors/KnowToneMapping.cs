using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Colors
{

	public static class KnowToneMapping
	{

		public static byte Drop ( double value )
		{
			value = Math . Max ( 0 , value ) ;
			value = Math . Min ( 1 , value ) ;

			return Convert . ToByte ( value * 255 ) ;
		}

		public static byte AcesMapping ( double value )
		{
			value = Math . Max ( 0 , value ) ;

			const float a = 2.51f ;
			const float b = 0.03f ;
			const float c = 2.43f ;
			const float d = 0.59f ;
			const float e = 0.14f ;

			return ( byte ) ( value
						* ( a * value + b )
						/ ( value * ( c * value + d ) + e )
						* 255 ) ;
		}

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Numerics ;

namespace DreamRecorder . ToolBox . Renderer
{

	public class ObliqueProjector : IProjector
	{

		public float Height { get ; set ; }

		public Vector3 CenterAt { get ; set ; }

		public float ScreenWidth { get ; set ; }

		public float WorldWidth { get ; set ; }

		//public readonly 

		public Vector2 Project ( Vector3 point )
		{
			Vector3 relativePoint = point - CenterAt ;
			Vector2 result = new Vector2 ( ( relativePoint . X - relativePoint . Y / 2 ) * ScreenWidth / WorldWidth ,
											- ( relativePoint . Z - relativePoint . Y / 2 )
											* ScreenWidth
											/ WorldWidth ) ;
			return result ;
		}

		public Ray Project ( Vector2 point )
		{
			Vector3 sourcePoint = new Vector3 ( point . X + point . Y + Height , ( point . Y + Height ) * 2 , Height ) ;

			return new Ray ( sourcePoint + CenterAt , new Vector3 ( - Height , - Height * 2 , - Height ) ) ;
		}

	}

}

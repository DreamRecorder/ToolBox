using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Numerics ;

using DreamRecorder . ToolBox . General ;

namespace DreamRecorder . ToolBox . Renderer
{

	public class IsometricProjector : IProjector
	{

		public float ScreenWidth { get ; set ; }

		public float WorldWidth { get ; set ; }

		public Vector2 Project ( Vector3 point )
		{
			Vector2 result = new Vector2 ( ( point . X - point . Y ) * Constants . Sqrt3F / 2 ,
											- ( point . Z - ( point . X + point . Y ) / 2 )  ) ;
			return result ;
		}

		public Ray Project ( Vector2 point ) { throw new NotImplementedException ( ) ; }

	}

}

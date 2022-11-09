using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Numerics ;

namespace DreamRecorder . ToolBox . Renderer
{

	public class PinholeCamera : Camera
	{

		protected override Vector2 CalculateProject ( Vector3 point )
			=> new Vector2 ( point . X / point . Z , point . Y / point . Z ) ;

		protected override Vector3 CalculateProject ( Vector2 point )
		{
			float x = ( float )HalfFovTan * point . X / ScreenWidth ;
			float y = ( float )HalfFovTan * point . Y / ScreenWidth ;

			return x * Right + y * Up + Forward ;
		}

	}

}

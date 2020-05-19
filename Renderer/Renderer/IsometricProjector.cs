using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Numerics ;

using DreamRecorder . ToolBox . General ;

namespace DreamRecorder . ToolBox . Renderer
{

	public class IsometricProjector : Projector
	{

		public override Vector3 Direction => new Vector3 ( - 0.5f , - 0.5f , - 1f ) ;

		protected override Vector2 CalculateProject ( Vector3 relativePoint )
		{
			return new Vector2 (
								( relativePoint . X - relativePoint . Y ) * Constants . Sqrt3F / 2 ,
								- ( relativePoint . Z - ( relativePoint . X + relativePoint . Y ) / 2 ) ) ;
		}

		protected override Vector3 CalculateProject ( Vector2 point )
		{
			return new Vector3 (
								point . X / Constants . Sqrt3F + point . Y ,
								point . Y                      - point . X / Constants . Sqrt3F ,
								0f ) ;
		}

	}

}

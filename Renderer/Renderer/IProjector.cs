using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Numerics ;

namespace DreamRecorder . ToolBox . Renderer
{

	public interface IProjector
	{

		float ScreenWidth { get ; set ; }

		Ray Project ( Vector2 point ) ;

		Vector2 Project ( Vector3 point ) ;

	}

}

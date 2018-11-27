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

		float WorldWidth { get ; set ; }

		Vector2 Project ( Vector3 point ) ;

		Ray Project ( Vector2 point ) ;

	}

}

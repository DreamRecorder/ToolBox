using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Numerics ;

namespace DreamRecorder . ToolBox . Renderer
{

	public interface ICamera : IProjector
	{

		Vector3 Position { get ; set ; }

		Vector3 LookAt { get ; set ; }

	}

}

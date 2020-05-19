using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Numerics ;

namespace DreamRecorder . ToolBox . Renderer
{

	public static class RayTransformExtension
	{

		public static Ray Transform ( this Ray source , Matrix4x4 matrix )
			=> new Ray (
						Vector3 . Transform ( source . StartPosition , matrix ) ,
						Vector3 . Transform ( source . Direction ,     matrix ) ) ;

	}

}

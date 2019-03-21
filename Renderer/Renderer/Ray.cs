using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Numerics ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Renderer
{

	[PublicAPI]
	public struct Ray
	{

		public Vector3 Direction { get ; }

		public Vector3 StartPosition { get ; }

		public Ray ( Vector3 startPosition , Vector3 direction )
		{
			StartPosition = startPosition ;
			Direction     = Vector3 . Normalize ( direction ) ;
		}

	}

}

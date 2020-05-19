using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Numerics ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Renderer
{

	[PublicAPI]
	public abstract class Projector : IProjector
	{

		public float Height { get ; set ; }

		public Vector3 CenterAt { get ; set ; }

		public float WorldWidth { get ; set ; }

		public abstract Vector3 Direction { get ; }

		public float ScreenWidth { get ; set ; }

		public Vector2 Project ( Vector3 point )
			=> CalculateProject ( point - CenterAt ) * ScreenWidth / WorldWidth ;

		public Ray Project ( Vector2 point )
		{
			Vector3 sourceCenter = CenterAt - Direction / Direction . Z * Height ;

			return new Ray (
							CalculateProject ( point ) / ScreenWidth * WorldWidth + sourceCenter ,
							Direction ) ;
		}

		protected abstract Vector2 CalculateProject ( Vector3 relativePoint ) ;

		protected abstract Vector3 CalculateProject ( Vector2 point ) ;

	}

}

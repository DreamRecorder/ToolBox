using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Numerics ;

using DreamRecorder . ToolBox . Renderer ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace DreamRecorder . ToolBox . UnitTest
{

	[TestClass]
	public class ProjectorTests
	{

		[TestMethod]
		public void IsometricProjectorTest ( )
		{
			IsometricProjector projector = new IsometricProjector ( ) ;

			projector . Project ( Vector3 . Zero ) ;
		}

		[TestMethod]
		public void ObliqueProjectorTest ( )
		{
			ObliqueProjector projector = new ObliqueProjector ( ) ;

			projector . Project ( Vector3 . Zero ) ;
		}

		[TestMethod]
		public void ProjectTest ( ) { }

	}

}

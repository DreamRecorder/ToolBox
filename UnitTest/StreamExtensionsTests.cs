using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace DreamRecorder . ToolBox . UnitTest
{

	[TestClass]
	public class StreamExtensionsTests
	{

		[TestMethod]
		public void ReadToFillBufferTest1 ( )
		{
			byte [ ] sourceBuffer = new byte [ 128 ] ;
			StaticRandom . Current . NextBytes ( sourceBuffer ) ;

			MemoryStream memoryStream = new MemoryStream ( sourceBuffer ) ;

			memoryStream . Position = 0 ;

			byte [ ]    destinationBuffer = new byte[ 128 ] ;
			Span <byte> buffer            = new Span <byte> ( destinationBuffer ) ;

			Assert . IsTrue ( memoryStream . ReadToFillBuffer ( buffer ) ) ;

			for ( int i = 0 ; i < destinationBuffer . Length ; i++ )
			{
				Assert . AreEqual ( sourceBuffer [ i ] , destinationBuffer [ i ] ) ;
			}
		}

		[TestMethod]
		public void ReadToFillBufferTest2 ( )
		{
			byte [ ] sourceBuffer = new byte[ 128 ] ;
			StaticRandom . Current . NextBytes ( sourceBuffer ) ;

			MemoryStream memoryStream = new MemoryStream ( sourceBuffer ) ;

			memoryStream . Position = 0 ;

			byte [ ]    destinationBuffer = new byte[ 64 ] ;
			Span <byte> buffer            = new Span <byte> ( destinationBuffer ) ;

			Assert . IsTrue ( memoryStream . ReadToFillBuffer ( buffer ) ) ;

			for ( int i = 0 ; i < destinationBuffer . Length ; i++ )
			{
				Assert . AreEqual ( sourceBuffer [ i ] , destinationBuffer [ i ] ) ;
			}

			Assert . AreEqual ( memoryStream . Position , 64 ) ;
		}

	}

}

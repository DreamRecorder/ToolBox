using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;
using DreamRecorder . ToolBox . Network ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace DreamRecorder . ToolBox .UnitTest
{
	[TestClass()]
	public class TcpServerTests
	{

		[TestMethod]
		public void Restart ( )
		{
			TcpServer server =new TcpServer(0);
			( ( IStartStop )server ) . Start ( ) ;
			( ( IStartStop )server ) . Stop ( ) ;
			( ( IStartStop )server ) . Start ( ) ;
			( ( IStartStop )server ) . Stop ( ) ;
		}

	}
}
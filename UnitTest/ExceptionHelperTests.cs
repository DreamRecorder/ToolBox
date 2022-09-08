using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace DreamRecorder . ToolBox .UnitTest
{
	[TestClass()]
	public class ExceptionHelperTests
	{


		[TestMethod()]
		public void SuccessTest()
		{
		
		}

		public object ErrorObject()=>throw	new Exception();
		public object PassObject()=>new object();

		[TestMethod()]
		public void IgnoreExceptionTest()
		{
			Assert . IsNull ( ExceptionHelper . IgnoreException ( ErrorObject ) ) ;
			Assert . IsNotNull ( ExceptionHelper . IgnoreException ( PassObject ) ) ;
		}

		public int ErrorInt ( ) => throw new Exception ( ) ;

		public int PassInt ( ) => default ;

		[TestMethod()]
		public void IgnoreExceptionTest1()
		{
			Assert.IsNull(ExceptionHelper.IgnoreException(ErrorInt));
			Assert.AreEqual(ExceptionHelper.IgnoreException(PassInt),default(int));
		}

		[TestMethod()]
		public void XmlNameMismatchTest()
		{

		}
	}
}
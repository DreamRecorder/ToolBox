using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace DreamRecorder . ToolBox . UnitTest
{

	[TestClass]
	public class ByteBooleanExtensionsTests
	{

		[TestMethod]
		public void ToBooleanArrayTest ( )
		{
			Assert . AreEqual (
								0b0000_0001 ,
								new [ ] { true , false , false , false , false , false , false , false } .
									ToByte ( ) ) ;
			Assert . AreEqual (
								0b0000_1000 ,
								new [ ] { false , false , false , true , false , false , false , false } .
									ToByte ( ) ) ;
			Assert . AreEqual (
								0b0001_0000 ,
								new [ ] { false , false , false , false , true , false , false , false } .
									ToByte ( ) ) ;
			Assert . AreEqual (
								0b1000_0000 ,
								new [ ] { false , false , false , false , false , false , false , true } .
									ToByte ( ) ) ;

			Assert . AreEqual (
								new [ ] { true , true , true , true , true , true , true , true } . ToByte ( ) ,
								0b1111_1111 ) ;
			Assert . AreEqual (
								new [ ] { false , false , false , false , false , false , false , false } . ToByte ( ) ,
								0b0000_0000 ) ;

			Assert . ThrowsException <ArgumentException> ( ( ) => { new bool [ ] { } . ToByte ( ) ; } ) ;
			Assert . ThrowsException <ArgumentException> ( ( ) => { new [ ] { false , true } . ToByte ( ) ; } ) ;
		}

		[TestMethod]
		public void ToByteArrayTest ( ) { }

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace DreamRecorder . ToolBox . UnitTest
{

	[TestClass]
	public class RandomExtensionsTest
	{

		[TestMethod]
		[ExpectedException ( typeof ( InvalidOperationException ) )]
		public void EmptyListRandomItemTest ( )
		{
			List <object> tester = new List <object> ( ) ;
			object        _      = tester . RandomItem ( ) ;
		}

		[TestMethod]
		[ExpectedException ( typeof ( ArgumentNullException ) )]
		public void NullListRandomItemTest ( ) { ListItemRandomExtensions . RandomItem <object> ( null ) ; }

	}

}

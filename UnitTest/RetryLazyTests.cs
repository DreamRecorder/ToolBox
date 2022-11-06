using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

using DreamRecorder . ToolBox . General ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace DreamRecorder . ToolBox . UnitTest
{

	[TestClass]
	public class RetryLazyTests
	{

		private int count ;

		private Test RetryTest ( )
		{
			if ( ++count > 5 )
			{
				if ( count > 6 )
				{
					Assert . Fail ( ) ;
				}

				return new Test ( count ) ;
			}
			else
			{
				return null ;
			}
		}

		[TestMethod]
		public void RetryLazyTest ( )
		{
			count = 0 ;
			RetryLazy <Test> lazy = new RetryLazy <Test> ( RetryTest ) ;
			Parallel . For ( 0 , Environment . ProcessorCount * 8 , _ => lazy . GetValue ( ) ) ;
			Assert . AreEqual ( 6 , count ) ;
		}

		public class Test
		{

			public int Value { get ; set ; }

			public Test ( int value ) => Value = value ;

		}

	}

}

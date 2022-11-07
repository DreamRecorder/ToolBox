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

		private int count1 ;

		private int count2 ;

		private Test RetryTest ( )
		{
			if ( ++count1 > 5 )
			{
				if ( count1 > 6 )
				{
					Assert . Fail ( ) ;
				}

				return new Test ( count1 ) ;
			}
			else
			{
				return null ;
			}
		}

		[TestMethod]
		public void RetryLazyTest ( )
		{
			count1 = 0 ;
			RetryLazy <Test> lazy = new RetryLazy <Test> ( RetryTest ) ;
			Parallel . For ( 0 , Environment . ProcessorCount * 8 , _ => lazy . GetValue ( ) ) ;
			Assert . AreEqual ( 6 , count1 ) ;
		}

		private Test RecursionRetryTest ( )
		{
			Assert . IsTrue ( count2++ == 0 ) ;
			return new Test ( count2 ) ;
		}

		[TestMethod]
		public void RetryLazyRecursionTest ( )
		{
			count2 = 0 ;
			RetryLazy <Test> lazy = null ;
			lazy = new RetryLazy <Test> (
										RecursionRetryTest ,
										result =>
										{
											Assert . IsNotNull ( lazy ? . GetValue ( ) ) ;
											Assert . AreSame ( result , lazy ? . GetValue ( ) ) ;
										} ) ;
		}

		public class Test
		{

			public int Value { get ; set ; }

			public Test ( int value ) => Value = value ;

		}

	}

}

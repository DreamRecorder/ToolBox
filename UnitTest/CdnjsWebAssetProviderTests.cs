using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Linq ;
using System . Threading . Tasks ;

using DreamRecorder . ToolBox . AspNet . General ;

using Microsoft.VisualStudio.TestTools.UnitTesting ;

namespace DreamRecorder . ToolBox .UnitTest
{
	[TestClass()]
	public class CdnjsWebAssetProviderTests
	{
		[TestMethod()]
		public async Task GetFileUrlTest()
		{
			CdnjsWebAssetProvider assetProvider = new CdnjsWebAssetProvider ( ) ;

			string url=await assetProvider . GetFileUrl ( "font-awesome" , "css/all.min.css" , null ) ;

			Assert.IsNotNull ( url ) ;
		}
	}
}
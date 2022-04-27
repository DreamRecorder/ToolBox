using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . Specialized ;
using System . ComponentModel ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace DreamRecorder . ToolBox . UnitTest
{

	[TestClass]
	public class DelegateExtensionsTests
	{

		private void StubHandler ( object sender , object e )
		{
			Console . WriteLine ( ( sender as Type ) ? . AssemblyQualifiedName ) ;
		}

		[TestMethod]
		public void ConvertToTest ( )
		{
			Action <object , object> action = StubHandler ;

			action . ConvertTo <EventHandler> ( ) . Invoke ( typeof ( EventHandler ) , null ) ;
			action . ConvertTo <NotifyCollectionChangedEventHandler> ( ) .
					Invoke ( typeof ( NotifyCollectionChangedEventHandler ) , null ) ;
			action . ConvertTo <PropertyChangedEventHandler> ( ) .
					Invoke ( typeof ( PropertyChangedEventHandler ) , null ) ;
		}

	}

}

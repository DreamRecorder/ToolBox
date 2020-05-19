using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Runtime . Serialization ;
using System . Xml . Linq ;

using DreamRecorder . ToolBox . General ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace DreamRecorder . ToolBox . UnitTest
{

	[TestClass]
	public class SerializableTests
	{

		[TestMethod]
		public void DataContractSerializableTest ( )
		{
			string result = new DataContractTestStub ( ) . Serialize ( ) ;
			Console . WriteLine ( result ) ;
			Assert . AreEqual (
								result ,
								result . Deserialize <DataContractTestStub> ( ) . Serialize ( ) ) ;
		}

		[TestMethod]
		public void SelfSerializableTest ( )
		{
			string result = new SelfSerializableTestStub ( ) . Serialize ( ) ;
			Console . WriteLine ( result ) ;

			Assert . AreEqual (
								result ,
								result . Deserialize <SelfSerializableTestStub> ( ) .
										Serialize ( ) ) ;
		}

		[TestMethod]
		public void XmlSerializableTest ( )
		{
			string result = new XmlTestStub ( ) . Serialize ( ) ;
			Console . WriteLine ( result ) ;
			Assert . AreEqual ( result , result . Deserialize <XmlTestStub> ( ) . Serialize ( ) ) ;
		}

		[DataContract]
		public class DataContractTestStub
		{

			[DataMember]
			public string Name { get ; set ; } = "DataContractTest" ;

		}

		public class SelfSerializableTestStub : ISelfSerializable
		{

			public SelfSerializableTestStub ( ) { }

			public SelfSerializableTestStub ( XElement element ) { }

			public XElement ToXElement ( )
			{
				XElement element = new XElement ( nameof ( SelfSerializableTestStub ) ) ;
				element . SetAttributeValue ( "Name" , "SelfSerializableTest" ) ;

				return element ;
			}

		}

		public class XmlTestStub
		{

			public string Name { get ; set ; } = "Xml" ;

		}

	}

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DreamRecorder.ToolBox.General;

namespace DreamRecorder.ToolBox.UnitTest;

[TestClass]
public class BytesCountToHumanStringExtensionsTests
{

	[TestMethod]
	public void SignedBytesCountToHumanStringTest ( )
	{
		Assert.AreEqual ( "0B" ,   0L.BytesCountToHumanString ( ) );
		Assert.AreEqual ( "1B" ,   1L.BytesCountToHumanString ( ) );
		Assert.AreEqual ( "1KiB" , 1024L.BytesCountToHumanString ( ) );
		Assert.AreEqual ( "1MiB" , ( 1024L * 1024L ).BytesCountToHumanString ( ) );
		Assert.AreEqual ( "1GiB" , ( 1024L * 1024L * 1024L ).BytesCountToHumanString ( ) );
		Assert.AreEqual ( "1TiB" , ( 1024L * 1024L * 1024L * 1024L ).BytesCountToHumanString ( ) );
		Assert.AreEqual ( "1PiB" , ( 1024L * 1024L * 1024L * 1024L * 1024L ).BytesCountToHumanString ( ) );
	}

	[TestMethod]
	public void UnsignedBytesCountToHumanStringTest ( )
	{
		Assert.AreEqual ( "0B" ,   0UL.BytesCountToHumanString ( ) );
		Assert.AreEqual ( "1B" ,   1UL.BytesCountToHumanString ( ) );
		Assert.AreEqual ( "1KiB" , 1024UL.BytesCountToHumanString ( ) );
		Assert.AreEqual ( "1MiB" , ( 1024UL * 1024UL ).BytesCountToHumanString ( ) );
		Assert.AreEqual ( "1GiB" , ( 1024UL * 1024UL * 1024UL ).BytesCountToHumanString ( ) );
		Assert.AreEqual ( "1TiB" , ( 1024UL * 1024UL * 1024UL * 1024UL ).BytesCountToHumanString ( ) );
		Assert.AreEqual ( "1PiB" , ( 1024UL * 1024UL * 1024UL * 1024UL * 1024UL ).BytesCountToHumanString ( ) );
	}

}

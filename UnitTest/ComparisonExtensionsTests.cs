using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DreamRecorder.ToolBox.General;

namespace DreamRecorder.ToolBox.UnitTest
{
	[TestClass()]
	public class ComparisonExtensionsTests
	{
		[TestMethod()]
		public void MinTest()
		{
			Assert.AreEqual(1, ComparisonExtensions.Min(1, 2));
			Assert.AreEqual(1, ComparisonExtensions.Min(2, 1));
			Assert.AreEqual(1, ComparisonExtensions.Min(1, 1));
		}

		[TestMethod()]
		public void MaxTest()
		{
			Assert.AreEqual(2, ComparisonExtensions.Max(1, 2));
			Assert.AreEqual(2, ComparisonExtensions.Max(2, 1));
			Assert.AreEqual(1, ComparisonExtensions.Max(1, 1));
		}

		[TestMethod()]
		public void ClampTest()
		{
			Assert.AreEqual(1, ComparisonExtensions.Clamp(1, 0, 2));
			Assert.AreEqual(0, ComparisonExtensions.Clamp(-1, 0, 2));
			Assert.AreEqual(2, ComparisonExtensions.Clamp(3, 0, 2));
		}
	}
}
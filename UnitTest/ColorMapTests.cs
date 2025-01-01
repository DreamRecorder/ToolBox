using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DreamRecorder.ToolBox.Colors.ColorMap;

namespace DreamRecorder.ToolBox.UnitTest;

[TestClass]
public class ColorMapTests
{

	[TestMethod]
	public void GetValueTest ( )
	{
		List <ColorMap> colorMaps = typeof ( ColorMap ).Assembly.GetTypes ( ).
														Where (
															   t => ( ! t.IsAbstract )
																	&& t.IsAssignableTo ( typeof ( ColorMap ) ) ).
														Select ( Activator.CreateInstance ).
														Cast <ColorMap> ( ).
														ToList ( );

		foreach ( ColorMap colorMap in colorMaps )
		{
			colorMap.Map(0.0);
			colorMap.Map(1.0);
			colorMap.Map(-1.0);
			for ( int i = 0 ; i < 255 ; i++ )
			{
				colorMap.Map(Random.Shared.NextDouble());
			}
		}
	}

}

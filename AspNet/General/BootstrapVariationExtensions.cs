using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.AspNet.General;

public static class BootstrapVariationExtensions
{

	public static string ToCssClassPostfix ( this BootstrapVariation variation ) => variation.ToString ( ).ToLower ( );

}

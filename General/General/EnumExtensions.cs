using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace DreamRecorder.ToolBox.General;

[PublicAPI]
public static class EnumExtensions
{

	public static T Random <T> ( IRandom random = null ) where T : struct , Enum
		=> Enum.GetValues <T> ( ).RandomItem ( random );

}

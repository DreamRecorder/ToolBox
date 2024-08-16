using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Colors.ColorMap;

public abstract class ColorMap
{

	public HdrColor Map ( double value ) => MapOverride ( value );

	protected abstract HdrColor MapOverride ( double value );

}

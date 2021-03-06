﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Colors . ColorMap
{

	public abstract class ColorMap
	{

		protected abstract HdrColor MapOverride ( double value ) ;

		public HdrColor Map ( double value ) => MapOverride ( value ) ;

	}

}

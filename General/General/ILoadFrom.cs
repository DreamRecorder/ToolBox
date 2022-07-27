﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public interface ILoadFrom <T> : IToT <T>
	{

		void LoadFrom ( T value ) ;

	}

}

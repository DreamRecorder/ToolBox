﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	/// <summary>
	///     Point out any method should be called before using this lib
	/// </summary>
	[AttributeUsage ( AttributeTargets . Method | AttributeTargets . Assembly , Inherited = false )]
	public sealed class PrepareAttribute : Attribute
	{

	}

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;

namespace DreamRecorder.ToolBox.General;

public static class StaticServiceProvider
{

	public static IServiceProvider Provider { get; private set; }

	public static IServiceCollection ServiceCollection { get; set; } = new ServiceCollection ( );

	public static void Update ( )
	{
		lock ( ServiceCollection )
		{
			Provider = ServiceCollection.BuildServiceProvider ( true );
		}
	}

}

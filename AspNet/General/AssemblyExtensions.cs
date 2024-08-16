using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using DreamRecorder.ToolBox.General;

using JetBrains.Annotations;

namespace DreamRecorder.ToolBox.AspNet.General;

[PublicAPI]
public static class AssemblyExtensions
{

	public static string GetWebTitle ( [NotNull] this Assembly assembly )
	{
		if ( assembly == null )
		{
			throw new ArgumentNullException ( nameof ( assembly ) );
		}

		WebTitleAttribute attribute = assembly.GetCustomAttribute <WebTitleAttribute> ( );

		return attribute?.Name ?? assembly.GetDisplayName ( );
	}

}

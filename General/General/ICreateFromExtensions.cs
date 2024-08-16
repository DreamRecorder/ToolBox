using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.General;

public static class ICreateFromExtensions
{

	public static IEnumerable <T> CreateFromList <T , TSource> ( this IEnumerable <TSource> sources )
		where T : ICreateFrom <T , TSource>
		=> sources.Select ( T.CreateFrom );

}

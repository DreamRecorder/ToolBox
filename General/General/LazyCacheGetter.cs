using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DreamRecorder.ToolBox.General;

public static class LazyCacheGetter
{

	private static readonly ConditionalWeakTable <object , IDictionary <string , object>> Instances =
		new ConditionalWeakTable <object , IDictionary <string , object>> ( );

	public static TProp Lazy <TProp> (
		this Type                 target ,
		Func <TProp>              valueFactory ,
		[CallerMemberName] string propertyName = default )
	{
		TProp result = default;
		if ( target is not null
			 && propertyName is not null )
		{
			if ( ! Instances.TryGetValue ( target , out IDictionary <string , object> cache )
				 || cache is null )
			{
				cache = new ConcurrentDictionary <string , object> ( );
				Instances.Add ( target , cache );
			}

			if ( ! cache.TryGetValue ( propertyName , out object cachedValue ) )
			{
				cache [ propertyName ] = ( result = valueFactory ( ) );
			}
			else
			{
				result = ( TProp )cachedValue;
			}
		}

		return result;
	}

	public static TProp Lazy <T , TProp> (
		this T                    target ,
		Func <TProp>              valueFactory ,
		[CallerMemberName] string propertyName = default )
	{
		TProp result = default;
		if ( target is not null
			 && propertyName is not null )
		{
			if ( ! Instances.TryGetValue ( target , out IDictionary <string , object> cache )
				 || cache is null )
			{
				cache = new ConcurrentDictionary <string , object> ( );
				Instances.Add ( target , cache );
			}

			if ( ! cache.TryGetValue ( propertyName , out object cachedValue ) )
			{
				cache [ propertyName ] = ( result = valueFactory ( ) );
			}
			else
			{
				result = ( TProp )cachedValue;
			}
		}

		return result;
	}

}

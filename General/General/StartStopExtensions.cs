using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General ;

public static class StartStopExtensions
{

	public static void StartAll ( this IEnumerable <IStartStop> startStops )
	{
		foreach ( IStartStop startStop in startStops )
		{
			startStop . Start ( ) ;
		}
	}

	public static void StartMembers ( [NotNull] this IStartStop startStop )
	{
		if ( startStop == null )
		{
			throw new ArgumentNullException ( nameof ( startStop ) ) ;
		}

		List <PropertyInfo> readable = startStop . GetType ( ) .
												   GetProperties ( ) .
												   Where (
														  p
															  => p . CanRead
																 && ( ! p . GetAccessors ( ) .
																			Any ( m => m . IsStatic ) ) ) .
												   ToList ( ) ;

		foreach ( PropertyInfo propertyInfo in readable )
		{
			if ( ExceptionHelper . IgnoreException ( ( ) => propertyInfo . GetValue ( startStop ) ) is IStartStop ss )
			{
				ss . Start ( ) ;
			}
		}
	}

	public static void StopAll ( this IEnumerable <IStartStop> startStops )
	{
		foreach ( IStartStop startStop in startStops )
		{
			startStop . Stop ( ) ;
		}
	}

	public static void StopMembers ( [NotNull] this IStartStop startStop )
	{
		if ( startStop == null )
		{
			throw new ArgumentNullException ( nameof ( startStop ) ) ;
		}

		List <PropertyInfo> readable = startStop . GetType ( ) .
												   GetProperties ( ) .
												   Where (
														  p
															  => p . CanRead
																 && ( ! p . GetAccessors ( ) .
																			Any ( m => m . IsStatic ) ) ) .
												   ToList ( ) ;

		foreach ( PropertyInfo propertyInfo in readable )
		{
			if ( ExceptionHelper . IgnoreException ( ( ) => propertyInfo . GetValue ( startStop ) ) is IStartStop ss )
			{
				ss . Stop ( ) ;
			}
		}
	}

}

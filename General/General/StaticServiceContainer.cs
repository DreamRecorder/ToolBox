using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading ;

using Microsoft . Extensions . DependencyInjection ;

namespace DreamRecorder . ToolBox . General
{

	public static class StaticServiceProvider
	{

		public static IServiceProvider Provider { get ; private set ; }

		public static IServiceCollection ServiceCollection { get ; set ; } =
			new ServiceCollection ( ) ;

		public static void Update ( )
		{
			bool notFinish = true ;
			while ( notFinish )
			{
				try
				{
					lock ( ServiceCollection )
					{
						Provider = ServiceCollection . BuildServiceProvider ( true ) ;
					}

					notFinish = false ;
				}
				catch ( Exception )
				{
					Thread . Yield ( ) ;
					Thread . Sleep ( 1 ) ;
				}
			}
		}

	}

}

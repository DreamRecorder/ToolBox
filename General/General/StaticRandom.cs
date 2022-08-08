using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using Microsoft . Extensions . DependencyInjection ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class StaticRandom 
	{
		public static IRandom Current { get ; } = (SystemRandomWrapper)Random.Shared ;

		[Prepare]
		public static void StartUp ( )
		{
			StaticServiceProvider . ServiceCollection . AddSingleton <IRandom> ( Current ) ;
		}

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using Microsoft . Extensions . DependencyInjection ;

using Pcg ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public class StaticRandom :  IRandom
	{

		public static StaticRandom Current { get ; }=new StaticRandom();

		private StaticRandom ( ) { }

		private PcgRandom Random{ get; }=new PcgRandom ();

		public int Next ( )
		{
			lock (Random)
			{
				return Random. Next ( ) ;
			}
		}

		public int Next ( int maxValue )
		{
			lock (Random)
			{
				return Random. Next ( maxValue ) ;
			}
		}

		public int Next ( int minValue , int maxValue )
		{
			lock (Random)
			{
				return Random. Next ( minValue , maxValue ) ;
			}
		}

		public void NextBytes ( byte [ ] buffer )
		{
			lock (Random)
			{
				Random. NextBytes ( buffer ) ;
			}
		}

		public double NextDouble ( )
		{
			lock (Random)
			{
				return Random. NextDouble ( ) ;
			}
		}

		[Prepare]
		public static void StartUp ( )
		{
			StaticServiceProvider . ServiceCollection . AddSingleton <IRandom> ( Current ) ;
		}

	}

}

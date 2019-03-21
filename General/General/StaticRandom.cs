using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using Microsoft . Extensions . DependencyInjection ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public class StaticRandom : Random , IRandom
	{

		public static StaticRandom Current { get ; set ; }

		public StaticRandom ( ) { }

		public StaticRandom ( int seed ) : base ( seed ) { }

		public override int Next ( )
		{
			lock ( this )
			{
				return base . Next ( ) ;
			}
		}

		public override int Next ( int maxValue )
		{
			lock ( this )
			{
				return base . Next ( maxValue ) ;
			}
		}

		public override int Next ( int minValue , int maxValue )
		{
			lock ( this )
			{
				return base . Next ( minValue , maxValue ) ;
			}
		}

		public override void NextBytes ( byte [ ] buffer )
		{
			lock ( this )
			{
				base . NextBytes ( buffer ) ;
			}
		}

		public override double NextDouble ( )
		{
			lock ( this )
			{
				return base . NextDouble ( ) ;
			}
		}

		[Prepare]
		public static void StartUp ( )
		{
			Current = new StaticRandom ( ) ;
			StaticServiceProvider . ServiceCollection . AddSingleton <IRandom> ( Current ) ;
		}

	}

}

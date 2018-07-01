using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox
{

	public class StaticRandom : Random
	{

		private readonly Random _random = new Random ( ) ;

		public static Random Current { get ; set ; } = new StaticRandom ( ) ;

		public override int Next ( )
		{
			lock ( _random )
			{
				return _random . Next ( ) ;
			}
		}

		public override int Next ( int maxValue )
		{
			lock ( _random )
			{
				return _random . Next ( maxValue ) ;
			}
		}

		public override int Next ( int minValue , int maxValue )
		{
			lock ( _random )
			{
				return _random . Next ( minValue , maxValue ) ;
			}
		}

		public override void NextBytes ( byte [ ] buffer )
		{
			lock ( _random )
			{
				_random . NextBytes ( buffer ) ;
			}
		}

		public override double NextDouble ( )
		{
			lock ( _random )
			{
				return _random . NextDouble ( ) ;
			}
		}

		public StaticRandom ( ) { }

		public StaticRandom ( Random random ) { _random = random ; }

		public StaticRandom ( int seed ) : base ( seed ) { }

	}

}

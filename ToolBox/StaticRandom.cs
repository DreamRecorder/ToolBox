using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox
{

	public class StaticRandom : Random
	{

		public static Random Current { get; } = new StaticRandom();

		public StaticRandom() { }

		public StaticRandom(int seed) : base(seed) { }

		private readonly Random _random = new Random();

		public override int Next()
		{
			lock (_random)
			{
				return _random.Next();
			}
		}

		public override int Next(int maxValue)
		{
			lock (_random)
			{
				return _random.Next(maxValue);
			}
		}

		public override int Next(int minValue, int maxValue)
		{
			lock (_random)
			{
				return _random.Next(minValue, maxValue);
			}
		}

		public override void NextBytes(byte[] buffer)
		{
			lock (_random)
			{
				_random.NextBytes(buffer);
			}
		}

		public override double NextDouble()
		{
			lock (_random)
			{
				return _random.NextDouble();
			}
		}

	}

}
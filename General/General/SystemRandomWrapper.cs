using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public sealed class SystemRandomWrapper : IRandom
	{

		private readonly Random _item ;

		public SystemRandomWrapper ( Random item ) => _item = item ;

		public int Next ( ) => _item . Next ( ) ;

		public int Next ( int maxValue ) => _item . Next ( maxValue ) ;

		public int Next ( int minValue , int maxValue ) => _item . Next ( minValue , maxValue ) ;

		public void NextBytes ( byte [ ] buffer ) { _item . NextBytes ( buffer ) ; }

		public double NextDouble ( ) => _item . NextDouble ( ) ;

		public static implicit operator Random ( SystemRandomWrapper wrapper ) => wrapper . _item ;

		public static implicit operator SystemRandomWrapper ( Random item ) => new SystemRandomWrapper ( item ) ;

	}

}

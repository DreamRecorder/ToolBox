﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public sealed class SystemRandomWrapper : IRandom
	{

		private readonly Random _target ;

		public SystemRandomWrapper ( Random target ) => _target = target ;

		public int Next ( ) => _target . Next ( ) ;

		public int Next ( int maxValue ) => _target . Next ( maxValue ) ;

		public int Next ( int minValue , int maxValue ) => _target . Next ( minValue , maxValue ) ;

		public void NextBytes ( byte [ ] buffer ) { _target . NextBytes ( buffer ) ; }

		public double NextDouble ( ) => _target . NextDouble ( ) ;

		public static implicit operator Random ( SystemRandomWrapper wrapper ) => wrapper . _target ;

		public static implicit operator SystemRandomWrapper ( Random target ) => new SystemRandomWrapper ( target ) ;

	}

}

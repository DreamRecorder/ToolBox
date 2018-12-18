﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	//HACK
	//Todo: Fix after https://github.com/dotnet/corefx/issues/34143
	public interface IRandom
	{

		int Next ( ) ;

		int Next ( int maxValue ) ;

		int Next ( int minValue , int maxValue ) ;

		void NextBytes ( byte [ ] buffer ) ;

		double NextDouble ( ) ;

	}

	//HACK
	//Todo: Fix after https://github.com/dotnet/corefx/issues/34143
	public sealed class SystemRandomWrapper : IRandom
	{

		private readonly Random _item ;

		public SystemRandomWrapper ( Random item ) { _item = item ; }

		public int Next ( ) { return _item . Next ( ) ; }

		public int Next ( int maxValue ) { return _item . Next ( maxValue ) ; }

		public int Next ( int minValue , int maxValue ) { return _item . Next ( minValue , maxValue ) ; }

		public void NextBytes ( byte [ ] buffer ) { _item . NextBytes ( buffer ) ; }

		public double NextDouble ( ) { return _item . NextDouble ( ) ; }

		public static implicit operator Random ( SystemRandomWrapper wrapper ) { return wrapper . _item ; }

		public static implicit operator SystemRandomWrapper ( Random item )
		{
			return new SystemRandomWrapper ( item ) ;
		}

	}

}

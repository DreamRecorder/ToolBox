﻿using System ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public class MarkedValue <TValue , TMark>
	{

		public TValue Value { get ; set ; }

		public TMark Mark { get ; set ; }

		public MarkedValue ( TValue value , TMark mark )
		{
			Value = value ;
			Mark = mark ;
		}

		public static implicit operator TValue ( MarkedValue <TValue , TMark> value ) { return value . Value ; }

		public static implicit operator MarkedValue <TValue , TMark> ( TValue value )
		{
			return new MarkedValue <TValue , TMark> ( value , default ) ;
		}

	}

}

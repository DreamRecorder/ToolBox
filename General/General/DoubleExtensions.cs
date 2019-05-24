﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]

	public static class DoubleExtensions
	{

		/// <summary>
		/// smallest such that 1.0+Epsilon != 1.0
		/// </summary>
		public const double Epsilon = 2.2204460492503131e-016;

		public static bool IsAboutZero(this double value)
		{
			return value < Epsilon && -value > Epsilon;
		}

		public static bool DefinitelyGreaterThan(double a, double b)
		{
			return (a - b) > (Math.Max(Math.Abs(a), Math.Abs(b))) * Epsilon;
		}

		public static bool DefinitelyLessThan(double a, double b)
		{
			return (b - a) > (Math.Max(Math.Abs(a), Math.Abs(b))) * Epsilon;
		}


	}

}
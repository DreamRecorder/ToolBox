using System ;
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

}

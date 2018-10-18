using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	[AttributeUsage ( AttributeTargets . Class | AttributeTargets . Property )]
	public sealed class SortIndexAttribute : Attribute
	{

		public int Value { get ; }

		public SortIndexAttribute ( int value ) { Value = value ; }

	}

}

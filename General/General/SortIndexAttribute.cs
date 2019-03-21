using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	[AttributeUsage ( AttributeTargets . Class | AttributeTargets . Property )]
	public sealed class SortIndexAttribute : Attribute
	{

		public int Value { get ; }

		public SortIndexAttribute ( int value ) => Value = value ;

	}

}

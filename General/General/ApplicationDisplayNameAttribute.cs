using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Linq ;

namespace DreamRecorder . ToolBox . General
{

	[AttributeUsage ( AttributeTargets . Assembly )]
	public sealed class ApplicationDisplayNameAttribute : Attribute
	{

		public string Name { get ; }

		public ApplicationDisplayNameAttribute ( string name ) => Name = name ;

	}

}
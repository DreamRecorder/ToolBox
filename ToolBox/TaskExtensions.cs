using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

namespace DreamRecorder . ToolBox
{

	public static class TaskExtensions
	{

		public static readonly Task CompletedTask = Task . FromResult ( false ) ;

	}

}

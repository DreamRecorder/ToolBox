using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	public interface ITaskDispatcher:IStartStop
	{

		void Dispatch ( [NotNull] ITask task ) ;


	}

}

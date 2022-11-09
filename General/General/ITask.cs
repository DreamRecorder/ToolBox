using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public interface ITask
	{

		TaskPriority Priority { get ; }

		TaskStatus Status { get ; }

		TimeSpan Timeout { get ; }

		void Invoke ( ITaskDispatcher dispatcher ) ;

	}

}

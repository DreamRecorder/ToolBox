using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public interface ITask
	{

		TimeSpan Timeout { get ; }

		TaskPriority Priority { get ; }

		TaskStatus Status { get ; }

		void Invoke ( ITaskDispatcher dispatcher ) ;

	}

}

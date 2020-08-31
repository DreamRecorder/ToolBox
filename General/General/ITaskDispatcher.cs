using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	public interface ITaskDispatcher
	{

		bool IsRunning { get ; }

		void Dispatch (
			[NotNull]
			ITask task ) ;

		void Start ( ) ;

		void Stop ( ) ;

	}

}

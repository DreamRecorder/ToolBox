using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General ;

public static class TaskDispatcherExtensions
{

	public static OnetimeTask Dispatch (
		[NotNull] this ITaskDispatcher dispatcher ,
		Action                         action ,
		TimeSpan ?                     timeout  = default ,
		TaskPriority                   priority = TaskPriority . Normal )
	{
		if ( dispatcher == null )
		{
			throw new ArgumentNullException ( nameof ( dispatcher ) ) ;
		}

		OnetimeTask task = new OnetimeTask ( action , timeout ?? TimeSpan . MaxValue , priority ) ;

		dispatcher . Dispatch ( task ) ;

		return task ;
	}

}

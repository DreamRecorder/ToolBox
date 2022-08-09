using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . Logging ;

namespace DreamRecorder . ToolBox . General
{

	public class OnetimeTask : ITask
	{

		public Action Action { get ; private set ; }

		public OnetimeTask ( Action action , TimeSpan timeout , TaskPriority priority = TaskPriority . Normal )
		{
			Action   = action ;
			Timeout  = timeout ;
			Priority = priority ;
		}

		public TimeSpan Timeout { get ; private set ; }

		public TaskPriority Priority { get ; private set ; }

		public TaskStatus Status { get => _status ; private set => _status = value ; }

		public void Invoke ( ITaskDispatcher dispatcher )
		{
			if ( Status != TaskStatus . Running )
			{
				lock ( this )
				{
					Status = TaskStatus . Running ;

					try
					{
						Action ? . Invoke ( ) ;
					}
					catch ( Exception e )
					{
						Logger ? . LogError ( e , $"{nameof ( OnetimeTask )} thrown unhandled exception." ) ;

						Status = TaskStatus . Ready ;

						throw ;
					}

					Status = TaskStatus . Finished ;
				}
			}
		}


		#region Logger

		private static ILogger Logger
			=> _logger ??= StaticServiceProvider . Provider . GetService <ILoggerFactory> ( ) .
													CreateLogger <OnetimeTask> ( ) ;


		private static ILogger _logger ;

		private volatile TaskStatus _status = TaskStatus . Ready ;

		#endregion

	}

}

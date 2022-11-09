using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . Logging ;

namespace DreamRecorder . ToolBox . General
{

	public sealed class IntervalTask : ITask
	{

		public Action Action { get ; set ; }

		public TimeSpan Interval { get ; set ; }

		private bool IsRunning { get ; set ; }

		public DateTimeOffset LastRun { get ; set ; }

		public DateTimeOffset NextRun { get ; set ; }

		public int RunCount { get ; set ; }

		public DateTimeOffset StartFrom { get ; set ; }

		public IntervalTask (
			Action           action ,
			TimeSpan         interval ,
			DateTimeOffset ? startFrom = null ,
			TimeSpan ?       timeout   = null ,
			TaskPriority     priority  = TaskPriority . Normal )
		{
			Interval  = interval ;
			Action    = action ;
			StartFrom = startFrom ?? DateTimeOffset . UtcNow ;
			Timeout   = timeout   ?? TimeSpan . FromMinutes ( 10 ) ;
			Priority  = priority ;

			UpdateStatus ( ) ;
		}

		public TimeSpan Timeout { get ; set ; }

		public TaskPriority Priority { get ; set ; }

		public TaskStatus Status
		{
			get
			{
				if ( IsRunning )
				{
					return TaskStatus . Running ;
				}
				else
				{
					if ( DateTimeOffset . UtcNow < NextRun )
					{
						return TaskStatus . Waiting ;
					}
					else
					{
						return TaskStatus . Ready ;
					}
				}
			}
		}

		public void Invoke ( ITaskDispatcher dispatcher )
		{
			lock ( this )
			{
				IsRunning = true ;

				if ( DateTimeOffset . UtcNow >= NextRun )
				{
					LastRun = DateTime . Now ;

					try
					{
						Action ? . Invoke ( ) ;
					}
					catch ( Exception e )
					{
						Logger ? . LogError ( e , $"{nameof ( IntervalTask )} thrown unhandled exception." ) ;
					}

					RunCount++ ;

					UpdateStatus ( ) ;
				}

				IsRunning = false ;
			}
		}


		public void UpdateStatus ( )
		{
			if ( NextRun < StartFrom )
			{
				NextRun = StartFrom ;
			}

			while ( NextRun < DateTimeOffset . UtcNow )
			{
				NextRun += Interval ;
			}
		}

		#region Logger

		private static ILogger Logger
			=> _logger ??= StaticServiceProvider . Provider . GetService <ILoggerFactory> ( ) .
												   CreateLogger <ScheduledTask> ( ) ;


		private static ILogger _logger ;

		#endregion

	}

}

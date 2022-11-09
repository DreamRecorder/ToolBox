using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . Logging ;

namespace DreamRecorder . ToolBox . General
{

	public sealed class ScheduledTask : ITask
	{

		public Func <DateTimeOffset ?> Action { get ; set ; }

		private bool IsRunning { get ; set ; }

		public DateTimeOffset ? LastRun { get ; private set ; }

		public DateTimeOffset ? NextRun { get ; set ; }

		public int RunCount { get ; set ; }

		public ScheduledTask (
			Func <DateTimeOffset ?> action ,
			DateTimeOffset ?        nextRun  = default ,
			TimeSpan ?              timeout  = default ,
			TaskPriority            priority = TaskPriority . Normal )
		{
			Action   = action ;
			NextRun  = nextRun ?? DateTimeOffset . UtcNow ;
			Timeout  = timeout ?? TimeSpan . MaxValue ;
			Priority = priority ;
		}

		public ScheduledTask ( ) => NextRun = DateTimeOffset . UtcNow ;

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
					if ( NextRun is null )
					{
						return TaskStatus . Finished ;
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
		}

		public void Invoke ( ITaskDispatcher dispatcher )
		{
			lock ( this )
			{
				IsRunning = true ;

				if ( NextRun != null )
				{
					if ( DateTimeOffset . UtcNow >= NextRun )
					{
						LastRun = DateTime . Now ;

						try
						{
							NextRun = Action ? . Invoke ( ) ;
						}
						catch ( Exception e )
						{
							Logger ? . LogError ( e , $"{nameof ( ScheduledTask )} thrown unhandled exception." ) ;
						}

						RunCount++ ;
					}
				}

				IsRunning = false ;
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

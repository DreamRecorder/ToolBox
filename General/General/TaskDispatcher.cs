using System ;
using System . Collections ;
using System . Collections . Concurrent ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading ;
using System . Threading . Tasks ;

using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . Logging ;

namespace DreamRecorder . ToolBox . General
{

	public class TaskDispatcher : ITaskDispatcher
	{

		public ConcurrentQueue <ITask> [ ] TaskQueues { get ; }

		public LinkedList <(Task RunningTask , ITask Task)> RunningTasks { get ; } =
			new LinkedList <(Task RunningTask , ITask Task)> ( ) ;

		private Thread RunningThread { get ; set ; }

		public void Dispatch ( ITask task )
		{
			if ( task == null )
			{
				throw new ArgumentNullException ( nameof ( task ) ) ;
			}

			lock ( this )
			{
				if ( ! IsRunning )
				{
					throw new InvalidOperationException ( ) ;
				}


				TaskQueues [ ( int )task . Priority ] . Enqueue ( task ) ;
			}
		}

		public bool IsRunning { get ; private set ; }

		public void Start ( )
		{
			lock ( this )
			{
				if ( ! IsRunning )
				{
					IsRunning     = true ;
					RunningThread = new Thread ( Execute ) ;
					RunningThread . Start ( ) ;
				}
			}
		}

		public void Stop ( )
		{
			lock ( this )
			{
				IsRunning = false ;

				RunningThread ? . Join ( ) ;

				lock ( RunningTasks )
				{
					Task . WaitAll ( RunningTasks . Select ( taskPair => taskPair . RunningTask ) . ToArray ( ) ) ;

					RunningTasks . Clear ( ) ;
				}
			}
		}

		[Prepare]
		public static void Prepare ( )
		{
			StaticServiceProvider . ServiceCollection . AddSingleton <ITaskDispatcher , TaskDispatcher> ( ) ;
		}

		private void Execute ( )
		{
			while ( IsRunning )
			{
				foreach ( ConcurrentQueue <ITask> taskQueue in TaskQueues )
				{
					if ( taskQueue . TryDequeue ( out ITask task ) )
					{
						if ( task . Status == TaskStatus . Ready
							&& RunningTasks . All ( taskPair => taskPair . Task != task ) )
						{
							Task runningTask = Task . Run (
															( ) =>
															{
																try
																{
																	task . Invoke ( this ) ;
																}
																catch ( Exception e )
																{
																	Logger . LogWarning (
																	e ,
																	"Task {0} throw unhandled exception." ,
																	task . GetType ( ) . Name ) ;
																}
															} ) ;

							lock ( RunningTasks )
							{
								RunningTasks . AddLast ( ( runningTask , task ) ) ;
							}
						}

						if ( task . Status != TaskStatus . Finished )
						{
							TaskQueues [ ( int )task . Priority ] . Enqueue ( task ) ;
						}
					}
				}

				lock ( RunningTasks )
				{
					LinkedListNode <(Task RunningTask , ITask task)> currentNode = RunningTasks . First ;

					while ( currentNode != null )
					{
						LinkedListNode <(Task RunningTask , ITask task)> nextNode = currentNode . Next ;

						Task task = currentNode . Value . RunningTask ;

						switch ( task . Status )
						{
							case System . Threading . Tasks . TaskStatus . Canceled :
							case System . Threading . Tasks . TaskStatus . Faulted :
							case System . Threading . Tasks . TaskStatus . RanToCompletion :
							{
								RunningTasks . Remove ( currentNode ) ;
								break ;
							}

							case System . Threading . Tasks . TaskStatus . Created :
							case System . Threading . Tasks . TaskStatus . WaitingForActivation :
							{
								task . Start ( ) ;
								break ;
							}
						}

						currentNode = nextNode ;
					}
				}

				Thread . Yield ( ) ;
				Thread . Sleep ( 1 ) ;
			}
		}

		#region Logger

		private static ILogger Logger
			=> _logger ??= StaticServiceProvider . Provider . GetService <ILoggerFactory> ( ) .
													CreateLogger <ScheduledTask> ( ) ;

		private static ILogger _logger ;

		public TaskDispatcher ( )
		{
			int queueCount = Enum . GetValues ( typeof ( TaskPriority ) ) . Cast <int> ( ) . Max ( ) + 1 ;

			TaskQueues = new ConcurrentQueue <ITask>[ queueCount ] ;
			for ( int i = 0 ; i < queueCount ; i++ )
			{
				TaskQueues [ i ] = new ConcurrentQueue <ITask> ( ) ;
			}
		}

		#endregion

	}

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using DreamRecorder.ToolBox.General;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DreamRecorder.ToolBox.UnitTest;

[TestClass]
public class TaskDispatcherTest
{

	private volatile bool _isRunning;

	public void ConcurrentTest ( int i ) { Console.WriteLine ( i ); }

	[TestInitialize]
	public void Prepare ( )
	{
		StaticServiceProvider.ServiceCollection.AddLogging ( builder => builder.AddConsole ( ) );

		AppDomainExtensions.PrepareCurrentDomain ( );
		StaticServiceProvider.Update ( );
	}

	public void SingleThreadConcurrentTest ( int i )
	{
		Assert.IsFalse ( _isRunning );
		_isRunning = true;
		Assert.IsTrue ( _isRunning );
		Console.WriteLine ( i );
		Thread.Sleep ( 10 );
		Assert.IsTrue ( _isRunning );
		_isRunning = false;
		Assert.IsFalse ( _isRunning );
	}

	[TestMethod]
	public void TaskDispatcherLimitConcurrentTest ( )
	{
		OnetimeTask [ ] tasks = new OnetimeTask[ 100 ];

		for ( int i = 0 ; i < 100 ; i++ )
		{
			int d = i;
			tasks [ i ] = new OnetimeTask ( ( ) => ConcurrentTest ( d ) , TimeSpan.MaxValue );
		}

		TaskDispatcher dispatcher = new TaskDispatcher ( );

		dispatcher.ConcurrentTaskLimit = 10;

		for ( int i = 0 ; i < 100 ; i++ )
		{
			dispatcher.Dispatch ( tasks [ i ] );
		}

		dispatcher.Start ( );

		Thread.Sleep ( 10 );

		dispatcher.StopAndWaitQueuedTask ( );
	}

	[TestMethod]
	public void TaskDispatcherOneConcurrentTest ( )
	{
		OnetimeTask [ ] tasks = new OnetimeTask[ 100 ];

		for ( int i = 0 ; i < 100 ; i++ )
		{
			int d = i;
			tasks [ i ] = new OnetimeTask ( ( ) => SingleThreadConcurrentTest ( d ) , TimeSpan.MaxValue );
		}

		TaskDispatcher dispatcher = new TaskDispatcher ( );

		dispatcher.ConcurrentTaskLimit = 1;

		for ( int i = 0 ; i < 100 ; i++ )
		{
			dispatcher.Dispatch ( tasks [ i ] );
		}

		dispatcher.Start ( );

		Thread.Sleep ( 10 );

		dispatcher.StopAndWaitQueuedTask ( );
	}

	[TestMethod]
	public void TaskDispatcherStartStopTest ( )
	{
		TaskDispatcher dispatcher = new TaskDispatcher ( );

		dispatcher.Start ( );
		dispatcher.Stop ( );
	}

}

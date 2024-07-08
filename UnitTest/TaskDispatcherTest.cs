using DreamRecorder.ToolBox.General;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DreamRecorder.ToolBox.UnitTest
{
	[TestClass]
	public class TaskDispatcherTest
	{
		[TestInitialize]
		public void Prepare()
		{
			StaticServiceProvider.ServiceCollection.AddLogging((builder)=>builder.AddConsole());

			AppDomainExtensions.PrepareCurrentDomain();
			StaticServiceProvider.Update();
		}

		[TestMethod]
		public void TaskDispatcherStartStopTest()
		{
			TaskDispatcher dispatcher = new TaskDispatcher();

			dispatcher.Start();
			dispatcher.Stop();
		}

		volatile bool IsRunning = false;

		public void SingleThreadConcurrentTest(int i)
		{
			Assert.IsFalse(IsRunning);
			IsRunning = true;
			Assert.IsTrue(IsRunning);
			Console.WriteLine(i);
			Thread.Sleep(10);
			Assert.IsTrue(IsRunning);
			IsRunning = false;
			Assert.IsFalse(IsRunning);
		}

		public void ConcurrentTest(int i)
		{
			Console.WriteLine(i);
		}

		[TestMethod]
		public void TaskDispatcherOneConcurrentTest()
		{
			OnetimeTask[] tasks = new OnetimeTask[100];

			for (int i = 0; i < 100; i++)
			{
				int d = i;
				tasks[i] = new OnetimeTask(()=>SingleThreadConcurrentTest(d), TimeSpan.MaxValue);
			}

			TaskDispatcher dispatcher = new TaskDispatcher();

			dispatcher.ConcurrentTaskLimit = 1;

			for (int i = 0; i < 100; i++)
			{
				dispatcher.Dispatch(tasks[i]);
			}

			dispatcher.Start();

			Thread.Sleep(10);

			dispatcher.StopAndWaitQueuedTask();
		}

		[TestMethod]
		public void TaskDispatcherLimitConcurrentTest()
		{
			OnetimeTask[] tasks = new OnetimeTask[100];

			for (int i = 0; i < 100; i++)
			{
				int d = i;
				tasks[i] = new OnetimeTask(() => ConcurrentTest(d), TimeSpan.MaxValue);
			}

			TaskDispatcher dispatcher = new TaskDispatcher();

			dispatcher.ConcurrentTaskLimit = 10;

			for (int i = 0; i < 100; i++)
			{
				dispatcher.Dispatch(tasks[i]);
			}

			dispatcher.Start();

			Thread.Sleep(10);

			dispatcher.StopAndWaitQueuedTask();
		}

	}
}

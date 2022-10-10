using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace DreamRecorder . ToolBox . UnitTest ;

[TestClass]
public class StartStopTests
{

	public class StatefulStartStopSelfStartStopTestStub : IStatefulStartStop
	{

		public string Name { get ; set ; }

		bool IStatefulStartStop . IsRunningStatus { get ; set ; }

		public void StartOverride ( )
		{
			Console . WriteLine ( $"{Name} start." ) ;
			( this as IStartStop ) . Start ( ) ;
		}

		public void StopOverride ( )
		{
			Console . WriteLine ( $"{Name} stop." ) ;
			( this as IStartStop ) . Stop ( ) ;
		}

	}

	public class StatefulStartStopMemberStartStopTestStub : IStatefulStartStop
	{

		public IStartStop Member { get ; set ; }

		public IStartStop Exception => throw null ;

		public string Name { get ; set ; }

		bool IStatefulStartStop . IsRunningStatus { get ; set ; }

		public void StartOverride ( )
		{
			Console . WriteLine ( $"{Name} start." ) ;
			this . StartMembers ( ) ;
		}

		public void StopOverride ( )
		{
			Console . WriteLine ( $"{Name} stop." ) ;
			this . StopMembers ( ) ;
		}

	}

	[TestMethod]
	public void SelfStartStopTest ( )
	{
		IStartStop stub = new StatefulStartStopSelfStartStopTestStub { Name = nameof ( stub ) } ;
		stub . Start ( ) ;
		stub . Stop ( ) ;
		stub . Start ( ) ;
		stub . Stop ( ) ;
	}

	[TestMethod]
	public void LoopMemberStartStopTest ( )
	{
		StatefulStartStopMemberStartStopTestStub stub1 =
			new StatefulStartStopMemberStartStopTestStub { Name = nameof ( stub1 ) } ;
		StatefulStartStopMemberStartStopTestStub stub2 =
			new StatefulStartStopMemberStartStopTestStub { Name = nameof ( stub2 ) } ;

		stub1 . Member = stub2 ;
		stub2 . Member = stub1 ;

		IStartStop stub = stub1 ;

		stub . Start ( ) ;
		stub . Stop ( ) ;
		stub . Start ( ) ;
		stub . Stop ( ) ;

		stub . Start ( ) ;
		stub = stub2 ;
		stub . Stop ( ) ;
		stub . Start ( ) ;
		stub . Stop ( ) ;
	}

	[TestMethod]
	public void SelfMemberStartStopTest ( )
	{
		StatefulStartStopMemberStartStopTestStub stub1 =
			new StatefulStartStopMemberStartStopTestStub { Name = nameof ( stub1 ) } ;

		stub1 . Member = stub1 ;

		IStartStop stub = stub1 ;

		stub . Start ( ) ;
		stub . Stop ( ) ;
		stub . Start ( ) ;
		stub . Stop ( ) ;
	}

}

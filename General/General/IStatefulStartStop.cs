using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General ;

public interface IStatefulStartStop : IStartStop
{

	bool IStartStop. IsRunning =>IsRunningStatus;

	bool IsRunningStatus { get; protected set; }

	void IStartStop . Start ( )
	{
		lock ( this )
		{
			if ( IsRunning )
			{
				return ;
			}

			StartOverride ();
			IsRunningStatus = true;
		}
	}

	void StartOverride ( ) ;

	void IStartStop. Stop()
	{
		lock (this)
		{
			if ( ! IsRunning )
			{
				return ;
			}

			StopOverride();
			IsRunningStatus = false;
		}
	}

	void StopOverride();

}

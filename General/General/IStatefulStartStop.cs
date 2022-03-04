using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General ;

public interface IStatefulStartStop : IStartStop
{

	bool IsRunningStatus { get ; protected set ; }

	bool IStartStop . IsRunning => IsRunningStatus ;

	void IStartStop . Start ( )
	{
		lock ( this )
		{
			if ( IsRunning )
			{
				return ;
			}

			StartOverride ( ) ;
			IsRunningStatus = true ;
		}
	}

	void IStartStop . Stop ( )
	{
		lock ( this )
		{
			if ( ! IsRunning )
			{
				return ;
			}

			StopOverride ( ) ;
			IsRunningStatus = false ;
		}
	}

	void StartOverride ( ) ;

	void StopOverride ( ) ;

}

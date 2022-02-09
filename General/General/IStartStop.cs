using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General ;

public interface IStartStop
{

	bool IsRunning { get; }

	void Start ();

	void Stop ();

}

using System ;
using System.Collections ;
using System.Collections.Generic ;
using System . Diagnostics ;
using System.Linq ;

namespace DreamRecorder . ToolBox . General
{

	public interface IPerformanceCounterProvider
	{

		PerformanceCounter GetPerformanceCounter (
			string categoryName = null ,
			string counterName  = null ,
			string instanceName = null ) ;

	}

}
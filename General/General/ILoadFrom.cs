using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public interface ILoadFrom <TSource> : IToT <TSource>
	{

		void LoadFrom ( TSource value ) ;

	}

}

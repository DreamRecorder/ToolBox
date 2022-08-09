using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General ;

public interface ICreateFrom <out T , TSource> : IToT <TSource> where T : ICreateFrom <T , TSource>
{

	static abstract T CreateFrom ( TSource value ) ;

}

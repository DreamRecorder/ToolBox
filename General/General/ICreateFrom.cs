using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General ;

public interface ICreateFrom <T> : IToT <T>
{

	static abstract T CreateFrom ( T value ) ;

}

public interface IToT <out T>
{

	T ToT ( ) ;

}

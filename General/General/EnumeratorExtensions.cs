using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General ;

public static class EnumeratorExtensions
{
	public static IEnumerable<T> ToIEnumerable<T>(IEnumerator<T> enumerator)
	{
		while (enumerator.MoveNext())
		{
			yield return enumerator.Current;
		}
	}

}

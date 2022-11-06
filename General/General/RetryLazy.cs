using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General ;

public class RetryLazy <T> where T : class
{

	private readonly Func <T> _factory ;

	private volatile T _value ;

	public RetryLazy ( Func <T> factory ) => _factory = factory ;

	public T GetValue ( )
	{
		if ( _value != null )
		{
			return _value ;
		}
		else
		{
			lock ( this )
			{
				if ( _value != null )
				{
					return _value ;
				}
				else
				{
					return _value = _factory ( ) ;
				}
			}
		}
	}

}

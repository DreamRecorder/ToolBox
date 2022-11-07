using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General ;

public class RetryLazy <T> where T : class
{

	private readonly Func <T> _factory ;

	private readonly Action <T> _valueProduced ;

	private volatile T _value ;

	public RetryLazy ( Func <T> factory , Action <T> valueProduced = default )
	{
		_factory       = factory ;
		_valueProduced = valueProduced ;
	}

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
					_value = _factory ( ) ;
					if ( _value is not null )
					{
						_valueProduced ? . Invoke ( _value ) ;
					}

					return _value ;
				}
			}
		}
	}

}

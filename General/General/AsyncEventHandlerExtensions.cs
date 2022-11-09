using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading . Tasks ;

namespace DreamRecorder . ToolBox . General
{

	public static class AsyncEventHandlerExtensions
	{

		public static Task RaiseAsync <T> ( this AsyncEventHandler <T> eventHandler , object sender , T eventArgs )
			where T : EventArgs
		{
			if ( eventHandler == null )
			{
				return Task . FromResult ( false ) ;
			}

			return Task . WhenAll (
								   eventHandler . GetInvocationList ( ) .
												  Cast <AsyncEventHandler <T>> ( ) .
												  Select ( x => x . Invoke ( sender , eventArgs ) ) ) ;
		}

	}

}

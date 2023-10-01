using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading ;

namespace DreamRecorder . ToolBox . Network . Dns
{

	internal class DnsClientParallelAsyncState <TMessage> : IAsyncResult where TMessage : DnsMessageBase
	{

		private ManualResetEvent _waitHandle ;

		internal List <TMessage> Responses ;

		internal int ResponsesToReceive ;

		internal AsyncCallback UserCallback ;

		public object AsyncState { get ; internal set ; }

		public bool IsCompleted { get ; private set ; }

		public bool CompletedSynchronously => false ;

		public WaitHandle AsyncWaitHandle => _waitHandle ??= new ManualResetEvent ( IsCompleted ) ;

		internal void SetCompleted ( )
		{
			IsCompleted = true ;

			if ( _waitHandle != null )
			{
				_waitHandle . Set ( ) ;
			}

			if ( UserCallback != null )
			{
				UserCallback ( this ) ;
			}
		}

	}

}

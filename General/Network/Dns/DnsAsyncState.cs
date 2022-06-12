using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;
using System . Net . Sockets ;
using System . Threading ;

namespace DreamRecorder . ToolBox . Network . Dns
{

	internal class DnsAsyncState : IAsyncResult
	{

		private long _timeOutUtcTicks ;

		private ManualResetEvent _waitHandle ;

		internal byte [ ] QueryData ;

		internal int QueryLength ;

		internal DnsMessage Response ;

		internal int ServerIndex ;

		internal List <IPAddress> Servers ;

		internal byte [ ] TcpBuffer ;

		internal int TcpBytesToReceive ;

		internal TcpClient TcpClient ;

		internal NetworkStream TcpStream ;

		internal bool TimedOut ;

		internal Timer Timer ;

		internal DnsServer . SelectTsigKey TSigKeySelector ;

		internal byte [ ] TSigOriginalMac ;

		internal UdpClient UdpClient ;

		internal IPEndPoint UdpEndpoint ;

		internal AsyncCallback UserCallback ;

		internal long TimeRemaining
		{
			get
			{
				long res = ( _timeOutUtcTicks - DateTime . UtcNow . Ticks ) / TimeSpan . TicksPerMillisecond ;
				return res > 0 ? res : 0 ;
			}
			set => _timeOutUtcTicks = DateTime . UtcNow . Ticks + value * TimeSpan . TicksPerMillisecond ;
		}

		public object AsyncState { get ; internal set ; }

		public bool IsCompleted { get ; private set ; }

		public bool CompletedSynchronously => false ;

		public WaitHandle AsyncWaitHandle => _waitHandle ?? ( _waitHandle = new ManualResetEvent ( IsCompleted ) ) ;

		internal void SetCompleted ( )
		{
			QueryData = null ;

			if ( Timer != null )
			{
				Timer . Dispose ( ) ;
				Timer = null ;
			}


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

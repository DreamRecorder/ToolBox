using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;
using System . Net . Sockets ;
using System . Threading ;

namespace DreamRecorder . ToolBox . Network . Dns
{

	internal class DnsClientAsyncState <TMessage> : IAsyncResult where TMessage : DnsMessageBase
	{

		private long _timeOutUtcTicks ;

		private ManualResetEvent _waitHandle ;

		internal byte [ ] Buffer ;

		internal int EndpointInfoIndex ;

		internal List <DnsClientEndpointInfo> EndpointInfos ;

		internal TMessage PartialMessage ;

		internal TMessage Query ;

		internal byte [ ] QueryData ;

		internal int QueryLength ;

		internal List <TMessage> Responses ;

		internal int TcpBytesToReceive ;

		internal TcpClient TcpClient ;

		internal NetworkStream TcpStream ;

		internal bool TimedOut ;

		internal Timer Timer ;

		internal DnsServer . SelectTsigKey TSigKeySelector ;

		internal byte [ ] TSigOriginalMac ;

		internal Socket UdpClient ;

		internal EndPoint UdpEndpoint ;

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

		public DnsClientAsyncState <TMessage> CreateTcpCloneWithoutCallback ( )
			=> new DnsClientAsyncState <TMessage>
			   {
				   EndpointInfos     = EndpointInfos ,
				   EndpointInfoIndex = EndpointInfoIndex ,
				   Query             = Query ,
				   QueryData         = QueryData ,
				   QueryLength       = QueryLength ,
				   TSigKeySelector   = TSigKeySelector ,
				   TSigOriginalMac   = TSigOriginalMac ,
				   Responses         = Responses ,
				   _timeOutUtcTicks  = _timeOutUtcTicks ,
			   } ;

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

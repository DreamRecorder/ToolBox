using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net . Sockets ;
using System . Threading ;
using System . Threading . Tasks ;

namespace DreamRecorder . ToolBox . Network
{

	public static class UdpClientExtensions
	{

		public static async Task <UdpReceiveResult> ReceiveAsync (
			this UdpClient    udpClient ,
			int               timeout ,
			CancellationToken token )
		{
			Task <UdpReceiveResult> connectTask = udpClient . ReceiveAsync ( ) ;
			Task                    timeoutTask = Task . Delay ( timeout , token ) ;

			await Task . WhenAny ( connectTask , timeoutTask ) ;

			if ( connectTask . IsCompleted )
			{
				return connectTask . Result ;
			}

			return new UdpReceiveResult ( ) ;
		}

	}

}

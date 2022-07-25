using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;
using System . Net . Sockets ;
using System . Threading ;
using System . Threading . Tasks ;

namespace DreamRecorder . ToolBox . Network
{

	public static class TcpClientExtensions
	{

		public static bool TryConnect ( this TcpClient tcpClient , IPEndPoint endPoint , int timeout )
		{
			IAsyncResult ar = tcpClient . BeginConnect ( endPoint . Address , endPoint . Port , null , null ) ;
			WaitHandle   wh = ar . AsyncWaitHandle ;
			try
			{
				if ( ! ar . AsyncWaitHandle . WaitOne ( TimeSpan . FromMilliseconds ( timeout ) , false ) )
				{
					tcpClient . Close ( ) ;
					return false ;
				}

				tcpClient . EndConnect ( ar ) ;
				return true ;
			}
			finally
			{
				wh . Close ( ) ;
			}
		}

		public static async Task <bool> TryConnectAsync (
			this TcpClient    tcpClient ,
			IPAddress         address ,
			int               port ,
			int               timeout ,
			CancellationToken token )
		{
			Task connectTask = tcpClient . ConnectAsync ( address , port ) ;
			Task timeoutTask = Task . Delay ( timeout , token ) ;

			await Task . WhenAny ( connectTask , timeoutTask ) ;

			if ( connectTask . IsCompleted )
			{
				return true ;
			}

			tcpClient . Close ( ) ;
			return false ;
		}

		public static bool IsConnected ( this TcpClient client )
		{
			if ( ! client . Connected )
			{
				return false ;
			}

			if ( client . Client . Poll ( 0 , SelectMode . SelectRead ) )
			{
				if ( client . Connected )
				{
					byte [ ] b = new byte[ 1 ] ;
					try
					{
						if ( client . Client . Receive ( b , SocketFlags . Peek ) == 0 )
						{
							return false ;
						}
					}
					catch
					{
						return false ;
					}
				}
			}

			return true ;
		}

	}

}

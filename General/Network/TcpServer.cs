using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;
using System . Net . Sockets ;
using System . Threading ;
using System . Threading . Tasks ;

using DreamRecorder . ToolBox . General ;

using JetBrains . Annotations ;

using Microsoft . Extensions . Logging ;

namespace DreamRecorder . ToolBox . Network ;

public class TcpServer : IStatefulStartStop
{

	public TcpListener Listener { get ; private set ; }

	public int ListeningPort { get ; set ; }

	public Thread ListenThread { get ; private set ; }

	public virtual IPAddress LocalAddress { get ; set ; } = IPAddress . IPv6Any ;

	[CanBeNull]
	public Logger <TcpServer> Logger { get ; set ; }

	protected TcpServer ( ) { }

	public TcpServer ( int listeningPort ) => ListeningPort = listeningPort ;

	public TcpServer ( [CanBeNull] Logger <TcpServer> logger , int listeningPort )
	{
		Logger        = logger ;
		ListeningPort = listeningPort ;
	}

	bool IStatefulStartStop . IsRunningStatus { get ; set ; }

	public void StartOverride ( )
	{
		Logger ? . LogInformation ( $"Starting {nameof ( ListenThread )}." ) ;
		ListenThread ??= new Thread ( ListenTcp ) ;
		ListenThread . Start ( ) ;
	}

	public void StopOverride ( )
	{
		ListenThread . Join ( ) ;
		ListenThread = new Thread ( ListenTcp ) ;
	}

	public void ListenTcp ( )
	{
		Listener = new TcpListener ( LocalAddress , ListeningPort ) ;
		Listener . Server . SetSocketOption ( SocketOptionLevel . IPv6 , SocketOptionName . IPv6Only , false ) ;

		Listener . Start ( ) ;
		ListeningPort = ( ( IPEndPoint )Listener . LocalEndpoint ) . Port ;
		Logger ? . LogInformation ( $"Started Listening Tcp {ListeningPort}." ) ;


		Task <TcpClient> task = Listener . AcceptTcpClientAsync ( ) ;

		while ( ( ( IStartStop )this ) . IsRunning )
		{
			if ( task . IsCompleted )
			{
				TcpClient acceptedClient = task . Result ;

				Logger ? . LogInformation ( $"{acceptedClient . Client . RemoteEndPoint} Connected In." ) ;

				TcpClientAccepted ? . Invoke ( this , new TcpClientAcceptedEventArgs ( acceptedClient ) ) ;

				task = Listener . AcceptTcpClientAsync ( ) ;
			}
			else if ( task . IsFaulted )
			{
				Logger ? . LogInformation ( task . Exception , "Socket error occurred." ) ;
			}

			task . Wait ( 1 ) ;
		}

		Listener . Stop ( ) ;
	}

	public event EventHandler <TcpClientAcceptedEventArgs> TcpClientAccepted ;

	public class TcpClientAcceptedEventArgs : EventArgs
	{

		public TcpClient Client { get ; set ; }

		public TcpClientAcceptedEventArgs ( TcpClient client ) => Client = client ;

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;
using System . Net . Sockets ;

namespace DreamRecorder . ToolBox . Network . Dns
{

	/// <summary>
	///     Event arguments of
	///     <see cref="DnsServer.ClientConnected" />
	///     event.
	/// </summary>
	public class ClientConnectedEventArgs : EventArgs
	{

		/// <summary>
		///     Protocol used by the client
		/// </summary>
		public ProtocolType ProtocolType { get ; private set ; }

		/// <summary>
		///     Remote endpoint of the client
		/// </summary>
		public IPEndPoint RemoteEndpoint { get ; private set ; }

		/// <summary>
		///     If true, the client connection will be refused
		/// </summary>
		public bool RefuseConnect { get ; set ; }

		internal ClientConnectedEventArgs ( ProtocolType protocolType , IPEndPoint remoteEndpoint )
		{
			ProtocolType   = protocolType ;
			RemoteEndpoint = remoteEndpoint ;
		}

	}

}

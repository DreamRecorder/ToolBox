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
	///     <see cref="DnsServer.QueryReceived" />
	///     event.
	/// </summary>
	public class QueryReceivedEventArgs : EventArgs
	{

		/// <summary>
		///     Protocol used by the client
		/// </summary>
		public ProtocolType ProtocolType { get ; private set ; }

		/// <summary>
		///     Original query, which the client provided
		/// </summary>
		public DnsMessageBase Query { get ; private set ; }

		/// <summary>
		///     Remote endpoint of the client
		/// </summary>
		public IPEndPoint RemoteEndpoint { get ; private set ; }

		/// <summary>
		///     The response, which should be sent to the client
		/// </summary>
		public DnsMessageBase Response { get ; set ; }

		internal QueryReceivedEventArgs ( DnsMessageBase query , ProtocolType protocolType , IPEndPoint remoteEndpoint )
		{
			Query          = query ;
			ProtocolType   = protocolType ;
			RemoteEndpoint = remoteEndpoint ;
		}

	}

}

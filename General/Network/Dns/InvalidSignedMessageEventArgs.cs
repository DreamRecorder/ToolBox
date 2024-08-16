using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace DreamRecorder.ToolBox.Network.Dns;

/// <summary>
///     Event arguments of
///     <see cref="DnsServer.InvalidSignedMessageReceived" />
///     event.
/// </summary>
public class InvalidSignedMessageEventArgs : EventArgs
{

	/// <summary>
	///     Protocol used by the client
	/// </summary>
	public ProtocolType ProtocolType { get; private set; }

	/// <summary>
	///     Original message, which the client provided
	/// </summary>
	public DnsMessageBase Query { get; private set; }

	/// <summary>
	///     Remote endpoint of the client
	/// </summary>
	public IPEndPoint RemoteEndpoint { get; private set; }

	internal InvalidSignedMessageEventArgs (
		DnsMessageBase query ,
		ProtocolType   protocolType ,
		IPEndPoint     remoteEndpoint )
	{
		Query          = query;
		ProtocolType   = protocolType;
		RemoteEndpoint = remoteEndpoint;
	}

}

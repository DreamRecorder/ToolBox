using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using DreamRecorder.ToolBox.Network.Dns.DnsSec;

namespace DreamRecorder.ToolBox.Network.Dns.Resolver;

/// <summary>
///     Interface to provide hints used by resolvers
/// </summary>
public interface IResolverHintStore
{

	/// <summary>
	///     List of DsRecords of the root zone
	/// </summary>
	List <DsRecord> RootKeys { get; }

	/// <summary>
	///     List of hints to the root servers
	/// </summary>
	List <IPAddress> RootServers { get; }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace DreamRecorder.ToolBox.Network.Dns;

/// <summary>
///     Provides a one/shot client for querying Multicast DNS as defined in
///     <see
///         cref="!:http://tools.ietf.org/html/rfc6762">
///         RFC 6762
///     </see>
///     .
/// </summary>
public sealed class MulticastDnsOneShotClient : DnsClientBase
{

	protected override int MaximumQueryMessageSize { get; }

	/// <summary>
	///     Provides a new instance with a timeout of 2.5 seconds
	/// </summary>
	public MulticastDnsOneShotClient ( ) : this ( 2500 ) { }

	/// <summary>
	///     Provides a new instance with a custom timeout
	/// </summary>
	/// <param name="queryTimeout"> Query timeout in milliseconds </param>
	public MulticastDnsOneShotClient ( int queryTimeout ) : base ( _addresses , queryTimeout , 5353 )
	{
		int maximumMessageSize = 0;

		try
		{
			maximumMessageSize = NetworkInterface.GetAllNetworkInterfaces ( ).
												  Where (
														 n => n.SupportsMulticast
															  && ( n.NetworkInterfaceType
																   != NetworkInterfaceType.Loopback )
															  && ( n.OperationalStatus == OperationalStatus.Up )
															  && ( n.Supports ( NetworkInterfaceComponent.IPv4 ) ) ).
												  Select ( n => n.GetIPProperties ( ) ).
												  Min (
													   p => Math.Min (
																	  p.GetIPv4Properties ( ).Mtu ,
																	  p.GetIPv6Properties ( ).Mtu ) );
		}
		catch
		{
			// ignored
		}

		MaximumQueryMessageSize = Math.Max ( 512 , maximumMessageSize );

		IsUdpEnabled = true;
		IsTcpEnabled = false;
	}

	private static readonly List <IPAddress> _addresses =
		new List <IPAddress> { IPAddress.Parse ( "FF02::FB" ) , IPAddress.Parse ( "224.0.0.251" ) , };

	/// <summary>
	///     Queries for specified records.
	/// </summary>
	/// <param name="name"> Name, that should be queried </param>
	/// <param name="recordType"> Type the should be queried </param>
	/// <returns> All available responses on the local network </returns>
	public List <MulticastDnsMessage> Resolve ( DomainName name , RecordType recordType = RecordType.Any )
	{
		if ( name == null )
		{
			throw new ArgumentNullException ( nameof ( name ) , "Name must be provided" );
		}

		MulticastDnsMessage message =
			new MulticastDnsMessage { IsQuery = true , OperationCode = OperationCode.Query , };
		message.Questions.Add ( new DnsQuestion ( name , recordType , RecordClass.INet ) );

		return SendMessageParallel ( message );
	}

	/// <summary>
	///     Queries for specified records as an asynchronous operation.
	/// </summary>
	/// <param name="name"> Name, that should be queried </param>
	/// <param name="recordType"> Type the should be queried </param>
	/// <param name="token"> The token to monitor cancellation requests </param>
	/// <returns> All available responses on the local network </returns>
	public Task <List <MulticastDnsMessage>> ResolveAsync (
		DomainName        name ,
		RecordType        recordType = RecordType.Any ,
		CancellationToken token      = default ( CancellationToken ) )
	{
		if ( name == null )
		{
			throw new ArgumentNullException ( nameof ( name ) , "Name must be provided" );
		}

		MulticastDnsMessage message =
			new MulticastDnsMessage { IsQuery = true , OperationCode = OperationCode.Query , };
		message.Questions.Add ( new DnsQuestion ( name , recordType , RecordClass.INet ) );

		return SendMessageParallelAsync ( message , token );
	}

}

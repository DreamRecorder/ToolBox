using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;
using System . Net . NetworkInformation ;
using System . Threading ;
using System . Threading . Tasks ;

namespace DreamRecorder . ToolBox . Network . Dns
{

	/// <summary>
	///     Provides a client for querying LLMNR (link-local multicast name resolution) as defined in
	///     <see
	///         cref="!:http://tools.ietf.org/html/rfc4795">
	///         RFC 4795
	///     </see>
	///     .
	/// </summary>
	public sealed class LlmnrClient : DnsClientBase
	{

		protected override int MaximumQueryMessageSize { get ; }

		/// <summary>
		///     Provides a new instance with a timeout of 1 second
		/// </summary>
		public LlmnrClient ( ) : this ( 1000 ) { }

		/// <summary>
		///     Provides a new instance with a custom timeout
		/// </summary>
		/// <param name="queryTimeout"> Query timeout in milliseconds </param>
		public LlmnrClient ( int queryTimeout ) : base ( _addresses , queryTimeout , 5355 )
		{
			int maximumMessageSize = 0 ;

			try
			{
				maximumMessageSize = NetworkInterface . GetAllNetworkInterfaces ( ) .
														Where (
															   n => n . SupportsMulticast
																	&& ( n . NetworkInterfaceType
																		 != NetworkInterfaceType . Loopback )
																	&& ( n . OperationalStatus
																		 == OperationalStatus . Up )
																	&& ( n . Supports (
																			NetworkInterfaceComponent . IPv4 ) ) ) .
														Select ( n => n . GetIPProperties ( ) ) .
														Min (
															 p => Math . Min (
																			  p . GetIPv4Properties ( ) . Mtu ,
																			  p . GetIPv6Properties ( ) . Mtu ) ) ;
			}
			catch
			{
				// ignored
			}

			MaximumQueryMessageSize = Math . Max ( 512 , maximumMessageSize ) ;

			IsUdpEnabled = true ;
			IsTcpEnabled = false ;
		}

		private static readonly List <IPAddress> _addresses =
			new List <IPAddress> { IPAddress . Parse ( "FF02::1:3" ) , IPAddress . Parse ( "224.0.0.252" ) , } ;

		/// <summary>
		///     Queries for specified records.
		/// </summary>
		/// <param name="name"> Name, that should be queried </param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <returns> All available responses on the local network </returns>
		public List <LlmnrMessage> Resolve ( DomainName name , RecordType recordType = RecordType . A )
		{
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) , "Name must be provided" ) ;
			}

			LlmnrMessage message = new LlmnrMessage { IsQuery = true , OperationCode = OperationCode . Query , } ;
			message . Questions . Add ( new DnsQuestion ( name , recordType , RecordClass . INet ) ) ;

			return SendMessageParallel ( message ) ;
		}

		/// <summary>
		///     Queries for specified records as an asynchronous operation.
		/// </summary>
		/// <param name="name"> Name, that should be queried </param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="token"> The token to monitor cancellation requests </param>
		/// <returns> All available responses on the local network </returns>
		public Task <List <LlmnrMessage>> ResolveAsync (
			DomainName        name ,
			RecordType        recordType = RecordType . A ,
			CancellationToken token      = default ( CancellationToken ) )
		{
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) , "Name must be provided" ) ;
			}

			LlmnrMessage message = new LlmnrMessage { IsQuery = true , OperationCode = OperationCode . Query , } ;
			message . Questions . Add ( new DnsQuestion ( name , recordType , RecordClass . INet ) ) ;

			return SendMessageParallelAsync ( message , token ) ;
		}

	}

}

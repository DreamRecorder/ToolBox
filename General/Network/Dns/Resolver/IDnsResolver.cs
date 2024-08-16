using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using DreamRecorder.ToolBox.Network.Dns.DnsRecord;

namespace DreamRecorder.ToolBox.Network.Dns.Resolver;

/// <summary>
///     Interface of a DNS resolver
/// </summary>
public interface IDnsResolver
{

	/// <summary>
	///     Clears the record cache
	/// </summary>
	void ClearCache ( );

	/// <summary>
	///     Queries a dns resolver for specified records.
	/// </summary>
	/// <typeparam name="T"> Type of records, that should be returned </typeparam>
	/// <param name="name"> Domain, that should be queried </param>
	/// <param name="recordType"> Type the should be queried </param>
	/// <param name="recordClass"> Class the should be queried </param>
	/// <returns>
	///     A list of matching
	///     <see cref="DnsRecordBase">records</see>
	/// </returns>
	List <T> Resolve <T> (
		DomainName  name ,
		RecordType  recordType  = RecordType.A ,
		RecordClass recordClass = RecordClass.INet ) where T : DnsRecordBase;

	/// <summary>
	///     Queries a dns resolver for specified records as an asynchronous operation.
	/// </summary>
	/// <typeparam name="T"> Type of records, that should be returned </typeparam>
	/// <param name="name"> Domain, that should be queried </param>
	/// <param name="recordType"> Type the should be queried </param>
	/// <param name="recordClass"> Class the should be queried </param>
	/// <param name="token"> The token to monitor cancellation requests </param>
	/// <returns>
	///     A list of matching
	///     <see cref="DnsRecordBase">records</see>
	/// </returns>
	Task <List <T>> ResolveAsync <T> (
		DomainName        name ,
		RecordType        recordType  = RecordType.A ,
		RecordClass       recordClass = RecordClass.INet ,
		CancellationToken token       = default ( CancellationToken ) ) where T : DnsRecordBase;

}

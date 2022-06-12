﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading ;
using System . Threading . Tasks ;

using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;

namespace DreamRecorder . ToolBox . Network . Dns . Resolver
{

	/// <summary>
	///     Extension methods for DNSSEC resolvers
	/// </summary>
	public static class DnsSecResolverExtensions
	{

		/// <summary>
		///     Queries a dns resolver for specified records.
		/// </summary>
		/// <typeparam name="T"> Type of records, that should be returned </typeparam>
		/// <param name="resolver"> The resolver instance, that should be used for queries </param>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="recordClass"> Class the should be queried </param>
		/// <returns>
		///     The validating result and a list of matching
		///     <see cref="DnsRecordBase">records</see>
		/// </returns>
		public static DnsSecResult <T> ResolveSecure
			<T> (
				this IDnsSecResolver resolver ,
				string               name ,
				RecordType           recordType  = RecordType . A ,
				RecordClass          recordClass = RecordClass . INet ) where T : DnsRecordBase
			=> resolver . ResolveSecure <T> ( DomainName . Parse ( name ) , recordType , recordClass ) ;

		/// <summary>
		///     Queries a dns resolver for specified records as an asynchronous operation.
		/// </summary>
		/// <typeparam name="T"> Type of records, that should be returned </typeparam>
		/// <param name="resolver"> The resolver instance, that should be used for queries </param>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="recordClass"> Class the should be queried </param>
		/// <param name="token"> The token to monitor cancellation requests </param>
		/// <returns>
		///     A list of matching
		///     <see cref="DnsRecordBase">records</see>
		/// </returns>
		public static Task <DnsSecResult <T>> ResolveSecureAsync <T> (
			this IDnsSecResolver resolver ,
			string               name ,
			RecordType           recordType  = RecordType . A ,
			RecordClass          recordClass = RecordClass . INet ,
			CancellationToken    token       = default ( CancellationToken ) ) where T : DnsRecordBase
			=> resolver . ResolveSecureAsync <T> ( DomainName . Parse ( name ) , recordType , recordClass , token ) ;

	}

}

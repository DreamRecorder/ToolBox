﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;
using System . Threading ;
using System . Threading . Tasks ;

using DreamRecorder . ToolBox . Network . Dns . Cache ;
using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;

namespace DreamRecorder . ToolBox . Network . Dns . Resolver
{

	/// <summary>
	///     <para>Stub resolver</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
	///     </para>
	/// </summary>
	public class DnsStubResolver : IDnsResolver
	{

		private readonly DnsClient _dnsClient ;

		private DnsCache _cache = new DnsCache ( ) ;

		/// <summary>
		///     Provides a new instance using the local configured DNS servers
		/// </summary>
		public DnsStubResolver ( ) : this ( DnsClient . Default ) { }

		/// <summary>
		///     Provides a new instance using a custom
		///     <see cref="DnsClient">DNS client</see>
		/// </summary>
		/// <param name="dnsClient">
		///     The
		///     <see cref="DnsClient">DNS client</see>
		///     to use
		/// </param>
		public DnsStubResolver ( DnsClient dnsClient ) => _dnsClient = dnsClient ;

		/// <summary>
		///     Provides a new instance using a list of custom DNS servers and a default query timeout of 10 seconds
		/// </summary>
		/// <param name="servers"> The list of servers to use </param>
		public DnsStubResolver ( IEnumerable <IPAddress> servers ) : this ( new DnsClient ( servers , 10000 ) ) { }

		/// <summary>
		///     Provides a new instance using a list of custom DNS servers and a custom query timeout
		/// </summary>
		/// <param name="servers"> The list of servers to use </param>
		/// <param name="queryTimeout"> The query timeout in milliseconds </param>
		public DnsStubResolver ( IEnumerable <IPAddress> servers , int queryTimeout ) : this (
		 new DnsClient ( servers , queryTimeout ) )
		{
		}

		/// <summary>
		///     Queries a the upstream DNS server(s) for specified records.
		/// </summary>
		/// <typeparam name="T"> Type of records, that should be returned </typeparam>
		/// <param name="name"> Domain, that should be queried </param>
		/// <param name="recordType"> Type the should be queried </param>
		/// <param name="recordClass"> Class the should be queried </param>
		/// <returns>
		///     A list of matching
		///     <see cref="DnsRecordBase">records</see>
		/// </returns>
		public List <T> Resolve <T> (
			DomainName  name ,
			RecordType  recordType  = RecordType . A ,
			RecordClass recordClass = RecordClass . INet ) where T : DnsRecordBase
		{
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) , "Name must be provided" ) ;
			}

			if ( _cache . TryGetRecords ( name , recordType , recordClass , out List <T> records ) )
			{
				return records ;
			}

			DnsMessage msg = _dnsClient . Resolve ( name , recordType , recordClass ) ;

			if ( ( msg == null )
				 || ( ( msg . ReturnCode != ReturnCode . NoError ) && ( msg . ReturnCode != ReturnCode . NxDomain ) ) )
			{
				throw new Exception ( "DNS request failed" ) ;
			}

			CNameRecord cName = msg . AnswerRecords .
									  Where (
											 x => ( x . RecordType     == RecordType . CName )
												  && ( x . RecordClass == recordClass )
												  && x . Name . Equals ( name ) ) .
									  OfType <CNameRecord> ( ) .
									  FirstOrDefault ( ) ;

			if ( cName != null )
			{
				records = msg . AnswerRecords . Where ( x => x . Name . Equals ( cName . CanonicalName ) ) .
								OfType <T> ( ) .
								ToList ( ) ;
				if ( records . Count > 0 )
				{
					_cache . Add (
								  name ,
								  recordType ,
								  recordClass ,
								  records ,
								  msg . ReturnCode ,
								  DnsSecValidationResult . Indeterminate ,
								  records . Min ( x => x . TimeToLive ) ) ;
					return records ;
				}

				if ( name . Equals ( cName . CanonicalName ) )
				{
					throw new Exception ( $"CNAME loop detected for '{name}'." ) ;
				}

				records = Resolve <T> ( cName . CanonicalName , recordType , recordClass ) ;

				if ( records . Count > 0 )
				{
					_cache . Add (
								  name ,
								  recordType ,
								  recordClass ,
								  records ,
								  msg . ReturnCode ,
								  DnsSecValidationResult . Indeterminate ,
								  records . Min ( x => x . TimeToLive ) ) ;
				}

				return records ;
			}

			records = msg . AnswerRecords . Where ( x => x . Name . Equals ( name ) ) . OfType <T> ( ) . ToList ( ) ;

			if ( records . Count > 0 )
			{
				_cache . Add (
							  name ,
							  recordType ,
							  recordClass ,
							  records ,
							  msg . ReturnCode ,
							  DnsSecValidationResult . Indeterminate ,
							  records . Min ( x => x . TimeToLive ) ) ;
			}

			return records ;
		}

		/// <summary>
		///     Queries a the upstream DNS server(s) for specified records as an asynchronous operation.
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
		public async Task <List <T>> ResolveAsync <T> (
			DomainName        name ,
			RecordType        recordType  = RecordType . A ,
			RecordClass       recordClass = RecordClass . INet ,
			CancellationToken token       = default ( CancellationToken ) ) where T : DnsRecordBase
		{
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) , "Name must be provided" ) ;
			}

			if ( _cache . TryGetRecords ( name , recordType , recordClass , out List <T> records ) )
			{
				return records ;
			}

			DnsMessage msg = await _dnsClient . ResolveAsync ( name , recordType , recordClass , null , token ) ;

			if ( ( msg == null )
				 || ( ( msg . ReturnCode != ReturnCode . NoError ) && ( msg . ReturnCode != ReturnCode . NxDomain ) ) )
			{
				throw new Exception ( "DNS request failed" ) ;
			}

			CNameRecord cName = msg . AnswerRecords .
									  Where (
											 x => ( x . RecordType     == RecordType . CName )
												  && ( x . RecordClass == recordClass )
												  && x . Name . Equals ( name ) ) .
									  OfType <CNameRecord> ( ) .
									  FirstOrDefault ( ) ;

			if ( cName != null )
			{
				records = msg . AnswerRecords .
								Where (
									   x => ( x . RecordType     == recordType )
											&& ( x . RecordClass == recordClass )
											&& x . Name . Equals ( cName . CanonicalName ) ) .
								OfType <T> ( ) .
								ToList ( ) ;
				if ( records . Count > 0 )
				{
					_cache . Add (
								  name ,
								  recordType ,
								  recordClass ,
								  records ,
								  msg . ReturnCode ,
								  DnsSecValidationResult . Indeterminate ,
								  Math . Min ( cName . TimeToLive , records . Min ( x => x . TimeToLive ) ) ) ;
					return records ;
				}

				if ( name . Equals ( cName . CanonicalName ) )
				{
					throw new Exception ( $"CNAME loop detected for '{name}'." ) ;
				}

				records = await ResolveAsync <T> ( cName . CanonicalName , recordType , recordClass , token ) ;

				if ( records . Count > 0 )
				{
					_cache . Add (
								  name ,
								  recordType ,
								  recordClass ,
								  records ,
								  msg . ReturnCode ,
								  DnsSecValidationResult . Indeterminate ,
								  Math . Min ( cName . TimeToLive , records . Min ( x => x . TimeToLive ) ) ) ;
				}

				return records ;
			}

			records = msg . AnswerRecords . Where ( x => x . Name . Equals ( name ) ) . OfType <T> ( ) . ToList ( ) ;

			if ( records . Count > 0 )
			{
				_cache . Add (
							  name ,
							  recordType ,
							  recordClass ,
							  records ,
							  msg . ReturnCode ,
							  DnsSecValidationResult . Indeterminate ,
							  records . Min ( x => x . TimeToLive ) ) ;
			}

			return records ;
		}

		/// <summary>
		///     Clears the record cache
		/// </summary>
		public void ClearCache ( ) { _cache = new DnsCache ( ) ; }

	}

}

using System ;
using System . Collections ;
using System . Collections . Concurrent ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;
using DreamRecorder . ToolBox . Network . Dns . Resolver ;

namespace DreamRecorder . ToolBox . Network . Dns . Cache
{

	internal class DnsCacheRecordList <T> : List <T>
	{

		public ReturnCode ReturnCode { get ; set ; }

		public DnsSecValidationResult ValidationResult { get ; set ; }

	}

	internal class DnsCache
	{

		private readonly ConcurrentDictionary <CacheKey , CacheValue> _cache =
			new ConcurrentDictionary <CacheKey , CacheValue> ( ) ;

		public void Add <TRecord> (
			DomainName             name ,
			RecordType             recordType ,
			RecordClass            recordClass ,
			IEnumerable <TRecord>  records ,
			ReturnCode             returnCode ,
			DnsSecValidationResult validationResult ,
			int                    timeToLive ) where TRecord : DnsRecordBase
		{
			DnsCacheRecordList <DnsRecordBase> cacheValues = new DnsCacheRecordList <DnsRecordBase> ( ) ;
			cacheValues . AddRange ( records ) ;
			cacheValues . ReturnCode       = returnCode ;
			cacheValues . ValidationResult = validationResult ;

			Add ( name , recordType , recordClass , cacheValues , timeToLive ) ;
		}

		public void Add (
			DomainName                         name ,
			RecordType                         recordType ,
			RecordClass                        recordClass ,
			DnsCacheRecordList <DnsRecordBase> records ,
			int                                timeToLive )
		{
			CacheKey key = new CacheKey ( name , recordType , recordClass ) ;
			_cache . TryAdd ( key , new CacheValue ( records , timeToLive ) ) ;
		}

		public void RemoveExpiredItems ( )
		{
			DateTime utcNow = DateTime . UtcNow ;

			foreach ( KeyValuePair <CacheKey , CacheValue> kvp in _cache )
			{
				if ( kvp . Value . ExpireDateUtc < utcNow )
				{
					_cache . TryRemove ( kvp . Key , out CacheValue tmp ) ;
				}
			}
		}

		public bool TryGetRecords <TRecord> (
			DomainName         name ,
			RecordType         recordType ,
			RecordClass        recordClass ,
			out List <TRecord> records ) where TRecord : DnsRecordBase
		{
			CacheKey key    = new CacheKey ( name , recordType , recordClass ) ;
			DateTime utcNow = DateTime . UtcNow ;

			if ( _cache . TryGetValue ( key , out CacheValue cacheValue ) )
			{
				if ( cacheValue . ExpireDateUtc < utcNow )
				{
					_cache . TryRemove ( key , out cacheValue ) ;
					records = null ;
					return false ;
				}

				int ttl = ( int )( cacheValue . ExpireDateUtc - utcNow ) . TotalSeconds ;

				records = new List <TRecord> ( ) ;

				records . AddRange (
									cacheValue . Records . OfType <TRecord> ( ) .
												 Select (
														 x =>
														 {
															 TRecord record = x . Clone <TRecord> ( ) ;
															 record . TimeToLive = ttl ;
															 return record ;
														 } ) ) ;

				return true ;
			}

			records = null ;
			return false ;
		}

		public bool TryGetRecords <TRecord> (
			DomainName                       name ,
			RecordType                       recordType ,
			RecordClass                      recordClass ,
			out DnsCacheRecordList <TRecord> records ) where TRecord : DnsRecordBase
		{
			CacheKey key    = new CacheKey ( name , recordType , recordClass ) ;
			DateTime utcNow = DateTime . UtcNow ;

			if ( _cache . TryGetValue ( key , out CacheValue cacheValue ) )
			{
				if ( cacheValue . ExpireDateUtc < utcNow )
				{
					_cache . TryRemove ( key , out cacheValue ) ;
					records = null ;
					return false ;
				}

				int ttl = ( int )( cacheValue . ExpireDateUtc - utcNow ) . TotalSeconds ;

				records = new DnsCacheRecordList <TRecord> ( ) ;

				records . AddRange (
									cacheValue . Records . OfType <TRecord> ( ) .
												 Select (
														 x =>
														 {
															 TRecord record = x . Clone <TRecord> ( ) ;
															 record . TimeToLive = ttl ;
															 return record ;
														 } ) ) ;

				records . ReturnCode       = cacheValue . Records . ReturnCode ;
				records . ValidationResult = cacheValue . Records . ValidationResult ;

				return true ;
			}

			records = null ;
			return false ;
		}

		private class CacheKey
		{

			private readonly int _hashCode ;

			private readonly DomainName _name ;

			private readonly RecordClass _recordClass ;

			private readonly RecordType _recordType ;

			public CacheKey ( DomainName name , RecordType recordType , RecordClass recordClass )
			{
				_name        = name ;
				_recordClass = recordClass ;
				_recordType  = recordType ;

				_hashCode = name . GetHashCode ( ) ^ ( 7 * ( int )recordType ) ^ ( 11 * ( int )recordClass ) ;
			}

			public override bool Equals ( object obj )
			{
				if ( obj is not CacheKey other )
				{
					return false ;
				}

				return ( _recordType     == other . _recordType )
					   && ( _recordClass == other . _recordClass )
					   && ( _name . Equals ( other . _name ) ) ;
			}


			public override int GetHashCode ( ) => _hashCode ;

			public override string ToString ( )
				=> _name + " " + _recordClass . ToShortString ( ) + " " + _recordType . ToShortString ( ) ;

		}

		private class CacheValue
		{

			public DateTime ExpireDateUtc { get ; }

			public DnsCacheRecordList <DnsRecordBase> Records { get ; }

			public CacheValue ( DnsCacheRecordList <DnsRecordBase> records , int timeToLive )
			{
				Records       = records ;
				ExpireDateUtc = DateTime . UtcNow . AddSeconds ( timeToLive ) ;
			}

		}

	}

}

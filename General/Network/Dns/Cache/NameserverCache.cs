using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace DreamRecorder.ToolBox.Network.Dns.Cache;

internal class NameserverCache
{

	private readonly ConcurrentDictionary <DomainName , HashSet <CacheValue>> _cache =
		new ConcurrentDictionary <DomainName , HashSet <CacheValue>> ( );

	public void Add ( DomainName zoneName , IPAddress address , int timeToLive )
	{
		if ( _cache.TryGetValue ( zoneName , out HashSet <CacheValue> addresses ) )
		{
			lock ( addresses )
			{
				addresses.Add ( new CacheValue ( timeToLive , address ) );
			}
		}
		else
		{
			_cache.TryAdd ( zoneName , new HashSet <CacheValue> { new CacheValue ( timeToLive , address ) , } );
		}
	}

	public void RemoveExpiredItems ( )
	{
		DateTime utcNow = DateTime.UtcNow;

		foreach ( KeyValuePair <DomainName , HashSet <CacheValue>> kvp in _cache )
		{
			lock ( kvp.Value )
			{
				kvp.Value.RemoveWhere ( x => x.ExpireDateUtc < utcNow );
				if ( kvp.Value.Count == 0 )
				{
					_cache.TryRemove ( kvp.Key , out HashSet <CacheValue> tmp );
				}
			}
		}
	}

	public bool TryGetAddresses ( DomainName zoneName , out List <IPAddress> addresses )
	{
		DateTime utcNow = DateTime.UtcNow;

		if ( _cache.TryGetValue ( zoneName , out HashSet <CacheValue> cacheValues ) )
		{
			addresses = new List <IPAddress> ( );
			bool needsCleanup = false;

			lock ( cacheValues )
			{
				foreach ( CacheValue cacheValue in cacheValues )
				{
					if ( cacheValue.ExpireDateUtc < utcNow )
					{
						needsCleanup = true;
					}
					else
					{
						addresses.Add ( cacheValue.Address );
					}
				}

				if ( needsCleanup )
				{
					cacheValues.RemoveWhere ( x => x.ExpireDateUtc < utcNow );
					if ( cacheValues.Count == 0 )
#pragma warning disable 0728
					{
						_cache.TryRemove ( zoneName , out cacheValues );
					}
#pragma warning restore 0728
				}
			}

			if ( addresses.Count > 0 )
			{
				return true;
			}
		}

		addresses = null;
		return false;
	}

	private class CacheValue
	{

		public IPAddress Address { get; }

		public DateTime ExpireDateUtc { get; }

		public CacheValue ( int timeToLive , IPAddress address )
		{
			ExpireDateUtc = DateTime.UtcNow.AddSeconds ( timeToLive );
			Address       = address;
		}

		public override bool Equals ( object obj )
		{
			if ( obj is not CacheValue second )
			{
				return false;
			}

			return Address.Equals ( second.Address );
		}

		public override int GetHashCode ( ) => Address.GetHashCode ( );

	}

}

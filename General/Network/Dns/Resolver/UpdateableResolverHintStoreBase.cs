using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;

using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;
using DreamRecorder . ToolBox . Network . Dns . DnsSec ;

namespace DreamRecorder . ToolBox . Network . Dns . Resolver
{

	/// <summary>
	///     Base class for a ResolverHintStore, which has an updateable local storage for the hints
	/// </summary>
	public abstract class UpdateableResolverHintStoreBase : IResolverHintStore
	{

		private bool _isInitiated ;

		private List <DsRecord> _rootKeys ;

		private List <IPAddress> _rootServers ;

		/// <summary>
		///     List of hints to the root servers
		/// </summary>
		public List <IPAddress> RootServers
		{
			get
			{
				EnsureInit ( ) ;
				return _rootServers ;
			}
			private set => _rootServers = value ;
		}

		/// <summary>
		///     List of DsRecords of the root zone
		/// </summary>
		public List <DsRecord> RootKeys
		{
			get
			{
				EnsureInit ( ) ;
				return _rootKeys ;
			}
			private set => _rootKeys = value ;
		}

		/// <summary>
		///     Forces to update all hints using the given resolver
		/// </summary>
		/// <param name="resolver">The resolver to use for resolving the new hints</param>
		public void Update ( IDnsResolver resolver )
		{
			Zone zone = new Zone ( DomainName . Root ) ;

			List <NsRecord> nameServer = resolver . Resolve <NsRecord> ( DomainName . Root , RecordType . Ns ) ;
			zone . AddRange ( nameServer ) ;

			foreach ( NsRecord nsRecord in nameServer )
			{
				zone . AddRange ( resolver . Resolve <ARecord> ( nsRecord . NameServer ) ) ;
				zone . AddRange ( resolver . Resolve <AaaaRecord> ( nsRecord . NameServer , RecordType . Aaaa ) ) ;
			}

			zone . AddRange (
							resolver . Resolve <DnsKeyRecord> ( DomainName . Root , RecordType . DnsKey ) .
										Where ( x => x . IsSecureEntryPoint ) ) ;

			LoadZoneInternal ( zone ) ;

			Save ( zone ) ;
		}

		private void EnsureInit ( )
		{
			if ( ! _isInitiated )
			{
				Zone zone = Load ( ) ;

				LoadZoneInternal ( zone ) ;

				_isInitiated = true ;
			}
		}

		private void LoadZoneInternal ( Zone zone )
		{
			IEnumerable <DomainName> nameServers = zone . OfType <NsRecord> ( ) .
														Where ( x => x . Name == DomainName . Root ) .
														Select ( x => x . NameServer ) ;
			RootServers = zone .
						Where ( x => x . RecordType == RecordType . A || x . RecordType == RecordType . Aaaa ) .
						Join ( nameServers , x => x . Name , x => x , ( x , y ) => ( ( IAddressRecord )x ) . Address ) .
						ToList ( ) ;
			RootKeys = zone . OfType <DnsKeyRecord> ( ) .
							Where ( x => ( x . Name == DomainName . Root ) && x . IsSecureEntryPoint ) .
							Select ( x => new DsRecord ( x , x . TimeToLive , DnsSecDigestType . Sha256 ) ) .
							ToList ( ) ;
		}

		/// <summary>
		///     Saves the hints to a local storage
		/// </summary>
		/// <param name="zone"></param>
		protected abstract void Save ( Zone zone ) ;

		/// <summary>
		///     Loads the hints from a local storage
		/// </summary>
		/// <returns></returns>
		protected abstract Zone Load ( ) ;

	}

}

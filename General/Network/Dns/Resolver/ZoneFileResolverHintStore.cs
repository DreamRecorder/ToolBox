using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;

using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;

namespace DreamRecorder . ToolBox . Network . Dns . Resolver
{

	/// <summary>
	///     Updateable Resolver HintStore using a local zone file for the hints
	/// </summary>
	public class ZoneFileResolverHintStore : UpdateableResolverHintStoreBase
	{

		private readonly string _fileName ;

		/// <summary>
		///     Creates a new instance of the ZoneFileResolverHintStore class
		/// </summary>
		/// <param name="fileName">The path to the local zone file containing the hints</param>
		public ZoneFileResolverHintStore ( string fileName ) => _fileName = fileName ;

		/// <summary>
		///     Loads the hints from the local file
		/// </summary>
		/// <returns></returns>
		protected override Zone Load ( )
		{
			if ( ! File . Exists ( _fileName ) )
			{
				throw new FileNotFoundException ( ) ;
			}

			return Zone . ParseMasterFile ( DomainName . Root , _fileName ) ;
		}

		/// <summary>
		///     Saves the hints to the local file
		/// </summary>
		/// <param name="zone">The zone to save</param>
		protected override void Save ( Zone zone )
		{
			using StreamWriter writer = new StreamWriter ( _fileName ) ;
			foreach ( DnsRecordBase record in zone )
			{
				writer . WriteLine ( record . ToString ( ) ) ;
			}
		}

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>IPv6 address</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc3596">RFC 3596</see>
	///     </para>
	/// </summary>
	public class AaaaRecord : AddressRecordBase
	{

		protected internal override int MaximumRecordDataLength => 16 ;

		internal AaaaRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the AaaaRecord class
		/// </summary>
		/// <param name="name"> Domain name of the host </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="address"> IP address of the host </param>
		public AaaaRecord ( DomainName name , int timeToLive , IPAddress address ) : base (
																							name ,
																							RecordType . Aaaa ,
																							timeToLive ,
																							address ?? IPAddress . IPv6None )
		{
		}

	}

}

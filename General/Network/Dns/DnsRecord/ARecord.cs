using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Host address record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
	///     </para>
	/// </summary>
	public class ARecord : AddressRecordBase
	{

		protected internal override int MaximumRecordDataLength => 4 ;

		internal ARecord ( ) { }

		/// <summary>
		///     Creates a new instance of the ARecord class
		/// </summary>
		/// <param name="name"> Domain name of the host </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="address"> IP address of the host </param>
		public ARecord ( DomainName name , int timeToLive , IPAddress address ) : base (
																						name ,
																						RecordType . A ,
																						timeToLive ,
																						address ?? IPAddress . None )
		{
		}

	}

}

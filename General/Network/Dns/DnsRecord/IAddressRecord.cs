using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     Interface for host address providing
	///     <see cref="DnsRecordBase">records</see>
	/// </summary>
	public interface IAddressRecord
	{

		/// <summary>
		///     IP address of the host
		/// </summary>
		IPAddress Address { get ; }

	}

}

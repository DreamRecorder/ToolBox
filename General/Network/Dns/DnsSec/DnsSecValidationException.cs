using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsSec
{

	/// <summary>
	///     The exception that is thrown when a DNSSEC validation fails
	/// </summary>
	public class DnsSecValidationException : Exception
	{

		internal DnsSecValidationException ( string message ) : base ( message ) { }

	}

}

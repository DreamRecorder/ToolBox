using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network
{

	public interface IAddress
	{

		Memory <byte> AddressBytes { get ; }

	}

}

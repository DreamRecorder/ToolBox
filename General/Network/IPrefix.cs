using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network
{

	public interface IPrefix <TAddress> where TAddress : IAddress
	{

		bool Contains ( TAddress address ) ;

	}

}

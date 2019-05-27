using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . CommandLine
{

	public interface ISettingProvider
	{

		T GetValue <T> ( string name , T defaultValue = default ) ;

	}

}

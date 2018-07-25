using System ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General . ColorMap
{

	public abstract class ColorMap
	{

		protected abstract HdrColor MapOverride ( double value ) ;

		public HdrColor Map ( double value ) { return MapOverride ( value ) ; }

	}

}

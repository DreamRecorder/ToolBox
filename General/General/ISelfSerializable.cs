using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	public interface ISelfSerializable
	{

		/// <summary>
		/// </summary>
		/// <returns></returns>
		[NotNull]
		XElement ToXElement ( ) ;

	}


}

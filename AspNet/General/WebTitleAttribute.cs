using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . AspNet . General ;

[AttributeUsage ( AttributeTargets . Assembly )]
public sealed class WebTitleAttribute : Attribute
{

	public string Name { get ; }

	public WebTitleAttribute ( string name ) => Name = name ;

}

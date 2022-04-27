using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General ;

public static class DelegateExtensions
{

	public static T ConvertTo <T> ( this Delegate sourceDelegate ) where T : Delegate
		=> ( T )Delegate . CreateDelegate ( typeof ( T ) , sourceDelegate . Target , sourceDelegate . Method ) ;

}

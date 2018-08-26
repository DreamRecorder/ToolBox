using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class SelfSerializableExtensions
	{

		public static string ToXmlString ( [NotNull] this ISelfSerializable item )
		{
			if ( item == null )
			{
				throw new ArgumentNullException ( nameof(item) ) ;
			}

			return item . ToXElement ( ) . ToString ( ) ;
		}

	}

}

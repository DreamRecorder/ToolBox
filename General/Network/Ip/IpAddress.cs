using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network . Ip
{

	public abstract class IpAddress : Address
	{

		public static explicit operator IpAddress ( [NotNull] string address )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof ( address ) ) ;
			}

			if ( address . Contains ( ':' ) )
			{
				return new Ipv6Address ( address ) ;
			}

			return new Ipv4Address ( address ) ;
		}

	}

}

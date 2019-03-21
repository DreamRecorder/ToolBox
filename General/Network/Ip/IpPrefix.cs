using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network . Ip
{

	public abstract class IpPrefix : Prefix
	{

		public static explicit operator IpPrefix ( [NotNull] string address )
		{
			if ( address == null )
			{
				throw new ArgumentNullException ( nameof (address) ) ;
			}

			if ( address . Contains ( ':' ) )
			{
				return new Ipv6Prefix ( address ) ;
			}

			return new Ipv4Prefix ( address ) ;
		}

	}

}

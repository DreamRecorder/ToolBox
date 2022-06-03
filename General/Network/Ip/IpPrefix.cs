using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network . Ip
{

	public abstract class IpPrefix : Prefix
	{

		public static explicit operator IpPrefix ( [NotNull] string prefix )
		{
			if ( prefix == null )
			{
				throw new ArgumentNullException ( nameof ( prefix ) ) ;
			}

			if ( prefix . Contains ( ':' ) )
			{
				return new Ipv6Prefix ( prefix ) ;
			}

			return new Ipv4Prefix ( prefix ) ;
		}

	}

}

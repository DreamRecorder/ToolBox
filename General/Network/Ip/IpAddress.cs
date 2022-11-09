using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;
using System . Net . Sockets ;

using DreamRecorder . ToolBox . General ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . Network . Ip
{

	public abstract class IpAddress : Address
	{

		/// <summary>
		///     Returns the reverse lookup address of an IPAddress
		/// </summary>
		/// <returns> A string with the reverse lookup address </returns>
		public abstract string GetReverseLookupAddress ( ) ;

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

		public static explicit operator IpAddress ( IPAddress address )
		{
			switch ( address . AddressFamily )
			{
				case AddressFamily . InterNetwork :
				{
					return new Ipv4Address ( address . GetAddressBytes ( ) . CastToStruct <uint> ( ) ) ;
				}
				case AddressFamily . InterNetworkV6 :
				{
					return new Ipv6Address ( address . GetAddressBytes ( ) ) ;
				}
				default :
				{
					throw new InvalidOperationException ( ) ;
				}
			}
		}

	}

}

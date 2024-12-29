using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using JetBrains.Annotations;

using static DreamRecorder.ToolBox.Network.Ip.Ipv6Address;

namespace DreamRecorder.ToolBox.Network.Ip;

public class Ipv6Prefix : IpPrefix
{

	public override AddressType Type => AddressType.Ipv6;

	public Ipv6Prefix ( )
	{
		AddressBytes = new byte[ 16 ];
		Length       = 0;
	}

	private Ipv6Prefix ( Memory <byte> address , byte length )
	{
		if ( address.Length != 6 )
		{
			throw new ArgumentException ( ); //todo
		}

		AddressBytes = address;
		Length       = length;
	}

	public Ipv6Prefix ( [NotNull] string addressString )
	{
		if ( addressString == null )
		{
			throw new ArgumentNullException ( nameof ( addressString ) );
		}

		string [ ] data = addressString.Split ( '/' );

		switch ( data.Length )
		{
			case 2 :
			{
				Ipv6Address address = new Ipv6Address ( data [ 0 ] );

				AddressBytes = address.AddressBytes;

				Length = Convert.ToByte ( data [ 1 ] );

				break;
			}

			case 1 :
			{
				Ipv6Address address = new Ipv6Address ( data [ 0 ] );

				AddressBytes = address.AddressBytes;

				Length = 128;

				break;
			}

			default :
			{
				throw new ArgumentException ( );
			}
		}
	}

	public override object Clone ( ) => new Ipv6Prefix ( AddressBytes , Length );

	public static explicit operator Ipv6Prefix ( [NotNull] string address )
	{
		if ( address == null )
		{
			throw new ArgumentNullException ( nameof ( address ) );
		}

		return new Ipv6Prefix ( address );
	}

	public string ToString(AddressStyle style)
	{
		StringBuilder builder = new StringBuilder();

		for (int i = 0; i < AddressBytes.Length; i += 2)
		{
			int segment = (ushort)(AddressBytes.Span[i] << 8) | AddressBytes.Span[i + 1];

			if (style.HasFlag(AddressStyle.LeadingZero))
			{
				builder.AppendFormat("{0:X4}", segment);
			}
			else
			{
				builder.AppendFormat("{0:X}", segment);
			}

			if (i + 2 != AddressBytes.Length)
			{
				builder.Append(':');
			}
		}

		if (!style.HasFlag(AddressStyle.NoOmitHextets))
		{
			MatchCollection matches = ShortenRegex.Matches(builder.ToString());

			if (matches.MaxBy(match => match.Length) is Match longestMatch)
			{
				if (longestMatch.Index + longestMatch.Length == builder.Length)
				{
					builder.Replace(longestMatch.Value, "::", longestMatch.Index, longestMatch.Length);
				}
				else
				{
					builder.Replace(longestMatch.Value, ":", longestMatch.Index, longestMatch.Length);
				}
			}
		}

		builder.Append('/');
		builder.Append(Length);

		return builder.ToString();
	}

	public override string ToString ( ) => ToString(AddressStyle.Compressed);

}

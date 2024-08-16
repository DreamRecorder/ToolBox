using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns.DnsSec;

/// <summary>
///     DNSSEC algorithm type
/// </summary>
public enum NSec3HashAlgorithm : byte
{

	/// <summary>
	///     <para>RSA MD5</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc5155">RFC 5155</see>
	///     </para>
	/// </summary>
	Sha1 = 1 ,

}

internal static class NSec3HashAlgorithmHelper
{

	public static int GetPriority ( this NSec3HashAlgorithm algorithm )
	{
		switch ( algorithm )
		{
			case NSec3HashAlgorithm.Sha1 :
				return 1;

			default :
				throw new NotSupportedException ( );
		}
	}

	public static bool IsSupported ( this NSec3HashAlgorithm algorithm )
	{
		switch ( algorithm )
		{
			case NSec3HashAlgorithm.Sha1 :
				return true;

			default :
				return false;
		}
	}

}

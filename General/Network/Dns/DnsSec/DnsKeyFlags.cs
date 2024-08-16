using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns.DnsSec;

[Flags]
public enum DnsKeyFlags : ushort
{

	/// <summary>
	///     <para>ZONE</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc3755">RFC 3755</see>
	///         and
	///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
	///     </para>
	/// </summary>
	Zone = 256 ,

	/// <summary>
	///     <para>REVOKE</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc5011">RFC 5011</see>
	///     </para>
	/// </summary>
	Revoke = 128 ,

	/// <summary>
	///     <para>Secure Entry Point (SEP)</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc3755">RFC 3755</see>
	///         and
	///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
	///     </para>
	/// </summary>
	SecureEntryPoint = 1 ,

}

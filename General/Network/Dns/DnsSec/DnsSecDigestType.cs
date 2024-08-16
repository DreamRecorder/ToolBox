﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns.DnsSec;

/// <summary>
///     Type of DNSSEC digest
/// </summary>
public enum DnsSecDigestType : byte
{

	/// <summary>
	///     <para>SHA-1</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc3658">RFC 3658</see>
	///     </para>
	/// </summary>
	Sha1 = 1 ,

	/// <summary>
	///     <para>SHA-256</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc4509">RFC 4509</see>
	///     </para>
	/// </summary>
	Sha256 = 2 ,

	/// <summary>
	///     <para>GOST R 34.11-94</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc5933">RFC 5933</see>
	///     </para>
	/// </summary>
	EccGost = 3 ,

	/// <summary>
	///     <para>SHA-384</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc6605">RFC 6605</see>
	///     </para>
	/// </summary>
	Sha384 = 4 ,

}

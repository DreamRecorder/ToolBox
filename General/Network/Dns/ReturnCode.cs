﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns
{

	/// <summary>
	///     Result of a dns request
	/// </summary>
	public enum ReturnCode : ushort
	{

		/// <summary>
		///     <para>No error</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
		///     </para>
		/// </summary>
		NoError = 0 ,

		/// <summary>
		///     <para>Format error</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
		///     </para>
		/// </summary>
		FormatError = 1 ,

		/// <summary>
		///     <para>Server failure</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
		///     </para>
		/// </summary>
		ServerFailure = 2 ,

		/// <summary>
		///     <para>Non-existent domain</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
		///     </para>
		/// </summary>
		NxDomain = 3 ,

		/// <summary>
		///     <para>Not implemented</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
		///     </para>
		/// </summary>
		NotImplemented = 4 ,

		/// <summary>
		///     <para>Query refused</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
		///     </para>
		/// </summary>
		Refused = 5 ,

		/// <summary>
		///     <para>Name exists when it should not</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2136">RFC 2136</see>
		///     </para>
		/// </summary>

		// ReSharper disable once InconsistentNaming
		YXDomain = 6 ,

		/// <summary>
		///     <para>Record exists when it should not</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2136">RFC 2136</see>
		///     </para>
		/// </summary>

		// ReSharper disable once InconsistentNaming
		YXRRSet = 7 ,

		/// <summary>
		///     <para>Record that should exist does not</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2136">RFC 2136</see>
		///     </para>
		/// </summary>

		// ReSharper disable once InconsistentNaming
		NXRRSet = 8 ,

		/// <summary>
		///     <para>Server is not authoritative for zone</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2136">RFC 2136</see>
		///     </para>
		/// </summary>
		NotAuthoritative = 9 ,

		/// <summary>
		///     <para>Name not contained in zone</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2136">RFC 2136</see>
		///     </para>
		/// </summary>
		NotZone = 10 ,

		/// <summary>
		///     <para>EDNS version is not supported by responder</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2671">RFC 2671</see>
		///     </para>
		/// </summary>
		BadVersion = 16 ,

		/// <summary>
		///     <para>TSIG signature failure</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2845">RFC 2845</see>
		///     </para>
		/// </summary>
		BadSig = 16 ,

		/// <summary>
		///     <para>Key not recognized</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2845">RFC 2845</see>
		///     </para>
		/// </summary>
		BadKey = 17 ,

		/// <summary>
		///     <para>Signature out of time window</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2845">RFC 2845</see>
		///     </para>
		/// </summary>
		BadTime = 18 ,

		/// <summary>
		///     <para>Bad TKEY mode</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2930">RFC 2930</see>
		///     </para>
		/// </summary>
		BadMode = 19 ,

		/// <summary>
		///     <para>Duplicate key name</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2930">RFC 2930</see>
		///     </para>
		/// </summary>
		BadName = 20 ,

		/// <summary>
		///     <para>Algorithm not supported</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2930">RFC 2930</see>
		///     </para>
		/// </summary>
		BadAlg = 21 ,

		/// <summary>
		///     <para>Bad truncation of TSIG record</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc4635">RFC 4635</see>
		///     </para>
		/// </summary>
		BadTrunc = 22 ,

		/// <summary>
		///     <para>Bad/missing server cookie</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/draft-ietf-dnsop-cookies">draft-ietf-dnsop-cookies</see>
		///     </para>
		/// </summary>
		BadCookie = 23 ,

	}

}

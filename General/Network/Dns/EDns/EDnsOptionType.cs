﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . EDns
{

	/// <summary>
	///     ENDS Option types
	/// </summary>
	public enum EDnsOptionType : ushort
	{

		/// <summary>
		///     <para>Update Lease</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://files.dns-sd.org/draft-sekar-dns-llq.txt">draft-sekar-dns-llq</see>
		///     </para>
		/// </summary>
		LongLivedQuery = 1 ,

		/// <summary>
		///     <para>Update Lease</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://files.dns-sd.org/draft-sekar-dns-ul.txt">draft-sekar-dns-ul</see>
		///     </para>
		/// </summary>
		UpdateLease = 2 ,

		/// <summary>
		///     <para>Name server ID</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc5001">RFC 5001</see>
		///     </para>
		/// </summary>
		NsId = 3 ,

		/// <summary>
		///     <para>Owner</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/draft-cheshire-edns0-owner-option">draft-cheshire-edns0-owner-option</see>
		///     </para>
		/// </summary>
		Owner = 4 ,

		/// <summary>
		///     <para>DNSSEC Algorithm Understood</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc6975">RFC 6975</see>
		///     </para>
		/// </summary>
		DnssecAlgorithmUnderstood = 5 ,

		/// <summary>
		///     <para>DS Hash Understood</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc6975">RFC 6975</see>
		///     </para>
		/// </summary>
		DsHashUnderstood = 6 ,

		/// <summary>
		///     <para>NSEC3 Hash Understood</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc6975">RFC 6975</see>
		///     </para>
		/// </summary>
		Nsec3HashUnderstood = 7 ,

		/// <summary>
		///     <para>ClientSubnet</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/draft-vandergaast-edns-client-subnet">draft-vandergaast-edns-client-subnet</see>
		///     </para>
		/// </summary>
		ClientSubnet = 8 ,

		/// <summary>
		///     <para>Expire EDNS Option</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc7314">RFC 7314</see>
		///     </para>
		/// </summary>
		Expire = 9 ,

		/// <summary>
		///     <para>Cookie Option</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/draft-ietf-dnsop-cookies">draft-ietf-dnsop-cookies</see>
		///     </para>
		/// </summary>
		Cookie = 10 ,

	}

}

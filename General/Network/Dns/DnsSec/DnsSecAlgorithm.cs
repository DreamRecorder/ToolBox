﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsSec
{

	/// <summary>
	///     DNSSEC algorithm type
	/// </summary>
	public enum DnsSecAlgorithm : byte
	{

		/// <summary>
		///     <para>RSA MD5</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc3110">RFC 3110</see>
		///         and
		///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
		///     </para>
		/// </summary>
		RsaMd5 = 1 ,

		/// <summary>
		///     <para>Diffie Hellman</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc2539">RFC 2539</see>
		///     </para>
		/// </summary>
		DiffieHellman = 2 ,

		/// <summary>
		///     <para>DSA/SHA-1</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc3755">RFC 3755</see>
		///         and
		///         <see cref="!:http://tools.ietf.org/html/rfc2536">RFC 4034</see>
		///     </para>
		/// </summary>
		Dsa = 3 ,

		/// <summary>
		///     <para>RSA/SHA-1</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc3110">RFC 3110</see>
		///         and
		///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
		///     </para>
		/// </summary>
		RsaSha1 = 5 ,

		/// <summary>
		///     <para>DSA/SHA-1 using NSEC3 hashs</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc5155">RFC 5155</see>
		///     </para>
		/// </summary>
		DsaNsec3Sha1 = 6 ,

		/// <summary>
		///     <para>RSA/SHA-1 using NSEC3 hashs</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc5155">RFC 5155</see>
		///     </para>
		/// </summary>
		RsaSha1Nsec3Sha1 = 7 ,

		/// <summary>
		///     <para>RSA/SHA-256</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc5702">RFC 5702</see>
		///     </para>
		/// </summary>
		RsaSha256 = 8 ,

		/// <summary>
		///     <para>RSA/SHA-512</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc5702">RFC 5702</see>
		///     </para>
		/// </summary>
		RsaSha512 = 10 ,

		/// <summary>
		///     <para>GOST R 34.10-2001</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc5933">RFC 5933</see>
		///     </para>
		/// </summary>
		EccGost = 12 ,

		/// <summary>
		///     <para>ECDSA Curve P-256 with SHA-256</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc6605">RFC 6605</see>
		///     </para>
		/// </summary>
		EcDsaP256Sha256 = 13 ,

		/// <summary>
		///     <para>ECDSA Curve P-384 with SHA-384</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc6605">RFC 6605</see>
		///     </para>
		/// </summary>
		EcDsaP384Sha384 = 14 ,

		/// <summary>
		///     <para>Indirect</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
		///     </para>
		/// </summary>
		Indirect = 252 ,

		/// <summary>
		///     <para>Private key using named algorithm</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
		///     </para>
		/// </summary>
		PrivateDns = 253 ,

		/// <summary>
		///     <para>Private key using algorithm object identifier</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
		///     </para>
		/// </summary>
		PrivateOid = 254 ,

	}

	internal static class DnsSecAlgorithmHelper
	{

		public static int GetPriority ( this DnsSecAlgorithm algorithm )
		{
			switch ( algorithm )
			{
				case DnsSecAlgorithm . RsaSha1 :
					return 100 ;
				case DnsSecAlgorithm . Dsa :
					return 90 ;
				case DnsSecAlgorithm . RsaSha1Nsec3Sha1 :
					return 100 ;
				case DnsSecAlgorithm . DsaNsec3Sha1 :
					return 90 ;
				case DnsSecAlgorithm . RsaSha256 :
					return 80 ;
				case DnsSecAlgorithm . RsaSha512 :
					return 70 ;
				case DnsSecAlgorithm . EccGost :
					return 110 ;
				case DnsSecAlgorithm . EcDsaP256Sha256 :
					return 60 ;
				case DnsSecAlgorithm . EcDsaP384Sha384 :
					return 50 ;

				default :
					throw new NotSupportedException ( ) ;
			}
		}

		public static bool IsCompatibleWithNSec ( this DnsSecAlgorithm algorithm )
		{
			switch ( algorithm )
			{
				case DnsSecAlgorithm . RsaSha1 :
				case DnsSecAlgorithm . Dsa :
				case DnsSecAlgorithm . RsaSha256 :
				case DnsSecAlgorithm . RsaSha512 :
				case DnsSecAlgorithm . EccGost :
				case DnsSecAlgorithm . EcDsaP256Sha256 :
				case DnsSecAlgorithm . EcDsaP384Sha384 :
					return true ;

				default :
					return false ;
			}
		}

		public static bool IsCompatibleWithNSec3 ( this DnsSecAlgorithm algorithm )
		{
			switch ( algorithm )
			{
				case DnsSecAlgorithm . RsaSha1Nsec3Sha1 :
				case DnsSecAlgorithm . DsaNsec3Sha1 :
				case DnsSecAlgorithm . RsaSha256 :
				case DnsSecAlgorithm . RsaSha512 :
				case DnsSecAlgorithm . EccGost :
				case DnsSecAlgorithm . EcDsaP256Sha256 :
				case DnsSecAlgorithm . EcDsaP384Sha384 :
					return true ;

				default :
					return false ;
			}
		}

		public static bool IsSupported ( this DnsSecAlgorithm algorithm )
		{
			switch ( algorithm )
			{
				case DnsSecAlgorithm . RsaSha1 :
				case DnsSecAlgorithm . Dsa :
				case DnsSecAlgorithm . RsaSha1Nsec3Sha1 :
				case DnsSecAlgorithm . DsaNsec3Sha1 :
				case DnsSecAlgorithm . RsaSha256 :
				case DnsSecAlgorithm . RsaSha512 :
				case DnsSecAlgorithm . EccGost :
				case DnsSecAlgorithm . EcDsaP256Sha256 :
				case DnsSecAlgorithm . EcDsaP384Sha384 :
					return true ;

				default :
					return false ;
			}
		}

	}

}

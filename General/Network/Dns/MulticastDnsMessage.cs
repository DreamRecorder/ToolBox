﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;

namespace DreamRecorder . ToolBox . Network . Dns
{

	/// <summary>
	///     Message returned as result to a dns query
	/// </summary>
	public class MulticastDnsMessage : DnsMessageBase
	{

		/// <summary>
		///     Gets or sets the entries in the answer records section
		/// </summary>
		public new List <DnsRecordBase> AnswerRecords
		{
			get => base . AnswerRecords ;
			set => base . AnswerRecords = ( value ?? new List <DnsRecordBase> ( ) ) ;
		}

		/// <summary>
		///     Gets or sets the entries in the authority records section
		/// </summary>
		public new List <DnsRecordBase> AuthorityRecords
		{
			get => base . AuthorityRecords ;
			set => base . AuthorityRecords = ( value ?? new List <DnsRecordBase> ( ) ) ;
		}

		internal override bool IsTcpResendingRequested => IsTruncated ;

		internal override bool IsTcpUsingRequested
			=> ( Questions . Count > 0 ) && Questions [ 0 ] . RecordType is RecordType . Axfr or RecordType . Ixfr ;

		/// <summary>
		///     Gets or sets the entries in the question section
		/// </summary>
		public new List <DnsQuestion> Questions
		{
			get => base . Questions ;
			set => base . Questions = ( value ?? new List <DnsQuestion> ( ) ) ;
		}

		internal override bool IsTcpNextMessageWaiting ( bool isSubsequentResponseMessage ) => false ;

		/// <summary>
		///     Parses a the contents of a byte array as MulticastDnsMessage
		/// </summary>
		/// <param name="data">Buffer, that contains the message data</param>
		/// <returns>A new instance of the MulticastDnsMessage class</returns>
		public static MulticastDnsMessage Parse ( byte [ ] data ) => Parse <MulticastDnsMessage> ( data ) ;

		#region Header

		/// <summary>
		///     <para>Gets or sets the autoritive answer (AA) flag</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
		///     </para>
		/// </summary>
		public bool IsAuthoritiveAnswer
		{
			get => ( Flags & 0x0400 ) != 0 ;
			set
			{
				if ( value )
				{
					Flags |= 0x0400 ;
				}
				else
				{
					Flags &= 0xfbff ;
				}
			}
		}

		/// <summary>
		///     <para>Gets or sets the truncated response (TC) flag</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
		///     </para>
		/// </summary>
		public bool IsTruncated
		{
			get => ( Flags & 0x0200 ) != 0 ;
			set
			{
				if ( value )
				{
					Flags |= 0x0200 ;
				}
				else
				{
					Flags &= 0xfdff ;
				}
			}
		}

		/// <summary>
		///     <para>Gets or sets the recursion desired (RD) flag</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
		///     </para>
		/// </summary>
		public bool IsRecursionDesired
		{
			get => ( Flags & 0x0100 ) != 0 ;
			set
			{
				if ( value )
				{
					Flags |= 0x0100 ;
				}
				else
				{
					Flags &= 0xfeff ;
				}
			}
		}

		/// <summary>
		///     <para>Gets or sets the recursion allowed (RA) flag</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
		///     </para>
		/// </summary>
		public bool IsRecursionAllowed
		{
			get => ( Flags & 0x0080 ) != 0 ;
			set
			{
				if ( value )
				{
					Flags |= 0x0080 ;
				}
				else
				{
					Flags &= 0xff7f ;
				}
			}
		}

		/// <summary>
		///     <para>Gets or sets the authentic data (AD) flag</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc4035">RFC 4035</see>
		///     </para>
		/// </summary>
		public bool IsAuthenticData
		{
			get => ( Flags & 0x0020 ) != 0 ;
			set
			{
				if ( value )
				{
					Flags |= 0x0020 ;
				}
				else
				{
					Flags &= 0xffdf ;
				}
			}
		}

		/// <summary>
		///     <para>Gets or sets the checking disabled (CD) flag</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc4035">RFC 4035</see>
		///     </para>
		/// </summary>
		public bool IsCheckingDisabled
		{
			get => ( Flags & 0x0010 ) != 0 ;
			set
			{
				if ( value )
				{
					Flags |= 0x0010 ;
				}
				else
				{
					Flags &= 0xffef ;
				}
			}
		}

		#endregion

	}

}

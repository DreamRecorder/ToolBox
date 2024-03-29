﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;

namespace DreamRecorder . ToolBox . Network . Dns . EDns
{

	/// <summary>
	///     <para>OPT record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc2671">RFC 2671</see>
	///     </para>
	/// </summary>
	public class OptRecord : DnsRecordBase
	{

		/// <summary>
		///     Gets or sets the high bits of return code (EXTENDED-RCODE)
		/// </summary>
		public ReturnCode ExtendedReturnCode
		{
			get => ( ReturnCode )( ( TimeToLive & 0xff000000 ) >> 20 ) ;
			set
			{
				int clearedTtl = ( TimeToLive & 0x00ffffff ) ;
				TimeToLive = ( clearedTtl | ( ( int )value << 20 ) ) ;
			}
		}

		/// <summary>
		///     <para>Gets or sets the DNSSEC OK (DO) flag</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc4035">RFC 4035</see>
		///         and
		///         <see cref="!:http://tools.ietf.org/html/rfc3225">RFC 3225</see>
		///     </para>
		/// </summary>
		public bool IsDnsSecOk
		{
			get => ( TimeToLive & 0x8000 ) != 0 ;
			set
			{
				if ( value )
				{
					TimeToLive |= 0x8000 ;
				}
				else
				{
					TimeToLive &= 0x7fff ;
				}
			}
		}

		protected internal override int MaximumRecordDataLength
		{
			get
			{
				if ( ( Options            == null )
					 || ( Options . Count == 0 ) )
				{
					return 0 ;
				}
				else
				{
					return Options . Sum ( option => option . DataLength + 4 ) ;
				}
			}
		}

		/// <summary>
		///     Gets or set additional EDNS options
		/// </summary>
		public List <EDnsOptionBase> Options { get ; private set ; }

		/// <summary>
		///     Gets or set the sender's UDP payload size
		/// </summary>
		public ushort UdpPayloadSize { get => ( ushort )RecordClass ; set => RecordClass = ( RecordClass )value ; }

		/// <summary>
		///     Gets or set the EDNS version
		/// </summary>
		public byte Version
		{
			get => ( byte )( ( TimeToLive & 0x00ff0000 ) >> 16 ) ;
			set
			{
				int clearedTtl = ( int )( ( uint )TimeToLive & 0xff00ffff ) ;
				TimeToLive = clearedTtl | ( value << 16 ) ;
			}
		}

		/// <summary>
		///     Creates a new instance of the OptRecord
		/// </summary>
		public OptRecord ( ) : base ( DomainName . Root , RecordType . Opt , ( RecordClass )512 , 0 )
		{
			UdpPayloadSize = 4096 ;
			Options        = new List <EDnsOptionBase> ( ) ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			if ( ( Options            != null )
				 && ( Options . Count != 0 ) )
			{
				foreach ( EDnsOptionBase option in Options )
				{
					DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , ( ushort )option . Type ) ;
					DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , option . DataLength ) ;
					option . EncodeData ( messageData , ref currentPosition ) ;
				}
			}
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			int endPosition = startPosition + length ;

			Options = new List <EDnsOptionBase> ( ) ;
			while ( startPosition < endPosition )
			{
				EDnsOptionType type =
					( EDnsOptionType )DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
				ushort dataLength = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;

				EDnsOptionBase option ;

				switch ( type )
				{
					case EDnsOptionType . LongLivedQuery :
						option = new LongLivedQueryOption ( ) ;
						break ;

					case EDnsOptionType . UpdateLease :
						option = new UpdateLeaseOption ( ) ;
						break ;

					case EDnsOptionType . NsId :
						option = new NsIdOption ( ) ;
						break ;

					case EDnsOptionType . Owner :
						option = new OwnerOption ( ) ;
						break ;

					case EDnsOptionType . DnssecAlgorithmUnderstood :
						option = new DnssecAlgorithmUnderstoodOption ( ) ;
						break ;

					case EDnsOptionType . DsHashUnderstood :
						option = new DsHashUnderstoodOption ( ) ;
						break ;

					case EDnsOptionType . Nsec3HashUnderstood :
						option = new Nsec3HashUnderstoodOption ( ) ;
						break ;

					case EDnsOptionType . ClientSubnet :
						option = new ClientSubnetOption ( ) ;
						break ;

					case EDnsOptionType . Expire :
						option = new ExpireOption ( ) ;
						break ;

					case EDnsOptionType . Cookie :
						option = new CookieOption ( ) ;
						break ;

					default :
						option = new UnknownOption ( type ) ;
						break ;
				}

				option . ParseData ( resultData , startPosition , dataLength ) ;
				Options . Add ( option ) ;
				startPosition += dataLength ;
			}
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			throw new NotSupportedException ( ) ;
		}

		internal override string RecordDataToString ( )
		{
			string flags = IsDnsSecOk ? "DO" : "" ;
			return string . Format ( "; EDNS version: {0}; flags: {1}; udp: {2}" , Version , flags , UdpPayloadSize ) ;
		}

		/// <summary>
		///     Returns the textual representation of the OptRecord
		/// </summary>
		/// <returns> The textual representation </returns>
		public override string ToString ( ) => RecordDataToString ( ) ;

	}

}

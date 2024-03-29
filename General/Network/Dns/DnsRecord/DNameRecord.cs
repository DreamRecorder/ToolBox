﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>DNS Name Redirection record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc6672">RFC 6672</see>
	///     </para>
	/// </summary>
	public class DNameRecord : DnsRecordBase
	{

		protected internal override int MaximumRecordDataLength => Target . MaximumRecordDataLength + 2 ;

		/// <summary>
		///     Target of the redirection
		/// </summary>
		public DomainName Target { get ; private set ; }

		internal DNameRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the DNameRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="target"> Target of the redirection </param>
		public DNameRecord ( DomainName name , int timeToLive , DomainName target ) : base (
		 name ,
		 RecordType . DName ,
		 RecordClass . INet ,
		 timeToLive )
			=> Target = target ?? DomainName . Root ;

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeDomainName (
											   messageData ,
											   offset ,
											   ref currentPosition ,
											   Target ,
											   null ,
											   useCanonical ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Target = DnsMessageBase . ParseDomainName ( resultData , ref startPosition ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 1 )
			{
				throw new FormatException ( ) ;
			}

			Target = ParseDomainName ( origin , stringRepresentation [ 0 ] ) ;
		}

		internal override string RecordDataToString ( ) => Target . ToString ( ) ;

	}

}

﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Naming authority pointer record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc2915">RFC 2915</see>
	///         ,
	///         <see cref="!:http://tools.ietf.org/html/rfc2168">RFC 2168</see>
	///         and
	///         <see cref="!:http://tools.ietf.org/html/rfc3403">RFC 3403</see>
	///     </para>
	/// </summary>
	public class NaptrRecord : DnsRecordBase
	{

		/// <summary>
		///     Flags of the record
		/// </summary>
		public string Flags { get ; private set ; }

		protected internal override int MaximumRecordDataLength
			=> Flags . Length + Services . Length + RegExp . Length + Replacement . MaximumRecordDataLength + 13 ;

		/// <summary>
		///     Order of the record
		/// </summary>
		public ushort Order { get ; private set ; }

		/// <summary>
		///     Preference of record with same order
		/// </summary>
		public ushort Preference { get ; private set ; }

		/// <summary>
		///     Substitution expression that is applied to the original string
		/// </summary>
		public string RegExp { get ; private set ; }

		/// <summary>
		///     The next name to query
		/// </summary>
		public DomainName Replacement { get ; private set ; }

		/// <summary>
		///     Available services
		/// </summary>
		public string Services { get ; private set ; }

		internal NaptrRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the NaptrRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="order"> Order of the record </param>
		/// <param name="preference"> Preference of record with same order </param>
		/// <param name="flags"> Flags of the record </param>
		/// <param name="services"> Available services </param>
		/// <param name="regExp"> Substitution expression that is applied to the original string </param>
		/// <param name="replacement"> The next name to query </param>
		public NaptrRecord (
			DomainName name ,
			int        timeToLive ,
			ushort     order ,
			ushort     preference ,
			string     flags ,
			string     services ,
			string     regExp ,
			DomainName replacement ) : base ( name , RecordType . Naptr , RecordClass . INet , timeToLive )
		{
			Order       = order ;
			Preference  = preference ;
			Flags       = flags       ?? string . Empty ;
			Services    = services    ?? string . Empty ;
			RegExp      = regExp      ?? string . Empty ;
			Replacement = replacement ?? DomainName . Root ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , Order ) ;
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , Preference ) ;
			DnsMessageBase . EncodeTextBlock ( messageData , ref currentPosition , Flags ) ;
			DnsMessageBase . EncodeTextBlock ( messageData , ref currentPosition , Services ) ;
			DnsMessageBase . EncodeTextBlock ( messageData , ref currentPosition , RegExp ) ;
			DnsMessageBase . EncodeDomainName (
											   messageData ,
											   offset ,
											   ref currentPosition ,
											   Replacement ,
											   null ,
											   useCanonical ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Order       = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			Preference  = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			Flags       = DnsMessageBase . ParseText ( resultData , ref startPosition ) ;
			Services    = DnsMessageBase . ParseText ( resultData , ref startPosition ) ;
			RegExp      = DnsMessageBase . ParseText ( resultData , ref startPosition ) ;
			Replacement = DnsMessageBase . ParseDomainName ( resultData , ref startPosition ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 6 )
			{
				throw new NotSupportedException ( ) ;
			}

			Order       = ushort . Parse ( stringRepresentation [ 0 ] ) ;
			Preference  = ushort . Parse ( stringRepresentation [ 1 ] ) ;
			Flags       = stringRepresentation [ 2 ] ;
			Services    = stringRepresentation [ 3 ] ;
			RegExp      = stringRepresentation [ 4 ] ;
			Replacement = ParseDomainName ( origin , stringRepresentation [ 5 ] ) ;
		}

		internal override string RecordDataToString ( )
			=> Order
			   + " "
			   + Preference
			   + " \""
			   + Flags . ToMasterfileLabelRepresentation ( )
			   + "\""
			   + " \""
			   + Services . ToMasterfileLabelRepresentation ( )
			   + "\""
			   + " \""
			   + RegExp . ToMasterfileLabelRepresentation ( )
			   + "\""
			   + " "
			   + Replacement ;

	}

}

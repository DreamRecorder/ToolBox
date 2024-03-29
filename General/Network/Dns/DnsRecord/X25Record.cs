﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>X.25 PSDN address record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc1183">RFC 1183</see>
	///     </para>
	/// </summary>
	public class X25Record : DnsRecordBase
	{

		protected internal override int MaximumRecordDataLength => 1 + X25Address . Length ;

		/// <summary>
		///     PSDN (Public Switched Data Network) address
		/// </summary>
		public string X25Address { get ; protected set ; }

		internal X25Record ( ) { }

		/// <summary>
		///     Creates a new instance of the X25Record class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="x25Address"> PSDN (Public Switched Data Network) address </param>
		public X25Record ( DomainName name , int timeToLive , string x25Address ) : base (
		 name ,
		 RecordType . X25 ,
		 RecordClass . INet ,
		 timeToLive )
			=> X25Address = x25Address ?? string . Empty ;

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeTextBlock ( messageData , ref currentPosition , X25Address ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			X25Address += DnsMessageBase . ParseText ( resultData , ref startPosition ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 1 )
			{
				throw new FormatException ( ) ;
			}

			X25Address = stringRepresentation [ 0 ] ;
		}

		internal override string RecordDataToString ( ) => X25Address . ToMasterfileLabelRepresentation ( ) ;

	}

}

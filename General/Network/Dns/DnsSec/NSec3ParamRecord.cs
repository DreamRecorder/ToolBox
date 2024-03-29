﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;
using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsSec
{

	/// <summary>
	///     <para>Hashed next owner parameter record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc5155">RFC 5155</see>
	///     </para>
	/// </summary>
	public class NSec3ParamRecord : DnsRecordBase
	{

		/// <summary>
		///     Flags of the record
		/// </summary>
		public byte Flags { get ; private set ; }

		/// <summary>
		///     Algorithm of the hash
		/// </summary>
		public NSec3HashAlgorithm HashAlgorithm { get ; private set ; }

		/// <summary>
		///     Number of iterations
		/// </summary>
		public ushort Iterations { get ; private set ; }

		protected internal override int MaximumRecordDataLength => 5 + Salt . Length ;

		/// <summary>
		///     Binary data of salt
		/// </summary>
		public byte [ ] Salt { get ; private set ; }

		internal NSec3ParamRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the NSec3ParamRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="recordClass"> Class of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="hashAlgorithm"> Algorithm of hash </param>
		/// <param name="flags"> Flags of the record </param>
		/// <param name="iterations"> Number of iterations </param>
		/// <param name="salt"> Binary data of salt </param>
		public NSec3ParamRecord (
			DomainName         name ,
			RecordClass        recordClass ,
			int                timeToLive ,
			NSec3HashAlgorithm hashAlgorithm ,
			byte               flags ,
			ushort             iterations ,
			byte [ ]           salt ) : base ( name , RecordType . NSec3Param , recordClass , timeToLive )
		{
			HashAlgorithm = hashAlgorithm ;
			Flags         = flags ;
			Iterations    = iterations ;
			Salt          = salt ?? new byte [ ] { } ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			messageData [ currentPosition++ ] = ( byte )HashAlgorithm ;
			messageData [ currentPosition++ ] = Flags ;
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , Iterations ) ;
			messageData [ currentPosition++ ] = ( byte )Salt . Length ;
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , Salt ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int currentPosition , int length )
		{
			HashAlgorithm = ( NSec3HashAlgorithm )resultData [ currentPosition++ ] ;
			Flags         = resultData [ currentPosition++ ] ;
			Iterations    = DnsMessageBase . ParseUShort ( resultData , ref currentPosition ) ;
			int saltLength = resultData [ currentPosition++ ] ;
			Salt = DnsMessageBase . ParseByteData ( resultData , ref currentPosition , saltLength ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 4 )
			{
				throw new FormatException ( ) ;
			}

			HashAlgorithm = ( NSec3HashAlgorithm )byte . Parse ( stringRepresentation [ 0 ] ) ;
			Flags         = byte . Parse ( stringRepresentation [ 1 ] ) ;
			Iterations    = ushort . Parse ( stringRepresentation [ 2 ] ) ;
			Salt = ( stringRepresentation [ 3 ] == "-" )
					   ? new byte [ ] { }
					   : stringRepresentation [ 3 ] . FromBase16String ( ) ;
		}

		internal override string RecordDataToString ( )
			=> ( byte )HashAlgorithm
			   + " "
			   + Flags
			   + " "
			   + Iterations
			   + " "
			   + ( ( Salt . Length == 0 ) ? "-" : Salt . ToBase16String ( ) ) ;

	}

}

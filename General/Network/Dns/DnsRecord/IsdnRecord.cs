using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>ISDN address</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc1183">RFC 1183</see>
	///     </para>
	/// </summary>
	public class IsdnRecord : DnsRecordBase
	{

		/// <summary>
		///     ISDN number
		/// </summary>
		public string IsdnAddress { get ; private set ; }

		/// <summary>
		///     Sub address
		/// </summary>
		public string SubAddress { get ; private set ; }

		protected internal override int MaximumRecordDataLength => 2 + IsdnAddress . Length + SubAddress . Length ;

		internal IsdnRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the IsdnRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="isdnAddress"> ISDN number </param>
		public IsdnRecord ( DomainName name , int timeToLive , string isdnAddress ) : this (
		name ,
		timeToLive ,
		isdnAddress ,
		string . Empty )
		{
		}

		/// <summary>
		///     Creates a new instance of the IsdnRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="isdnAddress"> ISDN number </param>
		/// <param name="subAddress"> Sub address </param>
		public IsdnRecord ( DomainName name , int timeToLive , string isdnAddress , string subAddress ) : base (
		name ,
		RecordType . Isdn ,
		RecordClass . INet ,
		timeToLive )
		{
			IsdnAddress = isdnAddress ?? string . Empty ;
			SubAddress  = subAddress  ?? string . Empty ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int currentPosition , int length )
		{
			int endPosition = currentPosition + length ;

			IsdnAddress = DnsMessageBase . ParseText ( resultData , ref currentPosition ) ;
			SubAddress = ( currentPosition < endPosition )
							? DnsMessageBase . ParseText ( resultData , ref currentPosition )
							: string . Empty ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length > 2 )
			{
				throw new FormatException ( ) ;
			}

			IsdnAddress = stringRepresentation [ 0 ] ;

			if ( stringRepresentation . Length > 1 )
			{
				SubAddress = stringRepresentation [ 1 ] ;
			}
		}

		internal override string RecordDataToString ( )
			=> IsdnAddress . ToMasterfileLabelRepresentation ( )
				+ ( string . IsNullOrEmpty ( SubAddress )
						? string . Empty
						: " " + SubAddress . ToMasterfileLabelRepresentation ( ) ) ;

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeTextBlock ( messageData , ref currentPosition , IsdnAddress ) ;
			DnsMessageBase . EncodeTextBlock ( messageData , ref currentPosition , SubAddress ) ;
		}

	}

}

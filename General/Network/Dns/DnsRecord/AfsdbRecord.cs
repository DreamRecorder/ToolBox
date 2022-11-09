using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>AFS data base location</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc1183">RFC 1183</see>
	///         and
	///         <see cref="!:http://tools.ietf.org/html/rfc5864">RFC 5864</see>
	///     </para>
	/// </summary>
	public class AfsdbRecord : DnsRecordBase
	{

		/// <summary>
		///     AFS database subtype
		/// </summary>
		public enum AfsSubType : ushort
		{

			/// <summary>
			///     <para>Andrews File Service v3.0 Location service</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc1183">RFC 1183</see>
			///     </para>
			/// </summary>
			Afs = 1 ,

			/// <summary>
			///     <para>DCE/NCA root cell directory node</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc1183">RFC 1183</see>
			///     </para>
			/// </summary>
			Dce = 2 ,

		}

		/// <summary>
		///     Hostname of the AFS database
		/// </summary>
		public DomainName Hostname { get ; private set ; }

		protected internal override int MaximumRecordDataLength => Hostname . MaximumRecordDataLength + 4 ;

		/// <summary>
		///     Subtype of the record
		/// </summary>
		public AfsSubType SubType { get ; private set ; }

		internal AfsdbRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the AfsdbRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="subType"> Subtype of the record </param>
		/// <param name="hostname"> Hostname of the AFS database </param>
		public AfsdbRecord ( DomainName name , int timeToLive , AfsSubType subType , DomainName hostname ) : base (
		 name ,
		 RecordType . Afsdb ,
		 RecordClass . INet ,
		 timeToLive )
		{
			SubType  = subType ;
			Hostname = hostname ?? DomainName . Root ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , ( ushort )SubType ) ;
			DnsMessageBase . EncodeDomainName (
											   messageData ,
											   offset ,
											   ref currentPosition ,
											   Hostname ,
											   null ,
											   useCanonical ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			SubType  = ( AfsSubType )DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			Hostname = DnsMessageBase . ParseDomainName ( resultData , ref startPosition ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 2 )
			{
				throw new FormatException ( ) ;
			}

			SubType  = ( AfsSubType )byte . Parse ( stringRepresentation [ 0 ] ) ;
			Hostname = ParseDomainName ( origin , stringRepresentation [ 1 ] ) ;
		}

		internal override string RecordDataToString ( ) => ( byte )SubType + " " + Hostname ;

	}

}

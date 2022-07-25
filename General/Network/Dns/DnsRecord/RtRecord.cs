using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Route through record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc1183">RFC 1183</see>
	///     </para>
	/// </summary>
	public class RtRecord : DnsRecordBase
	{

		/// <summary>
		///     Preference of the record
		/// </summary>
		public ushort Preference { get ; private set ; }

		/// <summary>
		///     Name of the intermediate host
		/// </summary>
		public DomainName IntermediateHost { get ; private set ; }

		protected internal override int MaximumRecordDataLength => IntermediateHost . MaximumRecordDataLength + 4 ;

		internal RtRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the RtRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="preference"> Preference of the record </param>
		/// <param name="intermediateHost"> Name of the intermediate host </param>
		public RtRecord ( DomainName name , int timeToLive , ushort preference , DomainName intermediateHost ) : base (
		name ,
		RecordType . Rt ,
		RecordClass . INet ,
		timeToLive )
		{
			Preference       = preference ;
			IntermediateHost = intermediateHost ?? DomainName . Root ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 2 )
			{
				throw new FormatException ( ) ;
			}

			Preference       = ushort . Parse ( stringRepresentation [ 0 ] ) ;
			IntermediateHost = ParseDomainName ( origin , stringRepresentation [ 1 ] ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Preference       = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			IntermediateHost = DnsMessageBase . ParseDomainName ( resultData , ref startPosition ) ;
		}

		internal override string RecordDataToString ( ) => Preference + " " + IntermediateHost ;

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , Preference ) ;
			DnsMessageBase . EncodeDomainName (
												messageData ,
												offset ,
												ref currentPosition ,
												IntermediateHost ,
												null ,
												useCanonical ) ;
		}

	}

}

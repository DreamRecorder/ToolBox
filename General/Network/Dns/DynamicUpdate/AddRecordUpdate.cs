using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;

namespace DreamRecorder . ToolBox . Network . Dns . DynamicUpdate
{

	/// <summary>
	///     Add record action
	/// </summary>
	public class AddRecordUpdate : UpdateBase
	{

		/// <summary>
		///     Record which should be added
		/// </summary>
		public DnsRecordBase Record { get ; }

		protected internal override int MaximumRecordDataLength => Record . MaximumRecordDataLength ;

		internal AddRecordUpdate ( ) { }

		/// <summary>
		///     Creates a new instance of the AddRecordUpdate
		/// </summary>
		/// <param name="record"> Record which should be added </param>
		public AddRecordUpdate ( DnsRecordBase record ) : base (
																record . Name ,
																record . RecordType ,
																record . RecordClass ,
																record . TimeToLive )
			=> Record = record ;

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length ) { }

		internal override string RecordDataToString ( ) => Record ? . RecordDataToString ( ) ;

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			Record . EncodeRecordData ( messageData , offset , ref currentPosition , domainNames , useCanonical ) ;
		}

	}

}

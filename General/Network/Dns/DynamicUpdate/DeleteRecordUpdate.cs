using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;

namespace DreamRecorder . ToolBox . Network . Dns . DynamicUpdate
{

	/// <summary>
	///     Delete record action
	/// </summary>
	public class DeleteRecordUpdate : UpdateBase
	{

		/// <summary>
		///     Record that should be deleted
		/// </summary>
		public DnsRecordBase Record { get ; }

		protected internal override int MaximumRecordDataLength => Record ? . MaximumRecordDataLength ?? 0 ;

		internal DeleteRecordUpdate ( ) { }

		/// <summary>
		///     Creates a new instance of the DeleteRecordUpdate class
		/// </summary>
		/// <param name="name"> Name of the record that should be deleted </param>
		/// <param name="recordType"> Type of the record that should be deleted </param>
		public DeleteRecordUpdate ( DomainName name , RecordType recordType ) : base (
		name ,
		recordType ,
		RecordClass . Any ,
		0 )
		{
		}

		/// <summary>
		///     Creates a new instance of the DeleteRecordUpdate class
		/// </summary>
		/// <param name="record"> Record that should be deleted </param>
		public DeleteRecordUpdate ( DnsRecordBase record ) : base (
																	record . Name ,
																	record . RecordType ,
																	RecordClass . None ,
																	0 )
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
			Record ? . EncodeRecordData ( messageData , offset , ref currentPosition , domainNames , useCanonical ) ;
		}

	}

}

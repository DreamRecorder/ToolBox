using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DreamRecorder.ToolBox.Network.Dns.DnsRecord;

namespace DreamRecorder.ToolBox.Network.Dns.DynamicUpdate;

/// <summary>
///     Prequisite, that a record exists
/// </summary>
public class RecordExistsPrerequisite : PrerequisiteBase
{

	protected internal override int MaximumRecordDataLength => Record?.MaximumRecordDataLength ?? 0;

	/// <summary>
	///     Record that should exist
	/// </summary>
	public DnsRecordBase Record { get; }

	internal RecordExistsPrerequisite ( ) { }

	/// <summary>
	///     Creates a new instance of the RecordExistsPrerequisite class
	/// </summary>
	/// <param name="name"> Name of record that should be checked </param>
	/// <param name="recordType"> Type of record that should be checked </param>
	public RecordExistsPrerequisite ( DomainName name , RecordType recordType ) : base (
	 name ,
	 recordType ,
	 RecordClass.Any ,
	 0 )
	{
	}

	/// <summary>
	///     Creates a new instance of the RecordExistsPrerequisite class
	/// </summary>
	/// <param name="record"> tecord that should be checked </param>
	public RecordExistsPrerequisite ( DnsRecordBase record ) : base (
																	 record.Name ,
																	 record.RecordType ,
																	 record.RecordClass ,
																	 0 )
		=> Record = record;

	protected internal override void EncodeRecordData (
		byte [ ]                         messageData ,
		int                              offset ,
		ref int                          currentPosition ,
		Dictionary <DomainName , ushort> domainNames ,
		bool                             useCanonical )
	{
		Record?.EncodeRecordData ( messageData , offset , ref currentPosition , domainNames , useCanonical );
	}

	internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length ) { }

}

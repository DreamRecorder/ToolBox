using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns.DynamicUpdate;

/// <summary>
///     Prequisite, that a record does not exist
/// </summary>
public class RecordNotExistsPrerequisite : PrerequisiteBase
{

	protected internal override int MaximumRecordDataLength => 0;

	internal RecordNotExistsPrerequisite ( ) { }

	/// <summary>
	///     Creates a new instance of the RecordNotExistsPrerequisite class
	/// </summary>
	/// <param name="name"> Name of record that should be checked </param>
	/// <param name="recordType"> Type of record that should be checked </param>
	public RecordNotExistsPrerequisite ( DomainName name , RecordType recordType ) : base (
	 name ,
	 recordType ,
	 RecordClass.None ,
	 0 )
	{
	}

	protected internal override void EncodeRecordData (
		byte [ ]                         messageData ,
		int                              offset ,
		ref int                          currentPosition ,
		Dictionary <DomainName , ushort> domainNames ,
		bool                             useCanonical )
	{
	}

	internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length ) { }

}

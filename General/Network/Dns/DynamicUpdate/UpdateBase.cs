using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DreamRecorder.ToolBox.Network.Dns.DnsRecord;

namespace DreamRecorder.ToolBox.Network.Dns.DynamicUpdate;

/// <summary>
///     Base update action of dynamic dns update
/// </summary>
public abstract class UpdateBase : DnsRecordBase
{

	internal UpdateBase ( ) { }

	protected UpdateBase ( DomainName name , RecordType recordType , RecordClass recordClass , int timeToLive ) : base (
	 name ,
	 recordType ,
	 recordClass ,
	 timeToLive )
	{
	}

	internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
	{
		throw new NotSupportedException ( );
	}

}

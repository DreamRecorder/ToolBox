using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns.DnsRecord;

/// <summary>
///     <para>Text strings</para>
///     <para>
///         Defined in
///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
///     </para>
/// </summary>
public class TxtRecord : TextRecordBase
{

	internal TxtRecord ( ) { }

	/// <summary>
	///     Creates a new instance of the TxtRecord class
	/// </summary>
	/// <param name="name"> Name of the record </param>
	/// <param name="timeToLive"> Seconds the record should be cached at most </param>
	/// <param name="textData"> Text data </param>
	public TxtRecord ( DomainName name , int timeToLive , string textData ) : base (
	 name ,
	 RecordType.Txt ,
	 timeToLive ,
	 textData )
	{
	}

	/// <summary>
	///     Creates a new instance of the TxtRecord class
	/// </summary>
	/// <param name="name"> Name of the record </param>
	/// <param name="timeToLive"> Seconds the record should be cached at most </param>
	/// <param name="textParts"> All parts of the text data </param>
	public TxtRecord ( DomainName name , int timeToLive , IEnumerable <string> textParts ) : base (
	 name ,
	 RecordType.Txt ,
	 timeToLive ,
	 textParts )
	{
	}

}

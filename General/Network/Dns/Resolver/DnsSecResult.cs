using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DreamRecorder.ToolBox.Network.Dns.DnsRecord;

namespace DreamRecorder.ToolBox.Network.Dns.Resolver;

/// <summary>
///     The response of a secure DNS resolver
/// </summary>
public class DnsSecResult <T> where T : DnsRecordBase
{

	/// <summary>
	///     The records representing the response
	/// </summary>
	public List <T> Records { get; private set; }

	/// <summary>
	///     Gets the return code (RCODE)
	/// </summary>
	public ReturnCode ReturnCode { get; }

	/// <summary>
	///     The result of the validation process
	/// </summary>
	public DnsSecValidationResult ValidationResult { get; private set; }

	public DnsSecResult ( ReturnCode returnCode , List <T> records , DnsSecValidationResult validationResult )
	{
		ReturnCode       = returnCode;
		Records          = records;
		ValidationResult = validationResult;
	}

}

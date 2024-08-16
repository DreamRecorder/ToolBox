using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns.Resolver;

/// <summary>
///     The result of a DNSSEC validation
/// </summary>
public enum DnsSecValidationResult
{

	/// <summary>
	///     It is indeterminate whether the validation is secure, insecure or bogus
	/// </summary>
	Indeterminate ,

	/// <summary>
	///     The response is signed and fully validated
	/// </summary>
	Signed ,

	/// <summary>
	///     The response is unsigned with a validated OptOut
	/// </summary>
	Unsigned ,

	/// <summary>
	///     The response is bogus
	/// </summary>
	Bogus ,

}

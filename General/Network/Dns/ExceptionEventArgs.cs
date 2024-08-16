using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns;

/// <summary>
///     Event arguments of
///     <see cref="DnsServer.ExceptionThrown" />
///     event.
/// </summary>
public class ExceptionEventArgs : EventArgs
{

	/// <summary>
	///     Exception which was thrown originally
	/// </summary>
	public Exception Exception { get; set; }

	internal ExceptionEventArgs ( Exception exception ) => Exception = exception;

}

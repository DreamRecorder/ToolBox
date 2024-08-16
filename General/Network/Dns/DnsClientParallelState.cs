using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns;

internal class DnsClientParallelState <TMessage> where TMessage : DnsMessageBase
{

	internal object Lock = new object ( );

	internal DnsClientParallelAsyncState <TMessage> ParallelMessageAsyncState;

	internal IAsyncResult SingleMessageAsyncResult;

}

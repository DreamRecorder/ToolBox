using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

using JetBrains.Annotations;

namespace DreamRecorder.ToolBox.Network;

[PublicAPI]
public static class SocketExtensions
{

	public static void CleanTcpClient ( [NotNull] this List <TcpClient> clients )
	{
		if ( clients == null )
		{
			throw new ArgumentNullException ( nameof ( clients ) );
		}

		lock ( clients )
		{
			clients.RemoveAll (
							   client =>
							   {
								   lock ( client )
								   {
									   if ( client.Client.IsAvailable ( ) )
									   {
										   return false;
									   }

									   client.Dispose ( );

									   return true;
								   }
							   } );
		}
	}

	public static bool IsAvailable ( [NotNull] this Socket socket )
	{
		if ( socket == null )
		{
			throw new ArgumentNullException ( nameof ( socket ) );
		}

		try
		{
			return ! ( socket.Poll ( 1 , SelectMode.SelectRead ) && socket.Available == 0 );
		}
		catch ( SocketException )
		{
			return false;
		}
	}

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using JetBrains.Annotations;

namespace DreamRecorder.ToolBox.General;

public static class StreamExtensions
{

	public static bool ReadToFillBuffer ( [NotNull] this Stream stream , Span <byte> buffer )
	{
		if ( stream == null )
		{
			throw new ArgumentNullException ( nameof ( stream ) );
		}

		for ( int i = 0 ; i < buffer.Length ; )
		{
			int currentRead = stream.Read ( buffer.Slice ( i , buffer.Length - i ) );
			if ( currentRead > 0 )
			{
				i += currentRead;
			}
			else
			{
				return false;
			}
		}

		return true;
	}

	public static bool ReadToFillBuffer ( [NotNull] this BinaryReader reader , Span <byte> buffer )
	{
		if ( reader == null )
		{
			throw new ArgumentNullException ( nameof ( reader ) );
		}

		for ( int i = 0 ; i < buffer.Length ; )
		{
			int currentRead = reader.Read ( buffer.Slice ( i , buffer.Length - i ) );
			if ( currentRead > 0 )
			{
				i += currentRead;
			}
			else
			{
				return false;
			}
		}

		return true;
	}

}

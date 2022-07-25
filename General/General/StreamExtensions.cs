using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General ;

public static class StreamExtensions
{

	public static int ReadToFillBuffer ( [NotNull] this Stream stream , Span <byte> buffer )
	{
		if ( stream == null )
		{
			throw new ArgumentNullException ( nameof ( stream ) ) ;
		}

		for ( int i = 0 ; i < buffer . Length ; )
		{
			int currentRead = stream . Read ( buffer . Slice ( i , buffer . Length - i ) ) ;
			if ( currentRead > 0 )
			{
				i += currentRead ;
			}
			else
			{
				return i ;
			}
		}

		return buffer . Length ;
	}

}

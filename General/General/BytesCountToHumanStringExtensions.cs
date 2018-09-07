using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public static class BytesCountToHumanStringExtensions
	{

		private static readonly string [ ] Suffixes =
		{
			"B" , "KiB" , "MiB" , "GiB" , "TiB" , "PiB" , "EiB" , "ZiB" , "YiB"
		} ;

		public static string BytesCountToHumanString ( this long bytesCount )
		{
			if ( bytesCount == 0 )
			{
				return "0" + Suffixes [ 0 ] ;
			}

			long bytes = Math . Abs ( bytesCount ) ;
			int place = Math . Min ( Convert . ToInt32 ( Math . Floor ( Math . Log ( bytes , 1024 ) ) ) ,
									Suffixes . Length - 1 ) ;
			double num = Math . Round ( bytes / Math . Pow ( 1024 , place ) , 1 ) ;
			return Math . Sign ( bytesCount ) * num + Suffixes [ place ] ;
		}

	}

}

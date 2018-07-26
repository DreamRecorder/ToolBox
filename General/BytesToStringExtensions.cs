using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public static class BytesToStringExtensions
	{

		private static readonly string [ ] Suffixs =
		{
			"B" ,
			"KiB" ,
			"MiB" ,
			"GiB" ,
			"TiB" ,
			"PiB" ,
			"EiB" ,
			"ZiB" ,
			"YiB"
		} ;

		public static string BytesToString ( this long bytesCount )
		{
			if ( bytesCount == 0 )
			{
				return "0" + Suffixs [ 0 ] ;
			}

			long bytes = Math . Abs ( bytesCount ) ;
			int place = Math . Min ( Convert . ToInt32 ( Math . Floor ( Math . Log ( bytes , 1024 ) ) ) ,
									Suffixs . Length - 1 ) ;
			double num = Math . Round ( bytes / Math . Pow ( 1024 , place ) , 1 ) ;
			return Math . Sign ( bytesCount ) * num + Suffixs [ place ] ;
		}

	}

}

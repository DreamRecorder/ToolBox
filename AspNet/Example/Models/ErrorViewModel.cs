using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DreamRecorder . ToolBox . AspNet . Example . Models
{

	public class ErrorViewModel
	{

		public string RequestId { get ; set ; }

		public bool ShowRequestId => ! string . IsNullOrEmpty ( RequestId ) ;

	}

	public class ListModel
	{

		public int CurrentPage { get; set; }

		public int LastPage { get; set; }

		public int StartIndex { get; set; }

		public int? AcquiredCount { get; set; }

		public int ActualCount { get; set; }

		public List<Guid> Items { get; set; }

	}

}

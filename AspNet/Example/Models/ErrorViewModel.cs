using DreamRecorder.ToolBox.AspNet.CommonComponent.Models;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.AspNet.Example.Models;

public class ErrorViewModel
{

	public string RequestId { get; set; }

	public bool ShowRequestId => ! string.IsNullOrEmpty ( RequestId );

}

public class ListModel : PageNavigationModel
{

	public int ActualCount { get; set; }

	public List <Guid> Items { get; set; }

	public int StartIndex { get; set; }

}

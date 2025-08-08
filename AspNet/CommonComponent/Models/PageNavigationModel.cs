using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.AspNet.CommonComponent.Models;

public class PageNavigationModel
{

	public string Action { get; set; }

	public string Controller { get; set; }

	public IDictionary<string, string> RouteValues { get; set; }

    public int CurrentPage { get; set; }

	public int ? ItemPerPage { get; set; }

	public int LastPage { get; set; }

	public int PageCount { get; set; }

}

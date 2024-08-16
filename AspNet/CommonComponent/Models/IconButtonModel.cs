using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DreamRecorder.ToolBox.AspNet.General;

namespace DreamRecorder.ToolBox.AspNet.CommonComponent.Models;

public class IconButtonModel
{

	public string Action { get; set; }

	public BootstrapVariation BootstrapVariation { get; set; }

	public string Controller { get; set; }

	public string Icon { get; set; }

	public bool IncludeGuid { get; set; }

	#region

	public static IconButtonModel Add { get; } = new IconButtonModel
												 {
													 BootstrapVariation = BootstrapVariation.Primary ,
													 Action             = nameof ( Add ) ,
													 Icon               = "plus-lg" ,
												 };

	public static IconButtonModel Delete { get; } = new IconButtonModel
													{
														BootstrapVariation = BootstrapVariation.Danger ,
														Action             = nameof ( Delete ) ,
														Icon               = "trash" ,
														IncludeGuid        = true ,
													};

	public static IconButtonModel Restore { get; } = new IconButtonModel
													 {
														 BootstrapVariation = BootstrapVariation.Success ,
														 Action             = nameof ( Restore ) ,
														 Icon               = "recycle" ,
														 IncludeGuid        = true ,
													 };

	#endregion

}

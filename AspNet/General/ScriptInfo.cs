using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.AspNet.General;

public sealed class ScriptInfo : ExternalAssetInfoBase
{

	public enum ScriptType
	{

		Default ,

		Module ,

		ImportMap ,

	}

	public bool IsDefer { get; }

	public ScriptType Type { get; }

	public ScriptInfo (
		string     packageName ,
		string     fileName ,
		string     version = null ,
		bool       isDefer = false ,
		ScriptType type    = ScriptType.Default ) : base ( packageName , fileName , version )
	{
		IsDefer = isDefer;
		Type    = type;
	}

}

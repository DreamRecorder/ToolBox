using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using JetBrains.Annotations;

namespace DreamRecorder.ToolBox.General;

[PublicAPI]
[AttributeUsage ( AttributeTargets.Class | AttributeTargets.Property )]
public sealed class IgnoreAttribute : Attribute
{

}

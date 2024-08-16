using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamRecorder.ToolBox.General;

public delegate Task AsyncEventHandler <T> ( object sender , T eventArgs ) where T : EventArgs;

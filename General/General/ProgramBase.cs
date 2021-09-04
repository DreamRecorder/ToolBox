using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using Microsoft . Extensions . Logging ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public abstract class ProgramBase
	{

		public static ProgramBase Current { get ; protected set ; }

		public abstract string License { get ; }

		public bool IsDebug { get ; protected set ; }

		protected ILogger Logger { get ; set ; }

		public abstract void RunMain ( string [ ] args ) ;

		public abstract bool OnUnhandledExceptions ( Exception e ) ;

		public abstract bool OnStartupExceptions ( Exception e ) ;

	}

}

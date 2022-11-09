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

		public bool IsDebug { get ; protected set ; }

		public abstract string License { get ; }

		protected ILogger Logger { get ; set ; }

		public abstract bool OnStartupExceptions ( Exception e ) ;

		public abstract bool OnUnhandledExceptions ( Exception e ) ;

		public abstract void RunMain ( string [ ] args ) ;

	}

}

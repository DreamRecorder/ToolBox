using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . AspNet . AlertHelper
{

	[Serializable]
	public struct Alert : IEquatable <Alert>
	{

		public BootstrapVariation Variation { get ; }

		public string Message { get ; }

		public Alert ( BootstrapVariation variation , string message )
		{
			Variation = variation ;
			Message = message ;
		}

		public bool Equals ( Alert other )
		{
			return Variation == other . Variation && string . Equals ( Message , other . Message ) ;
		}

		public override bool Equals ( object obj )
		{
			if ( obj is null )
			{
				return false ;
			}

			return obj is Alert other && Equals ( other ) ;
		}

		public override int GetHashCode ( )
		{
			unchecked
			{
				return ( ( int ) Variation * 397 ) ^ ( Message != null ? Message . GetHashCode ( ): 0 ) ;
			}
		}

		public static bool operator == ( Alert left , Alert right ) { return left . Equals ( right ) ; }

		public static bool operator != ( Alert left , Alert right ) { return ! left . Equals ( right ) ; }

	}

}

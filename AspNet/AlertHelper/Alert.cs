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

		public bool Dismissible { get ; }

		public string Content { get ; }

		public Alert ( BootstrapVariation variation , string content , bool dismissible = false )
		{
			Variation   = variation ;
			Content     = content ;
			Dismissible = dismissible ;
		}


		public bool Equals ( Alert other )
			=> Variation == other . Variation && Dismissible == other . Dismissible && Content == other . Content ;

		public override bool Equals ( object obj ) => obj is Alert other && Equals ( other ) ;

		public override int GetHashCode ( ) => HashCode . Combine ( ( int ) Variation , Dismissible , Content ) ;

		public static bool operator == ( Alert left , Alert right ) => left . Equals ( right ) ;

		public static bool operator != ( Alert left , Alert right ) => ! left . Equals ( right ) ;

	}

}

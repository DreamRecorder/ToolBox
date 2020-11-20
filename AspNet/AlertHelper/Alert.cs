using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System.Runtime.Serialization;

namespace DreamRecorder . ToolBox . AspNet . AlertHelper
{
	public class Alert : IEquatable <Alert>
	{
		public BootstrapVariation Variation { get ; set ; }

		public bool Dismissible { get ; set; }

		public string Content { get ; set; }

		public Alert ( BootstrapVariation variation , string content , bool dismissible = false )
		{
			Variation   = variation ;
			Content     = content ;
			Dismissible = dismissible ;
		}

		public Alert ( ) {
		}

		public bool Equals ( Alert other )
			=> Variation == other . Variation && Dismissible == other . Dismissible && Content == other . Content ;

		public override bool Equals ( object obj ) => obj is Alert other && Equals ( other ) ;

		public override int GetHashCode ( ) => HashCode . Combine ( ( int ) Variation , Dismissible , Content ) ;

		public static bool operator == ( Alert left , Alert right ) => left . Equals ( right ) ;

		public static bool operator != ( Alert left , Alert right ) => ! left . Equals ( right ) ;

	}

}

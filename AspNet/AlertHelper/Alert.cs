using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . AspNet . General ;

namespace DreamRecorder . ToolBox . AspNet . AlertHelper
{

	public class Alert : IEquatable <Alert>
	{

		public BootstrapVariation Variation { get ; set ; }

		public bool Dismissible { get ; set ; }

		public string Content { get ; set ; }

		public Alert ( BootstrapVariation variation , string content , bool dismissible = false )
		{
			Variation   = variation ;
			Content     = content ;
			Dismissible = dismissible ;
		}

		public Alert ( ) { }

		private const string DismissibleClass = " alert-dismissible fade show" ;

		private const string ButtonHtmlString = @"
                <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
                <span aria-hidden=""true"">&times;</span>
                </button>" ;

		public bool Equals ( Alert other )
			=> Variation == other . Variation && Dismissible == other . Dismissible && Content == other . Content ;

		public virtual string ToHtmlString ( )
		{
			string dismissible = null ;
			string button      = null ;

			if ( Dismissible )
			{
				dismissible = DismissibleClass ;
				button      = ButtonHtmlString ;
			}

			return
				$"<div class=\"alert alert-{Variation . ToString ( ) . ToLower ( )}{dismissible}\" role=\"alert\">\n{Content}{button}\n</div>" ;
		}

		public override bool Equals ( object obj ) => obj is Alert other && Equals ( other ) ;

		public override int GetHashCode ( ) => HashCode . Combine ( ( int )Variation , Dismissible , Content ) ;

		public static bool operator == ( Alert left , Alert right ) => left . Equals ( right ) ;

		public static bool operator != ( Alert left , Alert right ) => ! left . Equals ( right ) ;

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Drawing ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public class LinearInterpolationLookupTable : ISelfSerializable
	{

		public ReadOnlyCollection <PointF> Points { get ; }

		private List <PointF> PointsList { get ; }

		public double this [ double x ] => Find ( x ) ;

		public LinearInterpolationLookupTable ( )
		{
			PointsList = new List <PointF> ( ) ;
			Points     = new ReadOnlyCollection <PointF> ( PointsList ) ;
			Sort ( ) ;
		}

		public LinearInterpolationLookupTable ( [NotNull] IEnumerable <PointF> init )
		{
			if ( init == null )
			{
				throw new ArgumentNullException ( nameof (init) ) ;
			}

			PointsList = new List <PointF> ( init ) ;
			Points     = new ReadOnlyCollection <PointF> ( PointsList ) ;
		}

		public LinearInterpolationLookupTable ( [NotNull] XElement element )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof (element) ) ;
			}

			if ( element . Name != nameof (LinearInterpolationLookupTable) )
			{
				throw new ArgumentException ( ExceptionMessages . XmlNameMismatch ( nameof (element) ,
																					typeof (
																						LinearInterpolationLookupTable
																					) ) ) ;
			}

			foreach ( XElement pointData in element . Elements ( ) )
			{
				PointF point = new PointF ( pointData . ReadNecessaryValue <float> ( nameof (point . X) ) ,
											pointData . ReadNecessaryValue <float> ( nameof (point . Y) ) ) ;

				PointsList . Add ( point ) ;
			}

			Sort ( ) ;
		}

		public XElement ToXElement ( )
		{
			XElement result = new XElement ( nameof (LinearInterpolationLookupTable) ) ;

			foreach ( PointF point in Points )
			{
				XElement pointElement = new XElement ( nameof (point) ) ;

				pointElement . SetAttributeValue ( nameof (point . X) , point . X ) ;
				pointElement . SetAttributeValue ( nameof (point . Y) , point . Y ) ;

				result . Add ( pointElement ) ;
			}

			return result ;
		}

		public void AddPoint ( PointF point )
		{
			PointsList . Add ( point ) ;
			Sort ( ) ;
		}

		public void Sort ( ) { PointsList . Sort ( ( left , right ) => left . X . CompareTo ( right . X ) ) ; }

		public double Find ( double x )
		{
			for ( int i = 0 ; i < ( Points . Count - 1 ) ; i++ )
			{
				if ( ( Points [ i ] . X <= x )
					&& ( x              < Points [ i + 1 ] . X ) )
				{
					return ( ( ( Points [ i + 1 ] . Y - Points [ i ] . Y ) * ( x - Points [ i ] . X ) )
							/ ( Points [ i + 1 ] . X - Points [ i ] . X ) )
							+ Points [ i ] . Y ;
				}
			}

			return 0 ;
		}

	}

}

using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Collections . ObjectModel ;
using System . Linq ;

namespace DreamRecorder . ToolBox . AspNet . CommonComponent . Models ;

public class PageTitleModel
{

	public IEnumerable <IconButtonModel> Buttons { get ; set ; }

	public string Controller { get ; set ; }

	public Guid? Guid { get ; set ; }

	public string Title { get ; set ; }

	#region Buttons

	public static IEnumerable <IconButtonModel> AddAndDeleteButtons { get ; } =
		new ReadOnlyCollection <IconButtonModel> (
												  new List <IconButtonModel>
												  {
													  IconButtonModel . Add , IconButtonModel . Delete ,
												  } ) ;

	public static IEnumerable <IconButtonModel> AddAndRestoreButtons { get ; } =
		new ReadOnlyCollection <IconButtonModel> (
												  new List <IconButtonModel>
												  {
													  IconButtonModel . Add , IconButtonModel . Restore ,
												  } ) ;

	public static IEnumerable <IconButtonModel> AddButtons { get ; } =
		new ReadOnlyCollection <IconButtonModel> ( new List <IconButtonModel> { IconButtonModel . Add , } ) ;

	#endregion

}
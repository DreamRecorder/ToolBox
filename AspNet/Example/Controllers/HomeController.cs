using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using DreamRecorder.ToolBox.AspNet.Example.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DreamRecorder.ToolBox.AspNet.Example.Controllers;

public class HomeController : Controller
{

	private readonly ILogger <HomeController> _logger;

	public static List <Guid> ListItems { get; set; }

	public HomeController ( ILogger <HomeController> logger ) => _logger = logger;

	[ResponseCache ( Duration = 0 , Location = ResponseCacheLocation.None , NoStore = true )]
	public IActionResult Error ( )
		=> View ( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier , } );

	public IActionResult Index ( ) => View ( );

	[HttpGet ( @"[controller]/[action]/{pageIndex?}/{acquiredCount?}" )]
	[HttpGet ( @"[action]/{pageIndex?}/{acquiredCount?}" )]
	public async Task <IActionResult> List ( int ? pageIndex , int ? acquiredCount )
	{
		int count = acquiredCount ?? 100;

		int itemCount = 1145;

		int maxPage = ( ( itemCount - 1 ) / count ) + 1;

		int actualPageIndex = Math.Min ( maxPage , pageIndex ?? 1 );

		int startIndex = count * ( actualPageIndex - 1 );

		int actualCount = Math.Min ( itemCount - startIndex , count );

		if ( ListItems == null )
		{
			ListItems = new List <Guid> ( );

			for ( int i = 0 ; i < itemCount ; i++ )
			{
				ListItems.Add ( Guid.NewGuid ( ) );
			}
		}

		ListModel model = new ListModel
						  {
							  StartIndex    = startIndex ,
							  ActualCount   = actualCount ,
							  CurrentPage   = actualPageIndex ,
							  LastPage      = maxPage ,
							  Items         = ListItems.Take ( actualCount ).ToList ( ) ,
							  AcquiredCount = acquiredCount ,
						  };


		return View ( model );
	}

	public IActionResult Privacy ( ) => View ( );

}

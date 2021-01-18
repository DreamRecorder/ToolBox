using System ;
using System.Collections ;
using System.Collections.Generic ;
using System.Diagnostics ;
using System.Linq ;

using DreamRecorder . ToolBox . AspNet . Example . Models ;

using Microsoft.AspNetCore.Mvc ;
using Microsoft.Extensions.Logging ;

namespace DreamRecorder . ToolBox . AspNet . Example .Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

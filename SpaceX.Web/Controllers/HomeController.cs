using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpaceX.Services.Contracts;

namespace SpaceX.Web.Controllers
{
    /// <summary>
    /// A controller class that will return the default view for our application
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataService _dataService;

        public HomeController(ILogger<HomeController> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpaceX.Services.Contracts;
using SpaceX.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceX.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISpacexApiService _spacexApiService;

        public HomeController(ILogger<HomeController> logger, ISpacexApiService spacexApiService)
        {
            _logger = logger;
            _spacexApiService = spacexApiService;
        }

        public async Task<IActionResult> Index()
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
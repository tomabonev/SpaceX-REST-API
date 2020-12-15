using Microsoft.AspNetCore.Mvc;
using SpaceX.Services;
using SpaceX.Services.Data;
using SpaceX.Services.IO;
using SpaceX.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceX.Web.Controllers
{
    /// <summary>
    /// A controller class that contains the flow control launch logic for our application and return it as a view
    /// </summary>
    public class LaunchController : Controller
    {
        private readonly IEnumerable<IExportService> _exportServices;
        private readonly IDataService _dataService;

        public
            LaunchController(
            IEnumerable<IExportService> exportServices,
            IDataService dateService)
        {
            _exportServices = exportServices;
            _dataService = dateService;
        }

        [HttpGet]
        public async Task<IActionResult> LaunchList(int page = 1, int size = 22)
        {
            var launchPlans = await _dataService.GetLaunchList(page, size);

            if (!launchPlans.Any())
            {
                return View("Error");
            }

            var viewModel = new LaunchListVM
            {
                LaunchPlans = launchPlans,
                Page = page,
                Size = size
            };

            return View(viewModel);
        }
        public async Task<IActionResult> PopulateDataToExcel()
        {
            try
            {
                var launchList = await _dataService.GetLaunchList(1, int.MaxValue);

                var content = _exportServices.FirstOrDefault(e => e is ExcelExportService).Export(launchList);

                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SpaceX Launches.xlsx");
            }
            catch (Exception)
            {
                return View("Home/Error");
            }
        }

        public async Task<IActionResult> PopulateDataToPdf()
        {
            try
            {
                var launchList = await _dataService.GetLaunchList(1, int.MaxValue);

                var valueToReturn = _exportServices.FirstOrDefault(e => e is PdfExportService).Export(launchList);

                return File(valueToReturn, "application/pdf", "SpaceX Launches.pdf");
            }
            catch (Exception)
            {
                return View("Home/Error");
            }
        }

        public async Task<IActionResult> LaunchDetails(string flightNumber)
        {
            try
            {
                var launchPlan = await _dataService.GetLaunchPlan(flightNumber);

                var launch = new LaunchDetailsVM();

                launch.LaunchPlans = launchPlan;

                return View(launch);
            }
            catch (Exception)
            {
                return View("Home/Error");
            }
        }
    }
}
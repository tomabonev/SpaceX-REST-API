using Microsoft.AspNetCore.Mvc;
using SpaceX.Services.Contracts;
using SpaceX.Services.IO;
using SpaceX.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceX.Web.Controllers
{
    /// <summary>
    /// A controller class that contains the flow control launch logic for our application and return it as a view
    /// </summary>
    public class LaunchController : Controller
    {
        private readonly IPdfExportService _pdfExportService;
        private readonly IExcelExportService _excelExporttService;
        private readonly IDataService _dataService;

        public
            LaunchController(
            IPdfExportService pdfExportService,
            IExcelExportService excelExporttService,
            IDataService dateService)
        {
            _pdfExportService = pdfExportService;
            _dataService = dateService;
            _excelExporttService = excelExporttService;
        }

        [HttpGet]
        public async Task<IActionResult> Launch(int page = 1, int size = 22)
        {
            var launchPlans = await _dataService.GetLaunchList(page, size);

            if (!launchPlans.Any())
            {
                return View("Error");
            }

            var viewModel = new LaunchViewModel
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

                var content = _excelExporttService.Export(launchList);

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

                var valueToReturn = _pdfExportService.Export(launchList);

                return File(valueToReturn, "application/pdf", "SpaceX Launches.pdf");
            }
            catch (Exception)
            {
                return View("Home/Error");
            }
        }

        public async Task<IActionResult> LaunchDetail(string flightNumber)
        {
            try
            {
                var launchPlan = await _dataService.GetLaunchPlan(flightNumber);

                return View(launchPlan);
            }
            catch (Exception)
            {
                return View("Home/Error");
            }
        }
    }
}
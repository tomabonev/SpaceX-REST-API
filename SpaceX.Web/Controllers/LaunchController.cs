using Microsoft.AspNetCore.Mvc;
using SpaceX.Services.Contracts;
using SpaceX.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceX.Web.Controllers
{
    public class LaunchController : Controller
    {
        private readonly ICreateExcelFileService _createExcelFileService;
        private readonly ICreatePdfFileService _createPdfFileService;
        private readonly ISpacexApiService _spacexApiService;

        public
            LaunchController(ICreateExcelFileService createExcelFileService,
            ICreatePdfFileService createPdfFileService,
            ISpacexApiService spacexApiService)
        {
            _createExcelFileService = createExcelFileService;
            _createPdfFileService = createPdfFileService;
            _spacexApiService = spacexApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Launch(int page = 1, int size = 22)
        {
            var launchPlans = await _spacexApiService.GetLaunchList(page, size);

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
                var launchList = await _spacexApiService.GetLaunchList(1, int.MaxValue);

                var content = _createExcelFileService.ExportToExcel(launchList);

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
                var launchList = await _spacexApiService.GetLaunchList(1, int.MaxValue);

                var valueToReturn = _createPdfFileService.ExportToPdf(launchList);

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
                var launchPlan = await _spacexApiService.GetLaunchPlan(flightNumber);

                return View(launchPlan);
            }
            catch (Exception)
            {
                return View("Home/Error");
            }
        }
    }
}
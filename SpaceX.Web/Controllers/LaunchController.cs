using Microsoft.AspNetCore.Mvc;
using RestSharp;
using SpaceX.Models;
using SpaceX.Services.Contracts;
using System.Collections.Generic;

namespace SpaceX.Web.Controllers
{
    public class LaunchController : Controller
    {
        private readonly string getAllLaunchesUrl = "https://api.spacexdata.com/v3/launches";

        private readonly ICreateExcelFileService _createExcelFileService;
        private readonly ICreatePdfFileService _createPdfFileService;

        public LaunchController(ICreateExcelFileService createExcelFileService, ICreatePdfFileService createPdfFileService)
        {
            _createExcelFileService = createExcelFileService;
            _createPdfFileService = createPdfFileService;
        }

        public IActionResult PopulateDataToExcel()
        {
            var client = new RestClient($"{getAllLaunchesUrl}");
            var request = new RestRequest($"{getAllLaunchesUrl}", Method.GET);

            IRestResponse response = client.Execute(request);

            var launchList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LaunchPlan>>(response.Content);

            var content = _createExcelFileService.ExportToExcel(launchList);

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "LaunchPlan.xlsx");
        }

        public IActionResult PopulateDataToPdf()
        {
            var client = new RestClient($"{getAllLaunchesUrl}");
            var request = new RestRequest($"{getAllLaunchesUrl}", Method.GET);

            IRestResponse response = client.Execute(request);

            var launchList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LaunchPlan>>(response.Content);

            var valueToReturn = _createPdfFileService.ExportToPdf(launchList);

            return File(valueToReturn, "application/pdf", "SpaceX Launches.pdf");
        }
    }
}
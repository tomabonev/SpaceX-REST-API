using Microsoft.AspNetCore.Mvc;
using RestSharp;
using SpaceX.Models;
using SpaceX.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IActionResult> PopulateDataToExcel()
        {
            var client = new RestClient($"{getAllLaunchesUrl}");
            var request = new RestRequest($"{getAllLaunchesUrl}", Method.GET);

            try
            {
                IRestResponse response = await client.ExecuteAsync(request);

                var launchList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LaunchPlan>>(response.Content);

                var content = _createExcelFileService.ExportToExcel(launchList);

                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "LaunchPlan.xlsx");
            }
            catch (Exception)
            {
                if (Response.StatusCode == 500)
                {
                    throw new Exception("SpaceX server is temporary unreachable. Please try again later");
                }
                else
                {
                    throw new Exception("SpaceX doesn't know such planet in all the galaxies");
                }
            }
        }

        public async Task<IActionResult> PopulateDataToPdf()
        {
            var client = new RestClient($"{getAllLaunchesUrl}");
            var request = new RestRequest($"{getAllLaunchesUrl}", Method.GET);

            try
            {
                IRestResponse response = await client.ExecuteAsync(request);

                var launchList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LaunchPlan>>(response.Content);

                var valueToReturn = _createPdfFileService.ExportToPdf(launchList);

                return File(valueToReturn, "application/pdf", "SpaceX Launches.pdf");
            }
            catch (Exception)
            {
                if (Response.StatusCode == 500)
                {
                    throw new Exception("SpaceX server is temporary unreachable. Please try again later");
                }
                else
                {
                    throw new Exception("SpaceX doesn't know such planet in all the galaxies");
                }
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using SpaceX.Models;
using SpaceX.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
            var client = new HttpClient();

            client.BaseAddress = new Uri(getAllLaunchesUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(1.00);

            try
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                response.EnsureSuccessStatusCode();

                var launchList = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<List<LaunchPlan>>(response.Content.ReadAsStringAsync().Result);

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
            var client = new HttpClient();

            client.BaseAddress = new Uri(getAllLaunchesUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(1.00);

            try
            {
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                response.EnsureSuccessStatusCode();

                var launchList = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<List<LaunchPlan>>(response.Content.ReadAsStringAsync().Result);

                var valueToReturn = _createPdfFileService.ExportToPdf(launchList);

                return File(valueToReturn, "application/pdf", "SpaceX Launches.pdf");
            }
            catch (Exception)
            {
                return View("Home/Error");
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using SpaceX.Models;
using SpaceX.Services.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SpaceX.Web.Controllers
{
    public class LaunchController : Controller
    {
        private readonly string getAllLaunchesUrl = "https://api.spacexdata.com/v3/launches";

        private readonly ICreateExcelFileService _createExcelFileService;

        public LaunchController(ICreateExcelFileService createExcelFileService)
        {
            _createExcelFileService = createExcelFileService;
        }

        public async Task<IActionResult> GetAll()
        {
            var client = new RestClient($"{getAllLaunchesUrl}");
            var request = new RestRequest($"{getAllLaunchesUrl}", Method.GET);

            IRestResponse response = client.Execute(request);

            var launchList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LaunchPlan>>(response.Content);

            using (var workbook = await _createExcelFileService.PopulateDataToExcel(launchList))
            {
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "LaunchPlan.xlsx");
                }
            }
        }
    }
}
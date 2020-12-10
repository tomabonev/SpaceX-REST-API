using ClosedXML.Excel;
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

            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Launch Plan");

                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "Flight Number";
                worksheet.Cell(currentRow, 2).Value = "Mission Name";
                worksheet.Cell(currentRow, 3).Value = "Mission Id";
                worksheet.Cell(currentRow, 4).Value = "Upcoming";
                worksheet.Cell(currentRow, 5).Value = "LaunchYear";
                worksheet.Cell(currentRow, 6).Value = "LaunchDateUnix";
                worksheet.Cell(currentRow, 7).Value = "LaunchDateUtc";
                worksheet.Cell(currentRow, 8).Value = "LaunchDateLocal";
                worksheet.Cell(currentRow, 9).Value = "IsTentative";
                worksheet.Cell(currentRow, 10).Value = "TentativeMaxPrecision";
                worksheet.Cell(currentRow, 11).Value = "Tbd";
                worksheet.Cell(currentRow, 12).Value = "LaunchWindow";
                worksheet.Cell(currentRow, 13).Value = "Rocket Id";
                worksheet.Cell(currentRow, 14).Value = "Rocket Name";
                worksheet.Cell(currentRow, 15).Value = "Rocket Type";
                worksheet.Cell(currentRow, 16).Value = "Ships";
                worksheet.Cell(currentRow, 17).Value = "Flight Club";
                worksheet.Cell(currentRow, 18).Value = "Site Id";
                worksheet.Cell(currentRow, 19).Value = "Site Name";
                worksheet.Cell(currentRow, 20).Value = "Site Name Long";
                worksheet.Cell(currentRow, 21).Value = "Launch Success";
                worksheet.Cell(currentRow, 22).Value = "Details";
                worksheet.Cell(currentRow, 23).Value = "Static Fire Date";
                worksheet.Cell(currentRow, 24).Value = "Static Fire Date Unix";
                //worksheet.Cell(currentRow, 25).Value = "Webcast Liftoff";
                //worksheet.Cell(currentRow, 22).Value = "Fail Time";
                //worksheet.Cell(currentRow, 23).Value = "Fail Altitude";
                //worksheet.Cell(currentRow, 24).Value = "Fail Reason";
                //worksheet.Cell(currentRow, 16).Value = "First Stage";
                //worksheet.Cell(currentRow, 17).Value = "Second Stage";
                //worksheet.Cell(currentRow, 18).Value = "Payloads";
                //worksheet.Cell(currentRow, 16).Value = "Fairing Reused";
                //worksheet.Cell(currentRow, 17).Value = "Fairing Recovery Attempt";
                //worksheet.Cell(currentRow, 18).Value = "Fairing Recovered";
                //worksheet.Cell(currentRow, 19).Value = "Fairing Ship";

                foreach (var item in launchList)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.FlightNumber;
                    worksheet.Cell(currentRow, 2).Value = item.MissionName;
                    worksheet.Cell(currentRow, 3).Value = item.MissionId;
                    worksheet.Cell(currentRow, 4).Value = item.Upcoming;
                    worksheet.Cell(currentRow, 5).Value = item.LaunchYear;
                    worksheet.Cell(currentRow, 6).Value = item.LaunchDateUnix;
                    worksheet.Cell(currentRow, 7).Value = item.LaunchDateUtc.UtcDateTime;
                    worksheet.Cell(currentRow, 8).Value = item.LaunchDateLocal.LocalDateTime;
                    worksheet.Cell(currentRow, 9).Value = item.IsTentative;
                    worksheet.Cell(currentRow, 10).Value = item.TentativeMaxPrecision;
                    worksheet.Cell(currentRow, 11).Value = item.Tbd;
                    worksheet.Cell(currentRow, 12).Value = item.LaunchWindow;
                    worksheet.Cell(currentRow, 13).Value = item.Rocket.RocketId;
                    worksheet.Cell(currentRow, 14).Value = item.Rocket.RocketName;
                    worksheet.Cell(currentRow, 15).Value = item.Rocket.RocketType;
                    worksheet.Cell(currentRow, 16).Value = item.Ships;
                    worksheet.Cell(currentRow, 17).Value = item.Telemetry.FlightClub;
                    worksheet.Cell(currentRow, 18).Value = item.LaunchSite.SiteId;
                    worksheet.Cell(currentRow, 19).Value = item.LaunchSite.SiteName;
                    worksheet.Cell(currentRow, 20).Value = item.LaunchSite.SiteNameLong;
                    worksheet.Cell(currentRow, 21).Value = item.LaunchSuccess;
                    worksheet.Cell(currentRow, 22).Value = item.Details;
                    worksheet.Cell(currentRow, 23).Value = item.StaticFireDateUtc;
                    worksheet.Cell(currentRow, 24).Value = item.StaticFireDateUnix;
                    //worksheet.Cell(currentRow, 25).Value = item.Timeline.WebcastLiftoff;
                    //worksheet.Cell(currentRow, 22).Value = item.LaunchFailureDetails.Time;
                    //worksheet.Cell(currentRow, 23).Value = item.LaunchFailureDetails.Altitude;
                    //worksheet.Cell(currentRow, 24).Value = item.LaunchFailureDetails.Reason;
                    //worksheet.Cell(currentRow, 16).Value = item.Rocket.FirstStage.Cores;
                    //worksheet.Cell(currentRow, 17).Value = item.Rocket.SecondStage.Block;
                    //worksheet.Cell(currentRow, 18).Value = item.Rocket.SecondStage.Payloads;
                    //worksheet.Cell(currentRow, 16).Value = item.Rocket.Fairings.Reused;
                    //worksheet.Cell(currentRow, 17).Value = item.Rocket.Fairings.RecoveryAttempt;
                    //worksheet.Cell(currentRow, 18).Value = item.Rocket.Fairings.Recovered;
                    //worksheet.Cell(currentRow, 19).Value = item.Rocket.Fairings.Ship;
                   
                }

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
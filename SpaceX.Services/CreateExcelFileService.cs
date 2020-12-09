using ClosedXML.Excel;
using SpaceX.Models;
using SpaceX.Services.Contracts;
using System.Collections.Generic;

namespace SpaceX.Services
{
    public class CreateExcelFileService : ICreateExcelFileService
    {
        public bool ExportToExcel(List<LaunchPlan> launchPlans)
        {
            var workbook = new XLWorkbook();

            IXLWorksheet worksheet = workbook.Worksheets.Add("Launch Plan");

            worksheet.Cell(1, 1).Value = "flight_number";
            worksheet.Cell(1, 2).Value = "landing_type";
            worksheet.Cell(1, 3).Value = "landing_vehicle";

            for (int index = 1; index <= launchPlans.Count; index++)
            {
                worksheet.Cell(index + 1, 1).Value = launchPlans[index - 1].FlightNumber;
                worksheet.Cell(index + 1, 2).Value = launchPlans[index - 1].IsTentative;
                worksheet.Cell(index + 1, 3).Value = launchPlans[index - 1].LaunchYear;
            }

            return true;
        }
    }
}
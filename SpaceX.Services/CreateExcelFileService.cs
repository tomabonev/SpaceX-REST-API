using ClosedXML.Excel;
using SpaceX.Models;
using SpaceX.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceX.Services
{
    public class CreateExcelFileService : ICreateExcelFileService
    {
        public async Task<XLWorkbook> PopulateDataToExcel(List<LaunchPlan> launchPlans)
        {
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("Launch Plan");

                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "FlightNumber";
                worksheet.Cell(currentRow, 2).Value = "MissionName";
                worksheet.Cell(currentRow, 3).Value = "Upcoming";

                foreach (var item in launchPlans)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.FlightNumber;
                    worksheet.Cell(currentRow, 2).Value = item.MissionName;
                    worksheet.Cell(currentRow, 3).Value = item.Upcoming;
                }

                return workbook;
            }
        }
    }
}
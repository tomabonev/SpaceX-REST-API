using ClosedXML.Excel;
using SpaceX.Models;
using System.Collections.Generic;

namespace SpaceX.Services.Contracts
{
    public interface ICreateExcelFileService
    {
        XLWorkbook PopulateDataToExcel(List<LaunchPlan> launchPlans);
    }
}

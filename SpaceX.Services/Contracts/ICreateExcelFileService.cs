using ClosedXML.Excel;
using SpaceX.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceX.Services.Contracts
{
    public interface ICreateExcelFileService
    {
        Task<XLWorkbook> PopulateDataToExcel(List<LaunchPlan> launchPlans);
    }
}

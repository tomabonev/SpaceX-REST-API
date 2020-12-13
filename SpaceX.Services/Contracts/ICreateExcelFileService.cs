using SpaceX.Models;
using System.Collections.Generic;

namespace SpaceX.Services.Contracts
{
    /// <summary>
    /// Defines functionality for exporting data to an excel file
    /// </summary>
    public interface ICreateExcelFileService
    {
        byte[] ExportToExcel(List<LaunchPlan> launchPlans);
    }
}

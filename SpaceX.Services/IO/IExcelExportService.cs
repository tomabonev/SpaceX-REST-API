using SpaceX.Models;
using System.Collections.Generic;

namespace SpaceX.Services.IO
{
    /// <summary>
    /// Defines functionality for exporting data to an excel file
    /// </summary>
    public interface IExcelExportService
    {
        byte[] Export(List<LaunchPlan> launchPlans);

    }

}

using SpaceX.Services.DTO;
using System.Collections.Generic;

namespace SpaceX.Services.IO
{
    /// <summary>
    /// Defines functionality for exporting data to excel and pdf files
    /// </summary>
    public interface IExportService
    {
        byte[] Export(List<LaunchPlan> launchPlans);
    }
}

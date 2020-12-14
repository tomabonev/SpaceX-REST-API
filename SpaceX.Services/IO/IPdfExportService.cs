using SpaceX.Models;
using System.Collections.Generic;

namespace SpaceX.Services.Contracts
{
    /// <summary>
    /// Defines functionality for exporting data to an excel or pdf file
    /// </summary>
    public interface IPdfExportService
    {
        byte[] Export(List<LaunchPlan> launchPlans);

    }
}

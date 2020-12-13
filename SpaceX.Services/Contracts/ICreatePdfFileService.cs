using SpaceX.Models;
using System.Collections.Generic;

namespace SpaceX.Services.Contracts
{
    /// <summary>
    /// Defines functionality for exporting data to a pdf file
    /// </summary>
    public interface ICreatePdfFileService
    {
        byte[] ExportToPdf(List<LaunchPlan> launchPlans);
    }
}

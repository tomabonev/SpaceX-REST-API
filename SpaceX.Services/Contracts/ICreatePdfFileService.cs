using SpaceX.Models;
using System.Collections.Generic;

namespace SpaceX.Services.Contracts
{
    public interface ICreatePdfFileService
    {
        byte[] ReportToPdf(List<LaunchPlan> launchPlans);
    }
}

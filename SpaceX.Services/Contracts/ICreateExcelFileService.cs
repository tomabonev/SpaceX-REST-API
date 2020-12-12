using SpaceX.Models;
using System.Collections.Generic;

namespace SpaceX.Services.Contracts
{
    public interface ICreateExcelFileService
    {
        byte[] ReportToExcel(List<LaunchPlan> launchPlans);
    }
}

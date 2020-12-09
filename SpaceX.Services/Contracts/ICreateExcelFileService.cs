using SpaceX.Models;
using System.Collections.Generic;

namespace SpaceX.Services.Contracts
{
    public interface ICreateExcelFileService
    {
        bool ExportToExcel(List<LaunchPlan> launchPlans);
    }
}

using SpaceX.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceX.Services.IO
{
    public interface IExcelExportService
    {
        byte[] Export(List<LaunchPlan> launchPlans);

    }

}

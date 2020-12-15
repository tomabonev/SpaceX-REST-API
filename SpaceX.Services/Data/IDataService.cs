using SpaceX.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceX.Services.Contracts
{
    /// <summary>
    /// Defines functionality for extrcting data from SpaceX API
    /// </summary>
    public interface IDataService
    {
        Task<List<LaunchPlan>> GetLaunchList(int page, int limit);

        Task<LaunchPlan> GetLaunchPlan(string flightNumber);
    }
}

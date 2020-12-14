using SpaceX.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceX.Services.Contracts
{
    public interface IDataService
    {
        Task<List<LaunchPlan>> GetLaunchList(int page, int limit);

        Task<LaunchPlan> GetLaunchPlan(string flightNumber);
    }
}

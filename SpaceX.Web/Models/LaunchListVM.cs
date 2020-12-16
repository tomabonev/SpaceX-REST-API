using SpaceX.Services.DTO;
using System.Collections.Generic;

namespace SpaceX.Web.Models
{
    /// <summary>
    /// The class handles a collection of launch plan data
    /// </summary>
    public class LaunchListVM
    {
        #region Properties

        public IEnumerable<LaunchPlan> LaunchPlans { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }

        #endregion
    }
}

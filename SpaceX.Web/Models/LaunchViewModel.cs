using SpaceX.Models;
using System.Collections.Generic;

namespace SpaceX.Web.Models
{
    /// <summary>
    /// A view model class which contains properties of launch plan data
    /// </summary>
    public class LaunchViewModel
    {
        #region Properties

        public IEnumerable<LaunchPlan> LaunchPlans { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }

        #endregion
    }
}

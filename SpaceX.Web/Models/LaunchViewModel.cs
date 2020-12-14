using SpaceX.Models;
using System.Collections.Generic;

namespace SpaceX.Web.Models
{
    public class LaunchViewModel
    {
        public IEnumerable<LaunchPlan> LaunchPlans { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }
    }
}

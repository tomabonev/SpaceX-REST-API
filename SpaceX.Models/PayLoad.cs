using System.Collections.Generic;

namespace SpaceX.Models
{
    public class PayLoad
    {
        public string payload_id { get; }

        public ICollection<object> customers { get; }

        public string payload_type { get; }

        public int payload_mass_kg { get; }

        public int payload_mass_lbs { get; }

        public string orbit { get; }
    }
}
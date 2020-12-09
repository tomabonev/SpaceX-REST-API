using System;
using System.Collections.Generic;

namespace SpaceX.Models
{
    public class LaunchPlanModel : Rocket
    {
        public int flight_number { get; }

        public int launch_year { get; }

        public DateTime launch_date_utc { get; }

        public DateTime launch_date_local { get; }

        public Rocket rocket { get; }

        public Telemetry telemetry { get; }

        public string core_serial { get; }

        public string cap_serial { get; }

        public LaunchSite launch_site { get; }

        public ICollection<PayLoad> payloads { get; }

        public bool launch_success { get; }

        public bool reused { get; }

        public bool land_success { get; }

        public object landing_type { get; }

        public object landing_vehicle { get; }

        public string details { get; set; }
    }
}
using Newtonsoft.Json;
using System;

namespace SpaceX.Models
{
    /// <summary>
    /// A dto class which contains properties of the launch plan
    /// </summary>
    public class LaunchPlan
    {
        #region Properties

        [JsonProperty("flight_number")]
        public string FlightNumber { get; set; }

        [JsonProperty("mission_name")]
        public string MissionName { get; set; }

        [JsonProperty("mission_id")]
        public object[] MissionId { get; set; }

        [JsonProperty("upcoming")]
        public string Upcoming { get; set; }

        [JsonProperty("launch_year")]
        public string LaunchYear { get; set; }

        [JsonProperty("launch_date_unix")]
        public string LaunchDateUnix { get; set; }

        [JsonProperty("launch_date_utc")]
        public DateTimeOffset LaunchDateUtc { get; set; }

        [JsonProperty("launch_date_local")]
        public DateTimeOffset LaunchDateLocal { get; set; }

        [JsonProperty("is_tentative")]
        public string IsTentative { get; set; }

        [JsonProperty("tentative_max_precision")]
        public string TentativeMaxPrecision { get; set; }

        [JsonProperty("tbd")]
        public string Tbd { get; set; }

        [JsonProperty("launch_window")]
        public string LaunchWindow { get; set; }

        [JsonProperty("rocket")]
        public Rocket Rocket { get; set; }

        [JsonProperty("ships")]
        public object[] Ships { get; set; }

        [JsonProperty("telemetry")]
        public Telemetry Telemetry { get; set; }

        [JsonProperty("launch_site")]
        public LaunchSite LaunchSite { get; set; }

        [JsonProperty("launch_success")]
        public string LaunchSuccess { get; set; }

        [JsonProperty("launch_failure_details")]
        public LaunchFailureInfo LaunchFailureDetails { get; set; } = new LaunchFailureInfo();

        [JsonProperty("links")]
        public LinksList Links { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("static_fire_date_utc")]
        public DateTimeOffset? StaticFireDateUtc { get; set; }

        [JsonProperty("static_fire_date_unix")]
        public string StaticFireDateUnix { get; set; }

        [JsonProperty("timeline")]
        public Timeline Timeline { get; set; }

        #endregion
    }             
}
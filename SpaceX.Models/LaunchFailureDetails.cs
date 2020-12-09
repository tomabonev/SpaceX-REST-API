using Newtonsoft.Json;

namespace SpaceX.Models
{
    public class LaunchFailureDetails
    {
        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("altitude")]
        public object Altitude { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}

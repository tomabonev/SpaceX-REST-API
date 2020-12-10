using Newtonsoft.Json;

namespace SpaceX.Models
{
    public class LaunchFailureInfo
    {
        #region Launch Failure Info Properties

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("altitude")]
        public int? Altitude { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        #endregion
    }
}
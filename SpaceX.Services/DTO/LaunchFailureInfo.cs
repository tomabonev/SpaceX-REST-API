using Newtonsoft.Json;

namespace SpaceX.Services.DTO
{
    /// <summary>
    /// The class handles the rocket launch failure info
    /// </summary>
    public class LaunchFailureInfo
    {
        #region Properties

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("altitude")]
        public int? Altitude { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        #endregion
    }
}
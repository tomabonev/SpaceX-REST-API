using Newtonsoft.Json;

namespace SpaceX.Services.DTO
{
    /// <summary>
    /// The class handles the fairings
    /// </summary>
    public class Fairing
    {
        #region Fairing Properties

        [JsonProperty("reused")]
        public bool? Reused { get; set; }

        [JsonProperty("recovery_attempt")]
        public bool? RecoveryAttempt { get; set; }

        [JsonProperty("recovered")]
        public bool? Recovered { get; set; }

        [JsonProperty("ship")]
        public object Ship { get; set; }

        #endregion
    }
}
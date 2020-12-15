using Newtonsoft.Json;

namespace SpaceX.Models
{
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
﻿using Newtonsoft.Json;

namespace SpaceX.Models
{
    public class Fairing
    {
        #region Fairing Properties

        [JsonProperty("reused")]
        public string Reused { get; set; }

        [JsonProperty("recovery_attempt")]
        public string RecoveryAttempt { get; set; }

        [JsonProperty("recovered")]
        public string Recovered { get; set; }

        [JsonProperty("ship")]
        public object Ship { get; set; }

        #endregion
    }
}
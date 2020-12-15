﻿using Newtonsoft.Json;

namespace SpaceX.Models
{
    /// <summary>
    /// A dto class which contains properties of the rocket launch failure info
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
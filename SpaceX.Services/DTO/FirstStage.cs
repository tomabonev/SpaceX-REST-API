﻿using Newtonsoft.Json;

namespace SpaceX.Services.DTO
{
    /// <summary>
    /// The class provide properties of the rocket core data during the first stage
    /// </summary>
    public class FirstStage
    {
        #region Properties

        [JsonProperty("cores")]
        public Core[] Cores { get; set; }

        #endregion
    }
}
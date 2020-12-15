using Newtonsoft.Json;

namespace SpaceX.Models
{
    /// <summary>
    /// A dto class which contains a collection of the rocket payload data during the second stage
    /// </summary>
    public class SecondStage
    {
        #region Properties

        [JsonProperty("block")]
        public string Block { get; set; }

        [JsonProperty("payloads")]
        public Payload[] Payloads { get; set; }

        #endregion
    }
}
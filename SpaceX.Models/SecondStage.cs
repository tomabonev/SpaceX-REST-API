using Newtonsoft.Json;

namespace SpaceX.Models
{
    public class SecondStage
    {
        #region Second Stage Properties

        [JsonProperty("block")]
        public string Block { get; set; }

        [JsonProperty("payloads")]
        public Payload[] Payloads { get; set; }

        #endregion
    }
}
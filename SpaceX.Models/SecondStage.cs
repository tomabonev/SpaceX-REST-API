using Newtonsoft.Json;

namespace SpaceX.Models
{
    public class SecondStage
    {
        [JsonProperty("block")]
        public string Block { get; set; }

        [JsonProperty("payloads")]
        public Payload[] Payloads { get; set; }
    }
}
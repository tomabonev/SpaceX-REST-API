using Newtonsoft.Json;

namespace SpaceX.Models
{
    public partial class FirstStage
    {
        [JsonProperty("cores")]
        public Core[] Cores { get; set; }
    }
}
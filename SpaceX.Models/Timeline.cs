using Newtonsoft.Json;

namespace SpaceX.Models
{
    public partial class Timeline
    {
        [JsonProperty("webcast_liftoff")]
        public string WebcastLiftoff { get; set; }
    }
}
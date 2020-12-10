using Newtonsoft.Json;

namespace SpaceX.Models
{
    public class Timeline
    {
        #region Timeline Properties

        [JsonProperty("webcast_liftoff")]
        public string WebcastLiftoff { get; set; }

        #endregion
    }
}
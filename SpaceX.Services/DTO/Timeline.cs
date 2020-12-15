using Newtonsoft.Json;

namespace SpaceX.Services.DTO
{
    /// <summary>
    /// The class provide properties of the timeline
    /// </summary>
    public class Timeline
    {
        #region Properties

        [JsonProperty("webcast_liftoff")]
        public string WebcastLiftoff { get; set; }

        #endregion
    }
}
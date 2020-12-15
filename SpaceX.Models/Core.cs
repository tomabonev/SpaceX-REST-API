using Newtonsoft.Json;

namespace SpaceX.Models
{
    /// <summary>
    /// A dto class which contains properties of rocket core data
    /// </summary>
    public class Core
    {
        #region Properties

        [JsonProperty("core_serial")]
        public string CoreSerial { get; set; }

        [JsonProperty("flight")]
        public string Flight { get; set; }

        [JsonProperty("block")]
        public object Block { get; set; }

        [JsonProperty("gridfins")]
        public string Gridfins { get; set; }

        [JsonProperty("legs")]
        public string Legs { get; set; }

        [JsonProperty("reused")]
        public string Reused { get; set; }

        [JsonProperty("land_success")]
        public object LandSuccess { get; set; }

        [JsonProperty("landing_intent")]
        public string LandingIntent { get; set; }

        [JsonProperty("landing_type")]
        public object LandingType { get; set; }

        [JsonProperty("landing_vehicle")]
        public object LandingVehicle { get; set; }

        #endregion
    }
}
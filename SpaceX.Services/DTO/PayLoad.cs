using Newtonsoft.Json;

namespace SpaceX.Services.DTO
{
    /// <summary>
    /// The class handles the rocket payloads
    /// </summary>
    public class Payload
    {
        #region Properties

        [JsonProperty("payload_id")]
        public string PayloadId { get; set; }

        [JsonProperty("norad_id")]
        public object[] NoradId { get; set; }

        [JsonProperty("reused")]
        public string Reused { get; set; }

        [JsonProperty("customers")]
        public string[] Customers { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty("payload_type")]
        public string PayloadType { get; set; }

        [JsonProperty("payload_mass_kg")]
        public string PayloadMassKg { get; set; }

        [JsonProperty("payload_mass_lbs")]
        public string PayloadMassLbs { get; set; }

        [JsonProperty("orbit")]
        public string Orbit { get; set; }

        [JsonProperty("orbit_params")]
        public OrbitParam OrbitParams { get; set; }

        #endregion
    }
}
using Newtonsoft.Json;

namespace SpaceX.Models
{
    public class Telemetry
    {
        #region Telemetry Properties

        [JsonProperty("flight_club")]
        public object FlightClub { get; set; }

        #endregion
    }
}
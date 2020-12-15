using Newtonsoft.Json;

namespace SpaceX.Models
{
    /// <summary>
    /// A dto class which contains properties of the telemetry flight club
    /// </summary>
    public class Telemetry
    {
        #region Properties

        [JsonProperty("flight_club")]
        public object FlightClub { get; set; }

        #endregion
    }
}
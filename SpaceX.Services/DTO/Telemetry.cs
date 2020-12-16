using Newtonsoft.Json;

namespace SpaceX.Services.DTO
{
    /// <summary>
    /// The class handles the telemetry flight club
    /// </summary>
    public class Telemetry
    {
        #region Properties

        [JsonProperty("flight_club")]
        public object FlightClub { get; set; }

        #endregion
    }
}
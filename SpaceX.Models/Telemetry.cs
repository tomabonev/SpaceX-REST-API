using Newtonsoft.Json;

namespace SpaceX.Models
{
    public class Telemetry
    {
        [JsonProperty("flight_club")]
        public object FlightClub { get; set; }
    }
}
using Newtonsoft.Json;

namespace SpaceX.Services.DTO
{
    /// <summary>
    /// The class handles the rocket data
    /// </summary>
    public class Rocket
    {
        #region Properties

        [JsonProperty("rocket_id")]
        public string RocketId { get; set; }

        [JsonProperty("rocket_name")]
        public string RocketName { get; set; }

        [JsonProperty("rocket_type")]
        public string RocketType { get; set; }

        [JsonProperty("first_stage")]
        public FirstStage FirstStage { get; set; }

        [JsonProperty("second_stage")]
        public SecondStage SecondStage { get; set; }

        [JsonProperty("fairings")]
        public Fairing Fairings { get; set; }

        #endregion
    }
}
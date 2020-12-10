using Newtonsoft.Json;

namespace SpaceX.Models
{
    public class Rocket
    {
        #region Rocket Properties

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
        public Fairing? Fairings { get; set; } = new Fairing();

        #endregion
    }
}
using Newtonsoft.Json;

namespace SpaceX.Models
{
    /// <summary>
    /// A dto class which contains a collection of the rocket core data during the first stage
    /// </summary>
    public class FirstStage
    {
        #region Properties

        [JsonProperty("cores")]
        public Core[] Cores { get; set; }

        #endregion
    }
}
using Newtonsoft.Json;

namespace SpaceX.Models
{
    public class FirstStage
    {
        #region First Stage Properties

        [JsonProperty("cores")]
        public Core[] Cores { get; set; }

        #endregion
    }
}
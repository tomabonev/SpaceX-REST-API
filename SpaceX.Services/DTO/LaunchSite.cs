using Newtonsoft.Json;

namespace SpaceX.Services.DTO
{
    /// <summary>
    /// The class handles the launch site
    /// </summary>
    public class LaunchSite
    {
        #region Properties

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("site_name")]
        public string SiteName { get; set; }

        [JsonProperty("site_name_long")]
        public string SiteNameLong { get; set; }

        #endregion
    }
}
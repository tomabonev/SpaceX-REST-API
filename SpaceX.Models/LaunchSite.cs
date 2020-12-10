﻿using Newtonsoft.Json;

namespace SpaceX.Models
{
    public class LaunchSite
    {
        #region Launch Site Properties

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("site_name")]
        public string SiteName { get; set; }

        [JsonProperty("site_name_long")]
        public string SiteNameLong { get; set; }

        #endregion
    }
}
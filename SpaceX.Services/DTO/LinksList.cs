using Newtonsoft.Json;

namespace SpaceX.Services.DTO
{
    /// <summary>
    /// The class handles the links for each rocket launch
    /// </summary>
    public class LinksList
    {
        #region Properties

        [JsonProperty("mission_patch")]
        public string MissionPatch { get; set; }

        [JsonProperty("mission_patch_small")]
        public string MissionPatchSmall { get; set; }

        [JsonProperty("reddit_campaign")]
        public object RedditCampaign { get; set; }

        [JsonProperty("reddit_launch")]
        public object RedditLaunch { get; set; }

        [JsonProperty("reddit_recovery")]
        public object RedditRecovery { get; set; }

        [JsonProperty("reddit_media")]
        public object RedditMedia { get; set; }

        [JsonProperty("presskit")]
        public object Presskit { get; set; }

        [JsonProperty("article_link")]
        public string ArticleLink { get; set; }

        [JsonProperty("wikipedia")]
        public string Wikipedia { get; set; }

        [JsonProperty("video_link")]
        public string VideoLink { get; set; }

        [JsonProperty("youtube_id")]
        public string YoutubeId { get; set; }

        [JsonProperty("flickr_images")]
        public object[] FlickrImages { get; set; }

        #endregion
    }
}
using Newtonsoft.Json;

namespace FutureSpaceAPI.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string Name { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("map_image")]
        public string MapImage { get; set; }
        [JsonProperty("total_launch_count")]
        public int TotalLaunchCount { get; set; }
        [JsonProperty("total_landing_count")]
        public int TotalLandingCount { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace FutureSpaceAPI.Domain.Entities
{
    public class Location : Entity
    {
        public string Url { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }
        [JsonPropertyName("map_image")]
        public string MapImage { get; set; }
        [JsonPropertyName("total_launch_count")]
        public int TotalLaunchCount { get; set; }
        [JsonPropertyName("total_landing_count")]
        public int TotalLandingCount { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace FutureSpaceAPI.Domain.Entities
{
    public class Pad : Entity
    {
        public string Url { get; set; }
        [JsonPropertyName("agency_id")]
        public int AgencyId { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("info_url")]
        public string InfoUrl { get; set; }
        [JsonPropertyName("wiki_url")]
        public string WikiUrl { get; set; }
        [JsonPropertyName("map_url")]
        public string MapUrl { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Location Location { get; set; }
        [JsonPropertyName("map_image")]
        public string MapImage { get; set; }
        public int TotalLaunchCount { get; set; }
    }
}

using Newtonsoft.Json;

namespace FutureSpaceAPI.Domain.Entities
{
    public class Pad
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        [JsonProperty("agency_id")]
        public int? AgencyId { get; set; }
        public string Name { get; set; }
        [JsonProperty("info_url")]
        public string? InfoUrl { get; set; }
        [JsonProperty("wiki_url")]
        public string? WikiUrl { get; set; }
        [JsonProperty("map_url")]
        public string? MapUrl { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Location? Location { get; set; }
        [JsonProperty("map_image")]
        public string? MapImage { get; set; }
        public int TotalLaunchCount { get; set; }
    }
}
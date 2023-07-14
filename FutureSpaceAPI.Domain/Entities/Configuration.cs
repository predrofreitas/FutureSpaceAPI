using System.Text.Json.Serialization;

namespace FutureSpaceAPI.Domain.Entities
{
    public class Configuration : Entity
    {
        [JsonPropertyName("launch_library_id")]
        public int LaunchLibraryId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
        public string Variant { get; set; }
    }
}

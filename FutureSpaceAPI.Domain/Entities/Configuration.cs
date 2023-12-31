﻿using Newtonsoft.Json;

namespace FutureSpaceAPI.Domain.Entities
{
    public class Configuration
    {
        public int Id { get; set; }
        [JsonProperty("launch_library_id")]
        public int? LaunchLibraryId { get; set; }
        public string? Url { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        public string Variant { get; set; }
    }
}

namespace FutureSpaceAPI.Domain.Entities
{
    public class Location : Entity
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string MapImage { get; set; }
        public int TotalLaunchCount { get; set; }
        public int TotalLandingCount { get; set; }
    }
}

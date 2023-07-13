namespace FutureSpaceAPI.Domain.Entities
{
    public class Configuration : Entity
    {
        public int LaunchLibraryId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string FullName { get; set; }
        public string Variant { get; set; }
    }
}

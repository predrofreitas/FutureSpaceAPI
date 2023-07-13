namespace FutureSpaceAPI.Domain.Entities
{
    public class Launcher : Entity
    {
        public string Url { get; set; }
        public int LaunchLibraryId { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime Net { get; set; }
        public DateTime WindowEnd { get; set; }
        public DateTime WindowStart { get; set; }
        public bool InHold { get; set; }
        public bool TbdTime { get; set; }
        public bool TbdDate { get; set; }
        public int Probability { get; set; }
        public string HoldReason { get; set; }
        public string FailReason { get; set; }
        public string Hashtag { get; set; }
        public LaunchServiceProvider LaunchServiceProvider { get; set; }
        public Rocket Rocket { get; set; }
        public Pad Pad { get; set; }
        public bool WebcastLive { get; set; }
        public string Image { get; set; }
    }
}

namespace IntelliMonitor.API.Models
{
    public class WebsiteMonitor
    {
        public int Id { get; set; }

        public required string Url { get; set; }

        public required string Email { get; set; }

        public DateTime ScheduledTime { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

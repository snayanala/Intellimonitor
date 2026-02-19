using Microsoft.EntityFrameworkCore;
using IntelliMonitor.API.Models;

namespace IntelliMonitor.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebsiteMonitor> WebsiteMonitors { get; set; }
    }
}

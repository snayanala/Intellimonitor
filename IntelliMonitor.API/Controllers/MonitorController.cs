using Microsoft.AspNetCore.Mvc;
using IntelliMonitor.API.Data;
using IntelliMonitor.API.Models;
using IntelliMonitor.API.Services;   
using Hangfire; 

namespace IntelliMonitor.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MonitorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMonitor(WebsiteMonitor monitor)
    {
             _context.WebsiteMonitors.Add(monitor);
            await _context.SaveChangesAsync();

    BackgroundJob.Enqueue<MonitoringService>(
    service => service.ExecuteMonitoring(monitor.Id));


           return Ok(new { message = "Monitor created and job scheduled", monitor.Id });
}[HttpGet("test-email")]
public async Task<IActionResult> TestEmail([FromServices] EmailService emailService)
{
    await emailService.SendEmailWithAttachment(
        "nayanalasupriya1428@gmail.com",  // 👈 replace with your Gmail
        "Test Email from IntelliMonitor",
        "If you receive this, SMTP works perfectly.",
        null);

    return Ok("Test email sent.");
}

[HttpGet("sac-login")]
public async Task<IActionResult> SacLogin([FromServices] SacAuthService authService)
{
    await authService.SaveSacAuthStateAsync();
    return Ok("SAC authentication saved.");
}


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.WebsiteMonitors.ToList());
        }
    }
}

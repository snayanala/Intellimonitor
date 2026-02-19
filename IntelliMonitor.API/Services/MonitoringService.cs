using Microsoft.Playwright;
using IntelliMonitor.API.Data;
using IntelliMonitor.API.Models;
using IntelliMonitor.API.Services;

namespace IntelliMonitor.API.Services
{
    public class MonitoringService
    {
        private readonly AppDbContext _context;
        private readonly EmailService _emailService;

        public MonitoringService(AppDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task ExecuteMonitoring(int monitorId)
        {
            var monitor = await _context.WebsiteMonitors.FindAsync(monitorId);

            if (monitor == null || !monitor.IsActive)
                return;

            Console.WriteLine($"Monitoring SAC story: {monitor.Url}");

            using var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = true
                });

            var context = await browser.NewContextAsync(
                new BrowserNewContextOptions
                {
                    StorageStatePath = "sacAuth.json"
                });

            var page = await context.NewPageAsync();

            await page.GotoAsync(monitor.Url);

            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await page.WaitForTimeoutAsync(10000); // SAC heavy JS

            var screenshotPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                $"sacReport_{monitorId}_{DateTime.Now:yyyyMMddHHmmss}.png");

            await page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = screenshotPath,
                FullPage = true
            });

            Console.WriteLine($"SAC Screenshot saved: {screenshotPath}");

            await _emailService.SendEmailWithAttachment(
                monitor.Email,
                "SAC Dashboard Screenshot",
                $"Attached is your SAC report screenshot captured at {DateTime.Now}.",
                screenshotPath);

            Console.WriteLine("Email sent successfully.");

            await browser.CloseAsync();
        }
    }
}

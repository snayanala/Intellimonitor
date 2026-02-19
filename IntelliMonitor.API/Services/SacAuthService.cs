using Microsoft.Playwright;

namespace IntelliMonitor.API.Services
{
    public class SacAuthService
    {
        public async Task SaveSacAuthStateAsync()
        {
            using var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = false,   // visible browser
                    SlowMo = 100
                });

            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            // Go to SAC login page
            await page.GotoAsync("https://academy-t-sac.us10.hcs.cloud.sap");

            Console.WriteLine("Please login manually and check 'Remember Me'...");
            Console.WriteLine("Waiting 60 seconds before saving session...");

            await page.WaitForTimeoutAsync(60000); // 60 seconds to login

            // Save session
            await context.StorageStateAsync(new BrowserContextStorageStateOptions
            {
                Path = "sacAuth.json"
            });

            Console.WriteLine("SAC authentication saved to sacAuth.json");

            await browser.CloseAsync();
        }
    }
}

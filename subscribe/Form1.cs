using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace subscribe
{
    public partial class Subscriber : Form
    {
        private static readonly string[] separator = ["\r\n", "\r", "\n"];

        public Subscriber()
        {
            InitializeComponent();
            Task.Run(Installer.Install).Wait();
        }       

        private async void Subscribe_Click(object sender, EventArgs e)
        {
            var list_emails = emails.Text
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Where(email => Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                .ToList();

            if (list_emails.Count == 0)
            {
                MessageBox.Show("Please enter email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var context = default(IBrowserContext);
            try
            {

                // Initialize Playwright
                using var playwright = await Playwright.CreateAsync();
                // Launch a new browser instance
                await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false,
                    Args = ["--start-maximized"]
                });

                // Create a new browser context and page      
                context = await browser.NewContextAsync(new BrowserNewContextOptions
                {
                    ViewportSize = ViewportSize.NoViewport
                });

                var tasks = new List<Task>
                {
                    Pages.FoxNews(context, list_emails),
                    Pages.UsaToday(context, list_emails),
                    Pages.WashitongPost(context, list_emails),
                    Pages.Timeout(context, list_emails),
                    Pages.HealthLine(context, list_emails),
                    Pages.Yves(context, list_emails),
                    Pages.Aib(context, list_emails),
                };

                await Task.WhenAll(tasks);
            }
            finally
            {
                context?.CloseAsync();
            }

        }
    }
}

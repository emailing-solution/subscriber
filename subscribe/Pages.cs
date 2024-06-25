using Microsoft.Playwright;
using System.Diagnostics;

namespace subscribe
{
    internal class Pages
    {
        public static async Task FoxNews(IBrowserContext context, List<string> emails)
        {
            const string url = "https://www.foxnews.com/alerts/subscribe";

            var page = await context.NewPageAsync();
            await page.GotoAsync(url);

            foreach (var email in emails)
            {
                try
                {
                    // Ensure the elements to be manipulated are visible and available
                    await page.EvaluateAsync("[...document.querySelectorAll(\".subscribe a\")].map(a => a.click())");
                    await Task.Delay(800);
                    await page.EvaluateAsync($"[...document.querySelectorAll(\".input-email\")].map(a => a.value  = '{email.Trim()}')");
                    await Task.Delay(800);
                    await page.EvaluateAsync("[...document.querySelectorAll(\".enter a\")].map(a => a.click())");

                    await Task.Delay(5000);
                    Debug.WriteLine($"Foxnews {email.Trim()} done");

                    //reload if not last in loop
                    if (emails.IndexOf(email) != emails.Count - 1)
                    {
                        await page.GotoAsync(url);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing {email.Trim()}: {ex.Message}");
                }
            }

            await page.CloseAsync();
        }

        public static async Task UsaToday(IBrowserContext context, List<string> emails)
        {
            const string url = "https://profile.usatoday.com/newsletters/manage/";

            var page = await context.NewPageAsync();
            await page.GotoAsync(url);

            foreach (var email in emails)
            {
                try
                {
                    // Ensure the elements to be manipulated are visible and available
                    await page.EvaluateAsync("[...document.querySelectorAll(\".newsletter-list\")].map((a,i) => (i != 1 && i !=3 && i != 8) && a.click())");
                    await Task.Delay(800);
                    await page.FillAsync("#email", email.Trim());
                    await Task.Delay(800);
                    //submit button click
                    await page.ClickAsync("button[type=submit]");

                    await Task.Delay(5000);
                    Debug.WriteLine($"UsaToday {email.Trim()} done");

                    //reload if not last in loop
                    if (emails.IndexOf(email) != emails.Count - 1)
                    {
                        await page.GotoAsync(url);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing {email.Trim()}: {ex.Message}");
                }
            }

            await page.CloseAsync();
        }


        public static async Task WashitongPost(IBrowserContext context, List<string> emails)
        {
            const string url = "https://www.washingtonpost.com/newsletters/";

            var page = await context.NewPageAsync();
            await page.GotoAsync(url);

            foreach (var email in emails)
            {
                try
                {     
                    await page.EvaluateAsync("[ ...document.querySelectorAll('.col-span-12 .mt-auto button')].map(a => a.click())");
                    await Task.Delay(800);
                    //submit button click
                    await page.ClickAsync("#email-input");
                    await Task.Delay(800);
                    await page.FillAsync("#email-input", email.Trim());

                    await page.ClickAsync("#tosCheckbox");
                    //click on form button
                    await page.EvaluateAsync("document.querySelectorAll('form button')[1].click()");

                    await Task.Delay(5000);
                    Debug.WriteLine($"WashitongPost {email.Trim()} done");

                    //reload if not last in loop
                    if (emails.IndexOf(email) != emails.Count - 1)
                    {
                        await page.GotoAsync(url);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing {email.Trim()}: {ex.Message}");
                }
            }

            await page.CloseAsync();
        }

        //public static async Task Cnn(IBrowserContext context, List<string> emails)
        //{
        //    const string url = "https://edition.cnn.com/newsletters";

        //    var page = await context.NewPageAsync();
        //    await page.GotoAsync(url);

        //    foreach (var email in emails)
        //    {
        //        try
        //        {
        //            await page.EvaluateAsync("[...document.querySelectorAll('.newsletter-hub__cards li button')].map((a,i) =>  (i != 35) && a.click())");
        //            await Task.Delay(800);
        //            //wait to #newsletter-signup-form to appear
        //            await page.WaitForSelectorAsync("#newsletter-signup-form");
        //            await page.FillAsync("#newsletter-subscribe-email-input", email.Trim());

        //            //click submit on #newsletter-signup-form from
        //            await page.ClickAsync("#newsletter-signup-form button[type=submit]");
                  
        //            //wait until all requests fullfilled
        //            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);

        //            Debug.WriteLine($"( {email.Trim()} done");

        //            //reload if not last in loop
        //            if (emails.IndexOf(email) != emails.Count - 1)
        //            {
        //                await page.GotoAsync(url);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine($"Error processing {email.Trim()}: {ex.Message}");
        //        }
        //    }
        //}
        
        public static async Task Timeout(IBrowserContext context, List<string> emails)
        {
            const string url = "https://www.timeout.com/usa/newsletter";

            var page = await context.NewPageAsync();
            await page.GotoAsync(url);

            foreach (var email in emails)
            {
                try
                {
                    await page.FillAsync("#footer-newsletter-email", email.Trim());
                    await page.ClickAsync("._submitWrap_1srxd_99 input[type=submit]");
                    await Task.Delay(5000);

                    Debug.WriteLine($"( {email.Trim()} done");

                    //reload if not last in loop
                    if (emails.IndexOf(email) != emails.Count - 1)
                    {
                        await page.GotoAsync(url);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing {email.Trim()}: {ex.Message}");
                }
            }

            await page.CloseAsync();
        }

        public static async Task HealthLine(IBrowserContext context, List<string> emails)
        {
            const string url = "https://www.healthline.com/newsletter-signup";

            var page = await context.NewPageAsync();
            await page.GotoAsync(url);

            foreach (var email in emails)
            {
                try
                {
                    await page.EvaluateAsync("[...document.querySelectorAll('.icon-hl-check')].map(a => a.click())");
                    await page.FillAsync("input[type=email]", email.Trim());
                    await page.EvaluateAsync("document.querySelector('button.hl-id-class[type=submit]').click()");
                    await Task.Delay(8000);

                    Debug.WriteLine($"( {email.Trim()} done");

                    //reload if not last in loop
                    if (emails.IndexOf(email) != emails.Count - 1)
                    {
                        await page.GotoAsync(url);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing {email.Trim()}: {ex.Message}");
                }
            }

            await page.CloseAsync();
        }

        public static async Task Yves(IBrowserContext context, List<string> emails)
        {
            const string url = "https://www.yves-rocher.ma/newsletter/subscribe";

            var page = await context.NewPageAsync();
            await page.GotoAsync(url);

            foreach (var email in emails)
            {
                try
                {
                    await page.FillAsync("input[type=email]", email.Trim());
                    await page.ClickAsync("#subscription-female");
                    await page.FillAsync("#firstname", "Sara");
                    await page.FillAsync("#lastname", "Abbasi");
                    await page.ClickAsync("#nlt_agreements");
                    await page.ClickAsync("button[type=submit]");
                    
                    await Task.Delay(5000);

                    Debug.WriteLine($"( {email.Trim()} done");

                    //reload if not last in loop
                    if (emails.IndexOf(email) != emails.Count - 1)
                    {
                        await page.GotoAsync(url);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing {email.Trim()}: {ex.Message}");
                }
            }
            await page.CloseAsync();
        }

        public static async Task Aib(IBrowserContext context, List<string> emails)
        {
            const string url = "https://www.aib-net.org/subscribe-newsletter";

            var page = await context.NewPageAsync();
            await page.GotoAsync(url);

            foreach (var email in emails)
            {
                try
                {
                    await page.FillAsync("input[type=email]", email.Trim());  
                    await Task.Delay(800);
                    await page.ClickAsync("button.btn-black[type=submit]");

                    await Task.Delay(5000);

                    Debug.WriteLine($"( {email.Trim()} done");

                    //reload if not last in loop
                    if (emails.IndexOf(email) != emails.Count - 1)
                    {
                        await page.GotoAsync(url);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error processing {email.Trim()}: {ex.Message}");
                }
            }
            await page.CloseAsync();
        }

        //public static async Task Buzz(IBrowserContext context, List<string> emails)
        //{
        //    const string url = "https://www.buzzfeed.com/newsletters";

        //    var page = await context.NewPageAsync();
        //    await page.GotoAsync(url);

        //    foreach (var email in emails)
        //    {
        //        try
        //        {
        //            await page.EvaluateAsync("[...document.querySelectorAll('fieldset input[type=checkbox]')].map(a => a.click())");

        //            await page.FillAsync("input[data-testid=\"email-input\" ]", email.Trim());
        //            await Task.Delay(800);
        //            await page.ClickAsync("button[type=submit]");

        //            await Task.Delay(5000);

        //            Debug.WriteLine($"( {email.Trim()} done");

        //            //reload if not last in loop
        //            if (emails.IndexOf(email) != emails.Count - 1)
        //            {
        //                await page.GotoAsync(url);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine($"Error processing {email.Trim()}: {ex.Message}");
        //        }
        //    }

        //    await page.CloseAsync();
        //}
    }
}

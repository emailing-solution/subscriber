using System.Diagnostics;

namespace subscribe
{
    internal class Installer
    {
        public async static Task Install()
        {
            Debug.WriteLine("Installing...");

            // Current path
            var path = AppDomain.CurrentDomain.BaseDirectory;

            var startInstall = new ProcessStartInfo
            {
                FileName = "pwsh",
                Arguments = path + "playwright.ps1 install",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false // Change this to true if you don't want a new window
            };

            using (var process = new Process { StartInfo = startInstall })
            {
                process.OutputDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        Debug.WriteLine(e.Data);
                        Console.WriteLine(e.Data);
                    }
                };

                process.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data != null)
                    {
                        Debug.WriteLine("Error: " + e.Data);                      
                    }
                };

                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                await process.WaitForExitAsync();

                if (process.ExitCode != 0)
                {
                    Debug.WriteLine("Error installing Playwright browsers.");
                }
                else
                {
                    Debug.WriteLine("Playwright browsers installed successfully.");
                }
            }

            Debug.WriteLine("Done");
        }
    }
}

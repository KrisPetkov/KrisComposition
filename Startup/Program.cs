using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using Web;

namespace Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MoveToProperDirectory();
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHost => webHost.UseStartup<Web.Startup>());

        private static void MoveToProperDirectory()
        {
            if (IsWwwrootPresent()) return;
            
            var parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            while (true)
            {
                var webAbbDirectory = Path.Combine(parentDirectory, nameof(Web));
                
                if (Directory.Exists(webAbbDirectory))
                {
                    Directory.SetCurrentDirectory(webAbbDirectory);
                    return;
                }

                parentDirectory = Directory.GetParent(parentDirectory).FullName;
            }
        }

        private static bool IsWwwrootPresent()
        {
            var currentPath = Directory.GetCurrentDirectory();
            var assumedWwwrootPath = Path.Combine(currentPath, "wwwroot");
            return Directory.Exists(assumedWwwrootPath);
        }
    }
}

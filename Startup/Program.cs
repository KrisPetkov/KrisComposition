using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore;
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

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost
                .CreateDefaultBuilder(args)
                .UseStartup<Web.Startup>()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<INonUiDependencyRegistry, NonUiDependencyRegistry>();
                });

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

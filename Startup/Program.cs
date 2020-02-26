using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
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

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton<INonUiDependencyRegistry, NonUiDependencyRegistry>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Web.Startup>();
                });

        private static void MoveToProperDirectory()
        {
            if (IsWwwrootPresent()) return;

            var parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var webAbbDirectory = Path.Combine(parentDirectory, "netcoreapp3.1");
            Directory.SetCurrentDirectory(webAbbDirectory);
        }

        private static bool IsWwwrootPresent()
        {
            var currentPath = Directory.GetCurrentDirectory();
            var assumedWwwrootPath = Path.Combine(currentPath, "wwwroot");
            return Directory.Exists(assumedWwwrootPath);
        }
    }
}

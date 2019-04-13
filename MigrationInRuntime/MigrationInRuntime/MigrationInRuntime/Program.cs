using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MigrationInRuntime
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            SeedWork.SeedAsync().Wait();

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

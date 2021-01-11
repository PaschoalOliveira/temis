using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace temis.api
{
    [ExcludeFromCodeCoverageAttribute]
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseUrls("http://127.0.0.1:5000","https://127.0.0.1:5001")
                    .ConfigureLogging((logging) =>
                    {
                         logging.ClearProviders();
                         logging.AddConsole();
                    });
                });
    } 
}

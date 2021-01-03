using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
namespace temis.api
{
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
                    webBuilder.UseStartup<Startup>().UseUrls("http://127.0.0.1:5000","https://127.0.0.1:5001");
                });
    }
}

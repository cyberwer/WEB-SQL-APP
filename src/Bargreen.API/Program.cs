using Bargreen.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace Bargreen.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            var builder = WebApplication.CreateBuilder(arg);
            builder.Services.AddTransient<IInventoryService, InventoryService>();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

       
    }
}

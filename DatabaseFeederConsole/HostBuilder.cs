using DXProject.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SXDatabase
{
    public class PXHostBuilder : IPXHostBuilder
    {
        public IHost Create(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);

            return hostBuilder.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>()).Build();
        }
    }
}

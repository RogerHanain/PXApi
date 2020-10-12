using DXProject.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SXDatabase
{
    public interface IPXHostBuilder
    {
        IHost Create(string[] args);
    }

    public class PXHostBuilder<T> : IPXHostBuilder where T : Startup
    {
        public IHost Create(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args);

            return hostBuilder.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<T>()).Build();
        }
    }
}

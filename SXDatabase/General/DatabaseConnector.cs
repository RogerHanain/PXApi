using DXProject.Database;
using DXProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SXDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SXDatabase
{
    public class DatabaseConnector : IAccessData
    {
        public DatabaseConnector()
        {
        }

        public IPXDbContext ConnectToDB()
        {
            var args = new List<string>();

            var host = CreateHostBuilder(args.ToArray()).Build();

            var context = GetContext(host);

            return context;
        }

        private IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
       .ConfigureWebHostDefaults(webBuilder =>
       {
           webBuilder.UseStartup<Startup>();
       });

        private static PXDbContext GetContext(IHost host)
        {
            var context = host.Services.GetRequiredService<PXDbContext>();

            return context;
        }
    }
}

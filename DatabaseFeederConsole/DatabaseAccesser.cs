using AXApi.Controllers;
using DXProject.Database;
using DXProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SXDatabase
{
    public class DatabaseAccesser : IAccessData<Word>
    {
        private PXDbContext context;

        public DatabaseAccesser()
        {
            context = ConnectToDB();

        }


        public IReadOnlyList<Word> ProvideAll()
        {
            return context.Words.ToList();
        }

        private static PXDbContext ConnectToDB()
        {
            var args = new List<string>();

            var host = CreateHostBuilder(args.ToArray()).Build();

            var context = GetContext(host);

            return context;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
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

        public void StoreAll(IReadOnlyList<Word> data)
        {
            var episods = data.Select(w => w.Episod).Distinct();
            
            foreach (var item in context.Words)
            {
                if (episods.Contains(item.Episod))
                {
                    context.Words.Remove(item);
                }
            }

            foreach (var element in data)
            {
                context.Words.Add(element);
            }

            context.SaveChanges();
        }
    }
}

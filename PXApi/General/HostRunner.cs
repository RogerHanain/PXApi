using DXProject.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SXDatabase;
using System;

namespace AXApi
{
    public class HostRunner
    {
        private IPXHostBuilder builder;
        private IHost host;
        public IHost TestHost => host;

        public HostRunner(IPXHostBuilder builder)
        {
            this.builder = builder;
        }

        public void Run(string[] args)
        {
            host = builder.Create(args);
            host.Run();
        }
    }
}

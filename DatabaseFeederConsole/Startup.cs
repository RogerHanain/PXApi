using AXApi.Controllers;
using DXProject.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SXDatabase
{
    public class Startup
    {
        static string CONNECTIONSTRING = @"Server=tcp:sql-projetx.database.windows.net,1433;Initial Catalog=database-projetx;Persist Security Info=False;User ID=Felix;Password=Ford79Freeze23Adorned;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PXDbContext>(opt => opt.UseSqlServer(CONNECTIONSTRING));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseMvc();
        }

    }
}

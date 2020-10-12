using DXProject.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SXDatabase.Models;

namespace SXDatabase
{
    public class Startup
    {
        static string CONNECTIONSTRING = @"Server=tcp:sql-projetx.database.windows.net,1433;Initial Catalog=database-projetx;Persist Security Info=False;User ID=Felix;Password=Ford79Freeze23Adorned;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PXDbContext>(opt => opt.UseSqlServer(CONNECTIONSTRING));
        }
        //dfgfdg

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }

    public class StartupAPI : Startup
    {
        static string CONNECTIONSTRING = @"Server=tcp:sql-projetx.database.windows.net,1433;Initial Catalog=database-projetx;Persist Security Info=False;User ID=Felix;Password=Ford79Freeze23Adorned;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public StartupAPI(IConfiguration configuration) : base(configuration) { }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PXDbContext>(opt => opt.UseSqlServer(CONNECTIONSTRING));

            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMvc();
        }
    }
}

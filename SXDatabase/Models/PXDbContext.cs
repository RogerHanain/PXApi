using DXProject.Database;
using DXProject.Models;
using Microsoft.EntityFrameworkCore;

namespace SXDatabase.Models
{

    public class PXDbContext : DbContext, IPXDbContext
    {
        public PXDbContext() : base()
        {
        }

        public PXDbContext(DbContextOptions<PXDbContext> options) : base(options)
        {
        }

        static string CONNECTIONSTRING = @"Server=tcp:sql-projetx.database.windows.net,1433;Initial Catalog=database-projetx;Persist Security Info=False;User ID=Felix;Password=Ford79Freeze23Adorned;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        public DbSet<Word> Words { get; set; }

        public DbSet<Translation> Translations { get; set; }

        public DbSet<Request> Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(CONNECTIONSTRING);
            }
        }
    }
}

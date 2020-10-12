using DXProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DXProject.Database
{
    public interface IPXDbContext
    {
        DbSet<Translation> Translations { get; set; }
        DbSet<Word> Words { get; set; }
    }
}

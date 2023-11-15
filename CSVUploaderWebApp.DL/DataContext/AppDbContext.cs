using CSVUploaderWebApp.DL.Models;
using Microsoft.EntityFrameworkCore;

namespace CSVUploaderWebApp.DL.DataContext;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<ContactData> Contacts { get; set; }
}
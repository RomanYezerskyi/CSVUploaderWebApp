using CSVUploaderWebApp.DL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CSVUploaderWebApp.DL.Extensions;

public static class MsSqlServiceExtensions
{
    public static void AddMssqlDbContext(this IServiceCollection serviceCollection, IConfiguration config)
    {
        serviceCollection.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(
                config.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("CSVUploaderWebApp.DL")
            );
        });
    }
}
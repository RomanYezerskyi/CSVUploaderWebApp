using CSVUploaderWebApp.DL.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CSVUploaderWebApp.DL.Extensions;

public static class EnsureMigration
{
    public static async Task EnsureMigrationOfContext(WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        await using var db = scope.ServiceProvider.GetService<AppDbContext>();
        await db?.Database.MigrateAsync();
    }
}
using CSVUploaderWebApp.BL.Interfaces;
using CSVUploaderWebApp.BL.Services;
using CSVUploaderWebApp.PipelineBehaviours;
using MediatR;

namespace CSVUploaderWebApp.DependencyInjection;

public static class ServiceInjector
{
    public static IServiceCollection InjectServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddScoped<ICsvReaderService, CsvReaderService>();

        return services;
    }
}

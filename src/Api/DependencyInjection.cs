using System.Reflection;
using Api.Extensions;
using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using Serilog.Debugging;

namespace Api;

public static class DependencyInjection
{
    private static readonly Assembly CurrentAssembly = typeof(DependencyInjection).Assembly;
    
    public static IServiceCollection AddApi(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        services.AddAutoMapper(CurrentAssembly);
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddHttpLogging();
        services.AddVersioning();
        builder.AddSwaggerDoc();
        builder.AddSerilog();
        return services;
    }
    
    private static void AddHttpLogging(this IServiceCollection services)
    {
        services.AddHttpLogging(logging =>
        {
            logging.LoggingFields = HttpLoggingFields.All;
            logging.CombineLogs = true;
        });
    }
    
    private static void AddSerilog(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        
        builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
        {
            SelfLog.Enable(Console.Error);

            loggerConfiguration
                .ReadFrom.Configuration(hostingContext.Configuration)
                .Enrich.FromLogContext();
        });
    }
}
using Application.Abstractions;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDummyRepository, DummyRepository>();
        services.AddDbContext<DummyDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DummiesDBConnection"));
        });
        return services;
    }
}
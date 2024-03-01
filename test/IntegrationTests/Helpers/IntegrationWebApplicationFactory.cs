using Api;
using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace IntegrationTests.Helpers;

public class IntegrationWebApplicationFactory : WebApplicationFactory<Startup>
{
    public List<Dummy> Dummies { get; private set; } = [];

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddDebug().AddConsole();
        });
        
        builder.ConfigureAppConfiguration((_, _) =>
        {
        });

        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll<DbContextOptions<DummyDbContext>>();
            services.RemoveAll<DummyDbContext>();
            services.AddDbContext<DummyDbContext>(options =>
            {
                options.UseSqlite("Data Source=DummiesDatabaseForTests.db");
            });

            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var scopedServiceProvider = scope.ServiceProvider;
            var context = scopedServiceProvider.GetRequiredService<DummyDbContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Dummies = context.Set<Dummy>().Take(2).ToList();
        });
    }
}
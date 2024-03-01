using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts;

public sealed class DummyDbContext : DbContext
{
    private static readonly Assembly CurrentAssembly = typeof(DependencyInjection).Assembly;
    
    public DummyDbContext(DbContextOptions<DummyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(CurrentAssembly);
    }
}
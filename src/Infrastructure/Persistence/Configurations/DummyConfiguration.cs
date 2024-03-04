using Domain.Models.Entities;
using Domain.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public sealed class DummyConfiguration : IEntityTypeConfiguration<Dummy>
{
    public void Configure(EntityTypeBuilder<Dummy> builder)
    {
        builder
            .Property(x => x.Id)
            .HasConversion(dummyId => dummyId.Value, dummyIdValue => new DummyId(dummyIdValue));
        
        builder
            .Property(x => x.Name)
            .HasConversion(dummyName => dummyName.Value, dummyNameValue => new DummyName(dummyNameValue));

        builder
            .HasData(new List<Dummy>
            {
                CreateDummy(Guid.NewGuid()),
                CreateDummy(Guid.NewGuid())
            });
    }
    
    private static Dummy CreateDummy(Guid id) => Dummy.CreateDummy($"id-{id:N}", $"name-{id:N}");
}
using Domain.Models.ValueObjects;

namespace Domain.Models.Entities;

public sealed class Dummy
{
    public DummyId Id { get; }
    public DummyName Name { get; }
    
    private Dummy(DummyId id, DummyName name)
    {
        Id = id;
        Name = name;
    }

    public static Dummy CreateDummy(DummyId id, DummyName name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id.Value);
        ArgumentException.ThrowIfNullOrWhiteSpace(name.Value);
        var dummy = new Dummy(id, name);
        return dummy;
    }
}
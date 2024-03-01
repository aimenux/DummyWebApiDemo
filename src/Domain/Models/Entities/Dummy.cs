using Domain.Models.ValueObjects;

namespace Domain.Models.Entities;

public sealed class Dummy
{
    public DummyId Id { get; private init; }
    public DummyName Name { get; private init; }
    
    private Dummy(DummyId id, DummyName name)
    {
        Id = id;
        Name = name;
    }

    public static Dummy CreateDummy(DummyId id, DummyName name)
    {
        var dummy = new Dummy(id, name);
        return dummy;
    }
}
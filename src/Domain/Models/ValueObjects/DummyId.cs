namespace Domain.Models.ValueObjects;

public sealed record DummyId(string Value)
{
    public static implicit operator DummyId(string id) => new(id);
}
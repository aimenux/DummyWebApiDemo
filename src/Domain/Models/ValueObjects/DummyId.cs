namespace Domain.Models.ValueObjects;

public sealed record DummyId(Guid Value)
{
    public static implicit operator DummyId(Guid id) => new(id);
}
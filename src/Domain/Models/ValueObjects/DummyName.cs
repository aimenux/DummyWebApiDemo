namespace Domain.Models.ValueObjects;

public sealed record DummyName(string Value)
{
    public static implicit operator DummyName(string name) => new(name);
}
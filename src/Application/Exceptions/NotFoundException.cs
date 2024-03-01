using Domain.Models.ValueObjects;

namespace Application.Exceptions;

public sealed class NotFoundException : Exception
{
    private NotFoundException(string message) : base(message)
    {
    }

    public static NotFoundException DummyIsNotFound(DummyId dummyId)
    {
        return new NotFoundException($"Dummy ({dummyId.Value}) is not found.");
    }
}
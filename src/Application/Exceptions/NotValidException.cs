using FluentValidation.Results;

namespace Application.Exceptions;

public sealed class NotValidException : Exception
{
    private NotValidException() : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public NotValidException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IReadOnlyDictionary<string, string[]> Errors { get; }
}
using FluentValidation;

namespace Application.UseCases.Queries.GetDummies;

public sealed class GetDummiesQueryValidator : AbstractValidator<GetDummiesQuery>
{
    public GetDummiesQueryValidator()
    {
    }
}
using FluentValidation;

namespace Application.UseCases.Queries.SearchDummies;

public sealed class SearchDummiesQueryValidator : AbstractValidator<SearchDummiesQuery>
{
    public SearchDummiesQueryValidator()
    {
        RuleFor(x => x.Keyword)
            .NotEmpty();
    }
}
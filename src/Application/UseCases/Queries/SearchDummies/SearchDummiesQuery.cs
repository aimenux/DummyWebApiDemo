using MediatR;

namespace Application.UseCases.Queries.SearchDummies;

public sealed record SearchDummiesQuery(string Keyword) : IRequest<SearchDummiesQueryResponse>;
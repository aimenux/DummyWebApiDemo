using Application.Abstractions;
using MediatR;

namespace Application.UseCases.Queries.SearchDummies;

public class SearchDummiesQueryHandler : IRequestHandler<SearchDummiesQuery, SearchDummiesQueryResponse>
{
    private readonly IDummyRepository _dummyRepository;

    public SearchDummiesQueryHandler(IDummyRepository dummyRepository)
    {
        _dummyRepository = dummyRepository;
    }

    public async Task<SearchDummiesQueryResponse> Handle(SearchDummiesQuery query, CancellationToken cancellationToken)
    {
        var dummies = await _dummyRepository.SearchDummiesAsync(query.Keyword, cancellationToken);
        var queryResponse = new SearchDummiesQueryResponse(dummies);
        return queryResponse;
    }
}
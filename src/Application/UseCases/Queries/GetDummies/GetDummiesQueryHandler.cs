using Application.Abstractions;
using MediatR;

namespace Application.UseCases.Queries.GetDummies;

public sealed class GetDummiesQueryHandler : IRequestHandler<GetDummiesQuery, GetDummiesQueryResponse>
{
    private readonly IDummyRepository _dummyRepository;

    public GetDummiesQueryHandler(IDummyRepository dummyRepository)
    {
        _dummyRepository = dummyRepository;
    }

    public async Task<GetDummiesQueryResponse> Handle(GetDummiesQuery request, CancellationToken cancellationToken)
    {
        var dummies = await _dummyRepository.GetDummiesAsync(cancellationToken);
        return new GetDummiesQueryResponse(dummies);
    }
}
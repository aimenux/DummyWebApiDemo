using MediatR;

namespace Application.UseCases.Queries.GetDummy;

public sealed record GetDummyQuery(string Id) : IRequest<GetDummyQueryResponse>;
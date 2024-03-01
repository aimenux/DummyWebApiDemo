using MediatR;

namespace Application.UseCases.Queries.GetDummies;

public sealed record GetDummiesQuery : IRequest<GetDummiesQueryResponse>;
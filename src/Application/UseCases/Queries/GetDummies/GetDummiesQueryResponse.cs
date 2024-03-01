using Domain.Models.Entities;

namespace Application.UseCases.Queries.GetDummies;

public sealed record GetDummiesQueryResponse(ICollection<Dummy> Dummies);
using Domain.Models.Entities;

namespace Application.UseCases.Queries.SearchDummies;

public sealed record SearchDummiesQueryResponse(ICollection<Dummy> Dummies);
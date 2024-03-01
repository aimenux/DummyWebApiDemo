namespace Api.Presentation.Controllers.Dummies.V2.GetDummies;

public sealed record GetDummiesResponse(ICollection<GetDummyDto> Dummies);

public sealed record GetDummyDto(string Id, string Name);
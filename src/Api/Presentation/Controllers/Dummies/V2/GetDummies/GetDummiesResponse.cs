namespace Api.Presentation.Controllers.Dummies.V2.GetDummies;

public sealed record GetDummiesResponse(ICollection<DummyDto> Dummies);

public sealed record DummyDto(string Id, string Name);
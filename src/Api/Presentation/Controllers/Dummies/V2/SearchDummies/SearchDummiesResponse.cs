namespace Api.Presentation.Controllers.Dummies.V2.SearchDummies;

public record SearchDummiesResponse(ICollection<SearchDummyDto> Dummies);

public sealed record SearchDummyDto(string Id, string Name);
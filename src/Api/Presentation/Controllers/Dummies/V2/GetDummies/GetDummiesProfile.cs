using Application.UseCases.Queries.GetDummies;
using AutoMapper;
using Domain.Models.Entities;

namespace Api.Presentation.Controllers.Dummies.V2.GetDummies;

public sealed class GetDummiesProfile : Profile
{
    public GetDummiesProfile()
    {
        CreateMap<GetDummiesRequest, GetDummiesQuery>();
        CreateMap<GetDummiesQueryResponse, GetDummiesResponse>();
        CreateMap<Dummy, DummyDto>()
            .ForCtorParam(nameof(DummyDto.Id), opt => opt.MapFrom(src => src.Id.Value))
            .ForCtorParam(nameof(DummyDto.Name), opt => opt.MapFrom(src => src.Name.Value));
    }
}
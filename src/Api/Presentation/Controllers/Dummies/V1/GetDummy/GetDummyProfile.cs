using Application.UseCases.Queries.GetDummy;
using AutoMapper;

namespace Api.Presentation.Controllers.Dummies.V1.GetDummy;

public sealed class GetDummyProfile : Profile
{
    public GetDummyProfile()
    {
        CreateMap<GetDummyRequest, GetDummyQuery>();
        CreateMap<GetDummyQueryResponse, GetDummyResponse>()
            .ForCtorParam(nameof(GetDummyResponse.Id), opt => opt.MapFrom(src => src.Dummy.Id.Value))
            .ForCtorParam(nameof(GetDummyResponse.Name), opt => opt.MapFrom(src => src.Dummy.Name.Value));
    }
}
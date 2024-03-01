using Api.Presentation.Controllers.Dummies.V1.GetDummy;
using Application.UseCases.Queries.GetDummy;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using UnitTests.Helpers;

namespace UnitTests;

public class GetDummyTests
{
    private static readonly IFixture Fixture = new Fixture();
    
    private static readonly IMapper Mapper = new MapperBuilder()
        .WithProfile<GetDummyProfile>()
        .Build();
    
    [Fact]
    public void Should_Map_GetDummyRequest_To_GetDummyQuery()
    {
        // arrange
        var request = Fixture.Create<GetDummyRequest>();

        // act
        var query = Mapper.Map<GetDummyQuery>(request);

        // assert
        query.Should().NotBeNull();
        query.Id.Should().Be(request.Id);
    }
    
    [Fact]
    public void Should_Map_GetDummyQueryResponse_To_GetDummyResponse()
    {
        // arrange
        var queryResponse = Fixture.Create<GetDummyQueryResponse>();

        // act
        var response = Mapper.Map<GetDummyResponse>(queryResponse);

        // assert
        response.Should().NotBeNull();
        response.Id.Should().Be(queryResponse.Dummy.Id.Value.ToString());
        response.Name.Should().Be(queryResponse.Dummy.Name.Value);
    }
}
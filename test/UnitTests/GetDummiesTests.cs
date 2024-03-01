using Api.Presentation.Controllers.Dummies.V2.GetDummies;
using Application.UseCases.Queries.GetDummies;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using UnitTests.Helpers;

namespace UnitTests;

public class GetDummiesTests
{
    private static readonly IFixture Fixture = new Fixture();
    
    private static readonly IMapper Mapper = new MapperBuilder()
        .WithProfile<GetDummiesProfile>()
        .Build();

    [Fact]
    public void Should_Map_GetDummiesRequest_To_GetDummiesQuery()
    {
        // arrange
        var request = Fixture.Create<GetDummiesRequest>();

        // act
        var query = Mapper.Map<GetDummiesQuery>(request);

        // assert
        query.Should().NotBeNull();
    }
    
    [Fact]
    public void Should_Map_GetDummiesQueryResponse_To_GetDummiesResponse()
    {
        // arrange
        var queryResponse = Fixture.Create<GetDummiesQueryResponse>();

        // act
        var response = Mapper.Map<GetDummiesResponse>(queryResponse);

        // assert
        response.Should().NotBeNull();
        response.Dummies.Should().NotBeNullOrEmpty();
        response.Dummies.Should().HaveCount(queryResponse.Dummies.Count);
    }
}
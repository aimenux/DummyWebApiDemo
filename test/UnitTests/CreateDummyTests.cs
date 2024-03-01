using Api.Presentation.Controllers.Dummies.V1.CreateDummy;
using Application.UseCases.Commands.CreateDummy;
using AutoFixture;
using AutoMapper;
using FluentAssertions;
using UnitTests.Helpers;

namespace UnitTests;

public class CreateDummyTests
{
    private static readonly IFixture Fixture = new Fixture();
    
    private static readonly IMapper Mapper = new MapperBuilder()
        .WithProfile<CreateDummyProfile>()
        .Build();
    
    [Fact]
    public void Should_Map_CreateDummyRequest_To_CreateDummyCommand()
    {
        // arrange
        var request = Fixture.Create<CreateDummyRequest>();

        // act
        var command = Mapper.Map<CreateDummyCommand>(request);

        // assert
        command.Should().NotBeNull();
        command.Name.Should().Be(request.Name);
    }
    
    [Fact]
    public void Should_Map_CreateDummyCommandResponse_To_CreateDummyResponse()
    {
        // arrange
        var commandResponse = Fixture.Create<CreateDummyCommandResponse>();

        // act
        var response = Mapper.Map<CreateDummyResponse>(commandResponse);

        // assert
        response.Should().NotBeNull();
        response.Id.Should().Be(commandResponse.Dummy.Id.Value.ToString());
        response.Name.Should().Be(commandResponse.Dummy.Name.Value);
    }
}
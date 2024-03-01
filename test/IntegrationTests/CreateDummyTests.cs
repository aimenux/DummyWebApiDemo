using System.Net;
using System.Net.Http.Json;
using Api.Presentation.Controllers.Dummies.V1.CreateDummy;
using FluentAssertions;
using IntegrationTests.Helpers;

namespace IntegrationTests;

[Collection(IntegrationCollectionFixture.CollectionName)]
public class CreateDummyTests
{
    private readonly IntegrationWebApplicationFactory _factory;

    public CreateDummyTests(IntegrationWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("api/v1/dummies")]
    [InlineData("api/v2/dummies")]
    public async Task Should_Create_Dummies_Returns_Created(string route)
    {
        // arrange
        var client = _factory.CreateClient();
        var dummyName = Guid.NewGuid().ToString("N");
        var request = new CreateDummyRequest(dummyName);

        // act
        var response = await client.PostAsJsonAsync(route, request);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}
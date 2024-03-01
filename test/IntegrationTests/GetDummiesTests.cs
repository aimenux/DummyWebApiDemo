using System.Net;
using FluentAssertions;
using IntegrationTests.Helpers;

namespace IntegrationTests;

[Collection(IntegrationCollectionFixture.CollectionName)]
public class GetDummiesTests
{
    private readonly IntegrationWebApplicationFactory _factory;

    public GetDummiesTests(IntegrationWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("api/v2/dummies")]
    public async Task Should_Get_Dummies_Returns_Ok(string route)
    {
        // arrange
        var client = _factory.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}
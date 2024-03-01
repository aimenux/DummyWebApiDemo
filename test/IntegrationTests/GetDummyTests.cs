using System.Net;
using FluentAssertions;
using IntegrationTests.Helpers;

namespace IntegrationTests;

[Collection(IntegrationCollectionFixture.CollectionName)]
public class GetDummyTests
{
    private readonly IntegrationWebApplicationFactory _factory;

    public GetDummyTests(IntegrationWebApplicationFactory factory)
    {
        _factory = factory;
    }
    
    [Theory]
    [InlineData("api/v1/dummies")]
    [InlineData("api/v2/dummies")]
    public async Task Should_Get_Dummy_Returns_Ok(string route)
    {
        // arrange
        var client = _factory.CreateClient();
        var dummyId = _factory.Dummies.First().Id;

        // act
        var response = await client.GetAsync($"{route}/{dummyId.Value}");
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}
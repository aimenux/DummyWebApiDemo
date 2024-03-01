using System.Net;
using FluentAssertions;
using IntegrationTests.Helpers;

namespace IntegrationTests;

[Collection(IntegrationCollectionFixture.CollectionName)]
public class SearchDummiesTests
{
    private readonly IntegrationWebApplicationFactory _factory;

    public SearchDummiesTests(IntegrationWebApplicationFactory factory)
    {
        _factory = factory;
    }
    
    [Theory]
    [InlineData("api/v2/dummies/search")]
    public async Task Should_Search_Dummies_Returns_Ok(string route)
    {
        // arrange
        var client = _factory.CreateClient();
        var dummyName = _factory.Dummies.First().Name;

        // act
        var response = await client.GetAsync($"{route}?keyword={dummyName.Value}");
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}
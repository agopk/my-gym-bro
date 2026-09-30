using System.Net;
using Testcontainers.PostgreSql;

namespace MyGymBro.Api.Tests;

public sealed class HealthEndpointTests : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder("postgres:18")
        .Build();

    public async Task InitializeAsync()
    {
        await _postgres.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _postgres.DisposeAsync();
    }

    [Fact]
    public async Task GetHealth_WhenPostgresAcceptsConnections_ReturnsOk()
    {
        await using var factory = new MyGymBroApiFactory(_postgres.GetConnectionString());
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/health");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Healthy", await response.Content.ReadAsStringAsync());
    }
}

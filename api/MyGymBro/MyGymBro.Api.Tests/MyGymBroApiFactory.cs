using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MyGymBro.Api.Tests;

public sealed class MyGymBroApiFactory : WebApplicationFactory<Program>
{
    private readonly string _connectionString;

    public MyGymBroApiFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");
        builder.UseSetting("ConnectionStrings:Database", _connectionString);
    }
}

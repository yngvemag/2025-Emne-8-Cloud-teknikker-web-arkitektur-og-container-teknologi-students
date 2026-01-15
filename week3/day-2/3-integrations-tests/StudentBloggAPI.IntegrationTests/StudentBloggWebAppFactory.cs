using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Testcontainers.MySql;

namespace StudentBloggAPI.IntegrationTests;

public class StudentBloggWebAppFactory : WebApplicationFactory<Program>, 
    IAsyncLifetime
{
    private readonly MySqlContainer _mySqlContainer;

    public StudentBloggWebAppFactory()
    {
        _mySqlContainer = new MySqlBuilder("yngvemag/studentblogg-db")
            .WithDatabase("ga_studentblogg")
            .WithUsername("ga-app")
            .WithPassword("ga-5ecret-%")
            .Build();

        // Start container synchronously (Option A: xUnit v2, no IAsyncLifetime)
        _mySqlContainer.StartAsync(CancellationToken.None).GetAwaiter().GetResult();
    }

    // Ensure container is stopped and base resources are disposed
    public async Task InitializeAsync()
    {
        await _mySqlContainer.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await _mySqlContainer.StopAsync();
    }
}
namespace StudentBloggAPI.IntegrationTests.Features;

public class IntegrationTestsBase(StudentBloggWebAppFactory factory)
    : IClassFixture<StudentBloggWebAppFactory>, IDisposable
{
    public HttpClient? Client { get; init; } = factory.CreateClient();

    // Centralized per-test cancellation token (xUnit v2)
    private CancellationToken Ct => CancellationToken.None;

    // Optional helpers to auto-flow CT
    protected Task<HttpResponseMessage> GetAsync(string uri) =>
        Client!.GetAsync(uri, Ct);

    protected Task<HttpResponseMessage> SendAsync(HttpRequestMessage request) =>
        Client!.SendAsync(request, Ct);

    public void Dispose() => Client?.Dispose();
}
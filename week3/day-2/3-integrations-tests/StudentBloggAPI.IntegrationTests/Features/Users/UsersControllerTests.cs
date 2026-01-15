using System.Net;

namespace StudentBloggAPI.IntegrationTests.Features.Users;

public class UsersControllerTests(StudentBloggWebAppFactory factory) 
    : IntegrationTestsBase(factory)
{

    [Fact]
    public async Task GetUserAsync_DefaultPageSize_ShouldReturnOk()
    {
        var response = await GetAsync("/api/v1/Users/");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
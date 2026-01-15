using System;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace StudentBloggAPI.Features.Hello;

[ApiController]
[Route("api/v1/[controller]")]
public class HelloController(ILogger<HelloController> logger) : ControllerBase
{
    private readonly ILogger<HelloController> _logger = logger;

    [HttpGet]
    public async Task<ActionResult<string>> SayHello()
    {
         await Task.Delay(20);
        
        _logger.LogInformation("Hello from API");

        await Task.Delay(20);
        string hostName = System.Net.Dns.GetHostName();
        StringBuilder sb = new();
        foreach (var adr in System.Net.Dns.GetHostEntry(hostName).AddressList)
            sb.Append($"Address: {adr.AddressFamily} {adr.ToString()}\n");

        return Ok(sb.ToString());
        
    }

}

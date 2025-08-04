using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    /// <summary>
    /// Ping the service to check if it's alive.
    /// </summary>
    /// <returns>Returns "Pong" if the service is reachable.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Pong");
    }
}

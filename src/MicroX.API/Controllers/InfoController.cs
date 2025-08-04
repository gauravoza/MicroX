using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class InfoController : ControllerBase
{
    /// <summary>
    /// Returns basic information about the service.
    /// </summary>
    /// <returns>Service metadata like name, environment, and version.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        var info = new
        {
            Service = "MicroX.API",
            Environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"),
            Version = "1.0.0"
        };

        return Ok(info);
    }
}

using Microsoft.AspNetCore.Mvc;
using MicroX.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class RedisDemoController : ControllerBase
{
    private readonly IRedisCacheService _redis;

    public RedisDemoController(IRedisCacheService redis)
    {
        _redis = redis;
    }

    [HttpGet("set")]
    public async Task<IActionResult> Set()
    {
        await _redis.SetAsync("microx:test", "Hello Redis", TimeSpan.FromMinutes(5));
        return Ok("Cached");
    }

    [HttpGet("get")]
    public async Task<IActionResult> Get()
    {
        var value = await _redis.GetAsync("microx:test");
        return Ok(value ?? "No value found");
    }
}

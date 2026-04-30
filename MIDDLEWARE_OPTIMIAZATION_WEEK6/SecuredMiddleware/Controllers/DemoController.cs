using Microsoft.AspNetCore.Mvc;

namespace SecuredMiddleware.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemoController : ControllerBase
{
    [HttpGet("ping")]
    public ActionResult<object> Ping()
    {
        return Ok(new
        {
            Message = "pong",
            Source = "DemoController"
        });
    }

    [HttpGet("echo")]
    public ActionResult<object> Echo([FromQuery] string input)
    {
        return Ok(new
        {
            Message = "echo",
            Input = input
        });
    }

    [HttpGet("users/{id:int}")]
    public ActionResult<object> GetUser(int id)
    {
        return Ok(new
        {
            Id = id,
            Name = $"User{id}",
            Email = $"user{id}@example.com"
        });
    }
}

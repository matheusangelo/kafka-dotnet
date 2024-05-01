using App.Application;
using App.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace App.Producer.Controllers;

[ApiController]
[Route("producer")]
public class ProducerController : ControllerBase
{
    private readonly ILogger<ProducerController> _logger;

    public ProducerController(ILogger<ProducerController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "message")]
    public IActionResult Get(
        [FromServices] IProducerService message,
        [FromBody] CreateMessageDTO body
    )
    {
        message.CreateMessage(body);
        return Ok("Initial Controller");
    }
}

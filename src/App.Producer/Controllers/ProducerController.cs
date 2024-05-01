using App.Application;
using App.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace App.Producer.Controllers;

[ApiController]
[Route("producer")]
public class ProducerController : ControllerBase
{
    public ProducerController()
    {
    }

    [HttpPost(Name = "message")]
    public IActionResult Get([FromServices] IProducerService message, [FromBody] CreateMessageDTO body) => Ok(message.CreateMessage(body));
}

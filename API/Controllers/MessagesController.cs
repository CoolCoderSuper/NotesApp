using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class MessagesController : ControllerBase
{

    [HttpGet(Name = "GetMessages")]
    public IEnumerable<Message> Get()
    {
        return Message.GetMessages();
    }
}

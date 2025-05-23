using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController : ControllerBase
{

    private readonly ILogger<ToDoController> _logger;

    public ToDoController(ILogger<ToDoController> logger)
    {
        _logger = logger;
    }

  

}

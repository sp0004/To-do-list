using Microsoft.AspNetCore.Mvc;
using ToDo.Models;

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

    [HttpGet(Name = "getAllTasks")]
    public IEnumerable<ToDoItems> getAllTasks()
    {
        var taskList = new ToDoItems();
        return (IEnumerable<ToDoItems>)taskList;
    }

}

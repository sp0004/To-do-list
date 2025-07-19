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

    [HttpGet("db-health")]
    public IActionResult CheckDatabaseConnection([FromServices] ToDoContext context)
    {
        try
        {
            // Try to query the database
            var canConnect = context.Database.CanConnect();
            if (canConnect)
                return Ok("Database connection successful.");
            else
                return StatusCode(500, "Database connection failed.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Database connection error: {ex.Message}");
        }
}

}

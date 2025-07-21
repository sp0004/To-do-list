using Microsoft.AspNetCore.Mvc;
using ToDo.Models;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController : ControllerBase
{

    private readonly ILogger<ToDoController> _logger;
    private readonly ToDoContext _context;

    public ToDoController(ILogger<ToDoController> logger, ToDoContext context)
    {
        _logger = logger;
        _context = context;
    }



    [HttpGet("db-health")]
    public IActionResult CheckDatabaseConnection()
    {
        try
        {
            // Try to query the database
            var canConnect = _context.Database.CanConnect();
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

    [HttpGet("get-all-tasks")]
    public ActionResult<ToDoContext> getAllTheTasks()
    {
        return Ok(_context);
        // return Ok("hell");
    }

}

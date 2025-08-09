using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    private readonly ILogger<ToDoController> _logger;
    private readonly IToDoService _toDoService;

    public ToDoController(ILogger<ToDoController> logger, IToDoService toDoService)
    {
        _logger = logger;
        _toDoService = toDoService;
    }

    [HttpGet("db-health")]
    public async Task<IActionResult> CheckDatabaseConnection()
    {
        try
        {
            var canConnect = await _toDoService.CheckDatabaseConnectionAsync();
            if (canConnect)
                return Ok(new { message = "Database connection successful.", status = "healthy" });
            else
                return StatusCode(500, new { message = "Database connection failed.", status = "unhealthy" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Database connection check failed");
            return StatusCode(500, new { message = $"Database connection error: {ex.Message}", status = "error" });
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoItem>>> GetAllTasks()
    {
        try
        {
            var tasks = await _toDoService.GetAllTasksAsync();
            return Ok(tasks);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving all tasks");
            return StatusCode(500, new { message = "Error retrieving tasks", error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItem>> GetTask(Guid id)
    {
        try
        {
            var task = await _toDoService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound(new { message = $"Task with ID {id} not found" });
            }
            return Ok(task);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving task with ID: {TaskId}", id);
            return StatusCode(500, new { message = "Error retrieving task", error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<ToDoItem>> CreateTask([FromBody] ToDoItem task)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTask = await _toDoService.CreateTaskAsync(task);
            return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating task");
            return StatusCode(500, new { message = "Error creating task", error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ToDoItem>> UpdateTask(Guid id, [FromBody] ToDoItem task)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTask = await _toDoService.UpdateTaskAsync(id, task);
            if (updatedTask == null)
            {
                return NotFound(new { message = $"Task with ID {id} not found" });
            }

            return Ok(updatedTask);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating task with ID: {TaskId}", id);
            return StatusCode(500, new { message = "Error updating task", error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        try
        {
            var deleted = await _toDoService.DeleteTaskAsync(id);
            if (!deleted)
            {
                return NotFound(new { message = $"Task with ID {id} not found" });
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting task with ID: {TaskId}", id);
            return StatusCode(500, new { message = "Error deleting task", error = ex.Message });
        }
    }
}

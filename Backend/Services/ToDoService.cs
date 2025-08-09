using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace Backend.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoContext _context;
        private readonly ILogger<ToDoService> _logger;

        public ToDoService(ToDoContext context, ILogger<ToDoService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ToDoItem>> GetAllTasksAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all tasks");
                return await _context.ToDoItems.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all tasks");
                throw;
            }
        }

        public async Task<ToDoItem?> GetTaskByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Fetching task with ID: {TaskId}", id);
                return await _context.ToDoItems.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching task with ID: {TaskId}", id);
                throw;
            }
        }

        public async Task<ToDoItem> CreateTaskAsync(ToDoItem task)
        {
            try
            {
                _logger.LogInformation("Creating new task: {TaskName}", task.TaskName);
                task.CreatedOn = DateTime.UtcNow;
                task.UpdatedOn = DateTime.UtcNow;
                _context.ToDoItems.Add(task);
                await _context.SaveChangesAsync();
                return task;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating task: {TaskName}", task.TaskName);
                throw;
            }
        }

        public async Task<ToDoItem?> UpdateTaskAsync(Guid id, ToDoItem task)
        {
            try
            {
                _logger.LogInformation("Updating task with ID: {TaskId}", id);
                var existingTask = await _context.ToDoItems.FindAsync(id);
                if (existingTask == null)
                {
                    return null;
                }

                existingTask.TaskName = task.TaskName;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
                existingTask.IsComplete = task.IsComplete;
                existingTask.UpdatedOn = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                return existingTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating task with ID: {TaskId}", id);
                throw;
            }
        }

        public async Task<bool> DeleteTaskAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Deleting task with ID: {TaskId}", id);
                var task = await _context.ToDoItems.FindAsync(id);
                if (task == null)
                {
                    return false;
                }

                _context.ToDoItems.Remove(task);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting task with ID: {TaskId}", id);
                throw;
            }
        }

        public async Task<bool> CheckDatabaseConnectionAsync()
        {
            try
            {
                _logger.LogInformation("Checking database connection");
                return await _context.Database.CanConnectAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking database connection");
                return false;
            }
        }
    }
}

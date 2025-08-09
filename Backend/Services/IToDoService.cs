using ToDo.Models;

namespace Backend.Services
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoItem>> GetAllTasksAsync();
        Task<ToDoItem?> GetTaskByIdAsync(Guid id);
        Task<ToDoItem> CreateTaskAsync(ToDoItem task);
        Task<ToDoItem?> UpdateTaskAsync(Guid id, ToDoItem task);
        Task<bool> DeleteTaskAsync(Guid id);
        Task<bool> CheckDatabaseConnectionAsync();
    }
}

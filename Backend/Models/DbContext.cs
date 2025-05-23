using Microsoft.EntityFrameworkCore;

namespace ToDo.Models;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {

    }


    public DbSet<ToDo> ToDoItems { get; set; }
    
}
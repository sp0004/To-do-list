using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Models;

public class ToDoItem
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public string TaskName { get; set; } = "";

    public DateTime CreatedOn { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime UpdatedOn { get; set; }
    public string Description { get; set; } = "";

    public bool IsOverdue { get; set; }

    public bool IsComplete { get; set; }

    public bool IsDeleted { get; set; }


}
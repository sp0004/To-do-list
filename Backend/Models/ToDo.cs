using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Models;

public class ToDoItems
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
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
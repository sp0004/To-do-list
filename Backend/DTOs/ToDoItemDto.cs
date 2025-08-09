using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class CreateToDoItemDto
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string TaskName { get; set; } = "";
        
        [StringLength(1000)]
        public string Description { get; set; } = "";
        
        public DateTime DueDate { get; set; }
    }

    public class UpdateToDoItemDto
    {
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string TaskName { get; set; } = "";
        
        [StringLength(1000)]
        public string Description { get; set; } = "";
        
        public DateTime DueDate { get; set; }
        
        public bool IsComplete { get; set; }
    }

    public class ToDoItemResponseDto
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime CreatedOn { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsOverdue { get; set; }
        public bool IsComplete { get; set; }
    }
}

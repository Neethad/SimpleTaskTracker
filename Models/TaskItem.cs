using System.ComponentModel.DataAnnotations;

namespace SimpleTaskTracker.Models;

public class TaskItem
{
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Title { get; set; } = string.Empty;

    [StringLength(250)]
    public string? Description { get; set; }

    public bool IsCompleted { get; set; }
}

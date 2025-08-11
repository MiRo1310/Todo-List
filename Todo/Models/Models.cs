namespace Todo.Models;

public class SetStatus
{
    public Guid Id { get; set; }
    public bool Status { get; set; } = true;
}

public class UpdateTodoRequest
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? IsComplete { get; set; }
}

public class CreateTodoRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; } = null;
}

public class Todo(string title, string description, DateTime? dueDate)
{
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; } = dueDate;
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsCompleted { get; set; } = false;
}
namespace Todo.Services;

public class Todo(string title, string description, DateTime? dueDate)
{
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? DueDate { get; set; } = dueDate;
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsCompleted { get; set; } = false;
}
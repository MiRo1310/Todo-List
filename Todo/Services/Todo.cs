namespace Todo.Services;

public class Todo(string title, string description)
{
    public string Title { get; set; } = title;
    public string Description { get; set; } = description;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsCompleted { get; set; } = false;
}
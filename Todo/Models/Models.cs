namespace Todo.Models
{
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
}
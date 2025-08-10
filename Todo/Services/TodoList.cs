using Todo.Models;

namespace Todo.Services;

public class TodoList
{
    private readonly List<Todo> _todos = [];

    public TodoList()
    {
        SeedTodos();
    }

    public IEnumerable<Todo> GetTodos()
    {
        return _todos;
    }

    public void AddTodo(Todo todo)
    {
        _todos.Add(todo);
    }

    public IEnumerable<Todo> GetTodosByDueDate(DateTime dateTime)
    {
        return _todos.Where(todo => todo.DueDate >= dateTime);
    }

    public OperationResult RemoveTodo(Guid id)
    {
        var index = GetIndexOf(id);

        if (index == -1) return new OperationResult(false, "Todo not found");

        _todos.RemoveAt(index);
        return new OperationResult(true, "Todo removed successfully");
    }

    public OperationResult SetStatus(SetStatus status)
    {
        var index = GetIndexOf(status.Id);
        if (index == -1) return new OperationResult(false, "Todo not found");
        _todos[index].IsCompleted = status.Status;
        return new OperationResult(true, "Todo status updated successfully");
    }

    public OperationResult UpdateTodo(UpdateTodoRequest request)
    {
        var index = GetIndexOf(request.Id);
        if (index == -1) return new OperationResult(false, "Todo not found");

        if (request.Title is not null) _todos[index].Title = request.Title;

        if (request.IsComplete is not null) _todos[index].IsCompleted = request.IsComplete.Value;

        if (request.Description is not null) _todos[index].Description = request.Description;

        return new OperationResult(true, "Todo updated successfully");
    }

    public OperationResult DeleteTodo()
    {
        _todos.Clear();
        return new OperationResult(true, "All todos cleared successfully");
    }

    private int GetIndexOf(Guid id)
    {
        return _todos.FindIndex(todo => todo.Id == id);
    }

    public IEnumerable<Todo> SearchTodos(string searchTerm)
    {
        return _todos.Where(todo => todo.Title.Contains(searchTerm) || todo.Description.Contains(searchTerm));
    }


    private void SeedTodos()
    {
        if (_todos.Count > 0) return;
        _todos.Add(new Todo("Erste Aufgabe", "Beschreibung der ersten"));
        _todos.Add(new Todo("Zweite Aufgabe", "Beschreibung der zweiten"));
    }
}
using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController(TodoList todoList) : ControllerBase
{
    private readonly TodoList _todoList = todoList;

    [HttpGet(Name = "GetTodos")]
    public IEnumerable<Models.Todo> Get()
    {
        return _todoList.GetTodos();
    }

    [HttpPost("search", Name = "SearchTodos")]
    public IEnumerable<Models.Todo> Post([FromBody] string search)
    {
        return _todoList.SearchTodos(search);
    }

    [HttpGet("count", Name = "GetTodosLength")]
    public int GetCount()
    {
        return _todoList.GetTodos().Count();
    }

    [HttpGet("due", Name = "GetTodosByDueDate")]
    public IEnumerable<Models.Todo> Post([FromBody] DateTime dateTime)
    {
        return _todoList.GetTodosByDueDate(dateTime);
    }

    [HttpPost(Name = "AddTodo")]
    public IActionResult Post(CreateTodoRequest todo)
    {
        _todoList.AddTodo(todo);
        return Ok(new { message = "Todo added successfully" });
    }

    [HttpDelete("delete", Name = "RemoveTodo")]
    public IActionResult Delete([FromQuery] Guid id)
    {
        var result = _todoList.RemoveTodo(id);

        return ToActionResult(result);
    }

    [HttpPatch("status", Name = "SetTodoStatus")]
    public IActionResult Post(SetStatus status)
    {
        var result = _todoList.SetStatus(status);

        return ToActionResult(result);
    }

    [HttpPost("update", Name = "UpdateTodo")]
    public IActionResult Post(UpdateTodoRequest updateTodo)
    {
        var result = _todoList.UpdateTodo(updateTodo);

        return ToActionResult(result);
    }

    [HttpPost("clear", Name = "ClearTodos")]
    public IActionResult Delete()
    {
        var result = _todoList.ClearTodo();

        return ToActionResult(result);
    }


    private IActionResult ToActionResult(OperationResult result)
    {
        if (!result.IsSuccess) return NotFound(result);
        return Ok(result);
    }
}
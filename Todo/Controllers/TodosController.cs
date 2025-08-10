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
    public IEnumerable<Services.Todo> Get()
    {
        return _todoList.GetTodos();
    }

    [HttpGet("count", Name = "GetTodosLength")]
    public int GetCount()
    {
        return _todoList.GetTodos().Count();
    }

    [HttpPost(Name = "AddTodo")]
    public IActionResult Post([FromBody] Services.Todo todo)
    {
        _todoList.AddTodo(todo);
        return Ok("Todo added successfully");
    }

    [HttpPost("remove", Name = "RemoveTodo")]
    public IActionResult Post([FromBody] Guid id)
    {
        var result = _todoList.RemoveTodo(id);

        return ToActionResult(result);
    }

    [HttpPost("status", Name = "SetTodoStatus")]
    public IActionResult Post([FromBody] SetStatus status)
    {
        var result = _todoList.SetStatus(status);

        return ToActionResult(result);
    }

    [HttpPost("update", Name = "UpdateTodoSetTodoStatus")]
    public IActionResult Post([FromBody] UpdateTodoRequest updateTodo)
    {
        var result = _todoList.UpdateTodo(updateTodo);

        return ToActionResult(result);
    }

    [HttpPost("clear", Name = "ClearTodos")]
    public IActionResult Delete()
    {
        var result = _todoList.DeleteTodo();

        return ToActionResult(result);
    }
    

    private IActionResult ToActionResult(OperationResult result)
    {
        if (!result.IsSuccess) return NotFound(result.Message);
        return Ok(result.Message);
    }
}
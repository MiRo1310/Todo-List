using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{


    [HttpGet(Name = "GetTodos")]
    public IEnumerable<string> Get()
    {
        return new string[] { "Todo 1", "Todo 2", "Todo 3" };
    }

}
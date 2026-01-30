namespace api.Controllers.Todo;

using api.Dtos.Todo;
using api.Service.Todo;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{

    private readonly ILogger<TodoController> _logger;
    private readonly ITodoService todoService;

    public TodoController(ILogger<TodoController> logger, ITodoService todoService)
    {
        _logger = logger;
        this.todoService = todoService;
    }

    [HttpPost]
    public IActionResult CreateTodo([FromBody] CreateTodoDto data)
    {

        string result = todoService.CreateTodo(data);

        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetTodos()
    {

        string result = todoService.GetTodos();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetTodoById(int id)
    {
        string result = todoService.GetTodoById(id);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTodo(int id, [FromBody] UpdateTodoDto data)
    {

        string result = todoService.UpdateTodo(id, data);

        return Ok(result);
    }

    [HttpDelete("{id}")]
        public IActionResult DeleteTodo(int id)
    {

        string result = todoService.DeleteTodo(id);

        return Ok(result);
    }
}

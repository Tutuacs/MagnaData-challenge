namespace api.Controllers.Todo;

using api.Helpers;
using api.Model.Dtos.Todo;
using api.Service.Todo;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class TodoController(ITodoService todoService) : ControllerBase
{

    private readonly ITodoService todoService = todoService;

    [HttpPost]
    public IActionResult CreateTodo([FromBody] CreateTodoDto data)
    {
        var result = todoService.CreateTodo(data);
        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }

    [HttpGet]
    public IActionResult GetTodos()
    {
        var result = todoService.GetTodos();
        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }

    [HttpGet("{id}")]
    public IActionResult GetTodoById(string id)
    {
        var result = todoService.GetTodoById(id);
        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTodo(string id, [FromBody] UpdateTodoDto data)
    {
        var result = todoService.UpdateTodo(id, data);
        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTodo(string id)
    {
        var result = todoService.DeleteTodo(id);
        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }
}

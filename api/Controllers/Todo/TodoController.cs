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
    public async Task<IActionResult> CreateTodo([FromBody] CreateTodoDto data)
    {
        var result = await todoService.CreateTodoAsync(data);
        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos()
    {
        var result = await todoService.GetTodosAsync();
        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoById(Guid id)
    {
        var result = await todoService.GetTodoByIdAsync(id);
        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(Guid id, [FromBody] UpdateTodoDto data)
    {
        var result = await todoService.UpdateTodoAsync(id, data);
        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(Guid id)
    {
        var result = await todoService.DeleteTodoAsync(id);
        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }
}

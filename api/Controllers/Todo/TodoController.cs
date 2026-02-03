namespace api.Controllers.Todo;

using System.Net;
using System.Text.Json;
using api.Data;
using api.Helpers;
using api.Model.Dtos.Todo;
using api.Model.Entities;
using api.Service.Todo;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class TodoController(ITodoService todoService, CacheContext cacheContext) : ControllerBase
{

    private readonly ITodoService todoService = todoService;
    private readonly CacheContext cacheContext = cacheContext;

    [HttpPost]
    public async Task<IActionResult> CreateTodo([FromBody] CreateTodoDto data)
    {
        var result = await todoService.CreateTodoAsync(data);

        // Apaga cache da página principal
        cacheContext.DeleteKey("todos");

        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetTodos([FromQuery] string? type, [FromQuery] string? value)
    {

        // Verifica cache da página principal
        if (type == null && value == null)
        {
            var cachedTodos = cacheContext.GetCache("todos");
            if (cachedTodos != null)
            {
                var deserializedTodos = JsonSerializer.Deserialize<List<TodoDb>>(cachedTodos);
                return StatusCode((int)HttpStatusCode.OK, new ApiResponse<object>
                {
                    Data = deserializedTodos,
                });
            }
        }

        var result = await todoService.GetTodosAsync(type, value);
        // Página principal
        if (type == null && value == null && result.Data != null)
        {
            var serializedTodos = JsonSerializer.Serialize(result.Data);
            cacheContext.NewCache("todos", serializedTodos, TimeSpan.FromHours(1));
        }

        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoById(Guid id)
    {
        var cacheKey = "todo/" + id.ToString();

        var cachedTodo = cacheContext.GetCache(cacheKey);
        if (cachedTodo != null)
        {
            var deserializedTodo = JsonSerializer.Deserialize<TodoDb>(cachedTodo);
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse<object>
            {
                Data = deserializedTodo,
            });
        }

        var result = await todoService.GetTodoByIdAsync(id);

        if (result.Data != null)
        {
            var serializedTodo = JsonSerializer.Serialize(result.Data);
            cacheContext.NewCache(cacheKey, serializedTodo, TimeSpan.FromHours(1));
        }

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

        // Apaga cache da página principal e do todo atualizado
        cacheContext.DeleteKey("todos");
        cacheContext.DeleteKey("todo/" + id.ToString());

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

        // Apaga cache da página principal e do item deletado
        cacheContext.DeleteKey("todos");
        cacheContext.DeleteKey("todo/" + id.ToString());

        return StatusCode((int)result.StatusCode, new ApiResponse<object>
        {
            Data = result.Data,
            Message = result.Message
        });
    }
}

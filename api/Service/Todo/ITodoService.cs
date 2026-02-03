namespace api.Service.Todo;

using api.Helpers;
using api.Model.Dtos.Todo;
using api.Model.Entities;

public interface ITodoService
{
    Task<ServiceResponse<string>> CreateTodoAsync(CreateTodoDto data);
    Task<ServiceResponse<List<TodoDb>>> GetTodosAsync(string? type, string? value);
    Task<ServiceResponse<TodoDb?>> GetTodoByIdAsync(Guid id);
    Task<ServiceResponse<string>> UpdateTodoAsync(Guid id, UpdateTodoDto data);
    Task<ServiceResponse<string>> DeleteTodoAsync(Guid id);
}
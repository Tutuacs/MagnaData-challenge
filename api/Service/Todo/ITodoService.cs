namespace api.Service.Todo;

using api.Helpers;
using api.Model.Dtos.Todo;
using api.Model.Entities;

public interface ITodoService
{
    ServiceResponse<string> CreateTodo(CreateTodoDto data);
    ServiceResponse<List<TodoDb>> GetTodos();
    ServiceResponse<TodoDb?> GetTodoById(string id);
    ServiceResponse<string> UpdateTodo(string id, UpdateTodoDto data);
    ServiceResponse<string> DeleteTodo(string id);
}
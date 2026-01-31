namespace api.Service.Todo;

using api.Data.Repository.Todo;
using api.Helpers;
using api.Model.Dtos.Todo;
using api.Model.Entities;

public partial class TodoService(ITodoRepository todoRepository, ILogger<TodoService> logger) : ITodoService
{

    private readonly ITodoRepository _todoRepository = todoRepository;
    private readonly ApiLogger<TodoService> _logger = new (logger);

    public ServiceResponse<string> CreateTodo(CreateTodoDto data)
    {
        var result = _todoRepository.Create(data);

        if (result == 0)
        {
            _logger.Log(LogLevel.Error,"No records created when trying to create todo");
            _logger.Log(LogLevel.Information,"Dto: {@Data}", data);
            return new ServiceResponse<string>
            { 
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Message = "Failed to create todo"
            };
        }

        if (result > 1)
        {
            _logger.Log(LogLevel.Error,"More than one record created when trying to create todo: {result}", result);
            _logger.Log(LogLevel.Information,"Dto: {@Data}", data);
            return new ServiceResponse<string>
            { 
                StatusCode = System.Net.HttpStatusCode.Created 
            };
        }
        return new ServiceResponse<string> { StatusCode = System.Net.HttpStatusCode.Created  };
    }

    public ServiceResponse<List<TodoDb>> GetTodos()
    {
        var result = _todoRepository.GetAll();
        return new ServiceResponse<List<TodoDb>> { Data = result };
    }

    public ServiceResponse<TodoDb?> GetTodoById(string id)
    {
        return new ServiceResponse<TodoDb?> { Data = null };
    }

    public ServiceResponse<string> UpdateTodo(string id, UpdateTodoDto data)
    {
        return new ServiceResponse<string> { Data = $"UpdateTodo: {id} - {data}" };
    }

    public ServiceResponse<string> DeleteTodo(string id)
    {
        return new ServiceResponse<string> { Data = $"DeleteTodo: {id}" };
    }

}
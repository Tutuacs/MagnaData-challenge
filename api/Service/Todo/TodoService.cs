namespace api.Service.Todo;

using api.Data.Repository.Todo;
using api.Helpers;
using api.Model.Dtos.Todo;
using api.Model.Entities;

public partial class TodoService(ITodoRepository todoRepository, ILogger<TodoService> logger) : ITodoService
{

    private readonly ITodoRepository _todoRepository = todoRepository;
    private readonly ApiLogger<TodoService> _logger = new (logger);

    public async Task<ServiceResponse<string>> CreateTodoAsync(CreateTodoDto data)
    {
        var result = await _todoRepository.CreateAsync(data);

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

    public async Task<ServiceResponse<List<TodoDb>>> GetTodosAsync(string? type, string? value)
    {
        var result = await _todoRepository.GetAllAsync(type, value);
        return new ServiceResponse<List<TodoDb>> { Data = result };
    }

    public async Task<ServiceResponse<TodoDb?>> GetTodoByIdAsync(Guid id)
    {
        var result = await _todoRepository.GetByIdAsync(id);
        if (result == null)
        {
            return new ServiceResponse<TodoDb?> { StatusCode = System.Net.HttpStatusCode.OK, Message= "Not found" };
        }
        return new ServiceResponse<TodoDb?> { Data = result };
    }

    public async Task<ServiceResponse<string>> UpdateTodoAsync(Guid id, UpdateTodoDto data)
    {
        var result = await _todoRepository.UpdateAsync(id, data);

        switch (result)
        {
            // * Not found
            case < 0:
                return new ServiceResponse<string>
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Todo not found"
                };
            // ! Not updated
            case 0:
                _logger.Log(LogLevel.Error, "Todo could not be updated with id: {id}", id);
                return new ServiceResponse<string>
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = "Todo not updated"
                };
            // ! Updated More than one record
            case > 1:
                _logger.Log(LogLevel.Error, "More than one record updated when trying to update todo with id: {Id}", id);
                return new ServiceResponse<string>
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = "Multiple todos updated"
                };
            // * Updated one record
            default:
                return new ServiceResponse<string> { StatusCode = System.Net.HttpStatusCode.OK };
        }
    }

    public async Task<ServiceResponse<string>> DeleteTodoAsync(Guid id)
    {
        var result = await _todoRepository.DeleteAsync(id);

        switch (result)
        {
            // * Not found
            case < 0:
                return new ServiceResponse<string>
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Todo not found"
                };
            // ! Not deleted
            case 0:
                _logger.Log(LogLevel.Error, "Todo could not be deleted with id: {id}", id);
                return new ServiceResponse<string>
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Message = "Todo not deleted"
                };
            // ! Deleted More than one record
            case > 1:
                _logger.Log(LogLevel.Error, "More than one record deleted when trying to delete todo with id: {Id}", id);
                return new ServiceResponse<string>
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Message = "Multiple todos deleted"
                };
            // * Deleted one record
            default:
                return new ServiceResponse<string> { StatusCode = System.Net.HttpStatusCode.OK };
        }
    }

}
using api.Model.Dtos.Todo;
using api.Model.Entities;

namespace api.Data.Repository.Todo;

public interface ITodoRepository
{
    int Create(CreateTodoDto todo);
    List<TodoDb> GetAll();
    TodoDb? GetById(string id);
    int Update(string id, UpdateTodoDto todo);
    int Delete(string id);
}
using System.Data.Common;
using api.Model.Dtos.Todo;
using api.Model.Entities;
using Microsoft.AspNetCore.Connections;

namespace api.Data.Repository.Todo;

public class TodoRepository(ApplicationDbContext db) : ITodoRepository
{
    private readonly ApplicationDbContext _db = db;

    public int Create(CreateTodoDto todo)
    {
        _db.Todo.Add(new TodoDb(todo.Description));
        var affectedRows = _db.SaveChanges();
        return affectedRows;
    }
    public List<TodoDb> GetAll()
    {
        return [.. _db.Todo];
    }
    public TodoDb? GetById(string id)
    {
        return _db.Todo.Find(id);
    }
    public int Update(string id, UpdateTodoDto todo)
    {
        var UpdatedRows = 0;
        var exists = _db.Todo.Find(id);
        if (exists != null)
        {
            exists.Description = todo.Description;
            if (todo.Completed.HasValue)
            {
                exists.Completed = todo.Completed.Value 
                    ? DateOnly.FromDateTime(DateTime.Now) 
                    : null;
            }
            UpdatedRows = _db.SaveChanges();
        }
        return UpdatedRows;
    }
    public int Delete(string id)
    {
        var DeletedRows = 0;
        var todo = _db.Todo.Find(id);
        if (todo != null)
        {
            _db.Todo.Remove(todo);
            DeletedRows = _db.SaveChanges();
        }

        return DeletedRows;
    }
}
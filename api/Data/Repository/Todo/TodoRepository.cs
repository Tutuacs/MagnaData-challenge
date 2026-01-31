using api.Model.Dtos.Todo;
using api.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Repository.Todo;

public class TodoRepository(ApplicationDbContext db) : ITodoRepository
{
    private readonly ApplicationDbContext _db = db;

    public async Task<int> CreateAsync(CreateTodoDto todo)
    {
        _db.Todo.Add(new TodoDb(todo.Description));
        var affectedRows = await _db.SaveChangesAsync();
        return affectedRows;
    }
    
    public async Task<List<TodoDb>> GetAllAsync()
    {
        return await _db.Todo.ToListAsync();
    }
    
    public async Task<TodoDb?> GetByIdAsync(Guid id)
    {
        return await _db.Todo.FindAsync(Convert.ToString(id));
    }
    
    public async Task<int> UpdateAsync(Guid id, UpdateTodoDto todo)
    {
        var UpdatedRows = -1;
        var exists = await _db.Todo.FindAsync(Convert.ToString(id));
        if (exists != null)
        {
            exists.Description = !string.IsNullOrEmpty(todo.Description) ? todo.Description : exists.Description;
            if (todo.Completed.HasValue)
            {
                exists.Completed = todo.Completed.Value 
                    ? DateOnly.FromDateTime(DateTime.Now) 
                    : null;
            }
            UpdatedRows = await _db.SaveChangesAsync();
        }
        return UpdatedRows;
    }
    
    public async Task<int> DeleteAsync(Guid id)
    {
        var DeletedRows = -1;
        var todo = await _db.Todo.FindAsync(Convert.ToString(id));
        if (todo != null)
        {
            _db.Todo.Remove(todo);
            DeletedRows = await _db.SaveChangesAsync();
        }

        return DeletedRows;
    }
}
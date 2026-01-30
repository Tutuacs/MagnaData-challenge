namespace api.Service.Todo;

using api.Dtos.Todo;

public interface ITodoService
{
    String GetTodos();
    String GetTodoById(int id);
    String CreateTodo(CreateTodoDto data);
    String UpdateTodo(int id, UpdateTodoDto data);
    String DeleteTodo(int id);
}
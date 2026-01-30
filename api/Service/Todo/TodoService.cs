namespace api.Service.Todo;

using api.Dtos.Todo;

public class TodoService : ITodoService
{

    public String CreateTodo(CreateTodoDto data)
    {
        return $"CreateTodo: {data}";
    }
    public String GetTodos()
    {
        return "GetTodos";
    }

    public String GetTodoById(int id)
    {
        return $"GetTodoById: {id}";
    }

    public String UpdateTodo(int id, UpdateTodoDto data)
    {
        return $"UpdateTodo: {id} - {data}";
    }

    public String DeleteTodo(int id)
    {
        return $"DeleteTodo: {id}";
    }


}
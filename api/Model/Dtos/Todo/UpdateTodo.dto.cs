namespace api.Model.Dtos.Todo;

using System.ComponentModel.DataAnnotations;

public class UpdateTodoDto
{

    [StringLength(int.MaxValue, MinimumLength = 10)]
    public string? Description { get; set; }
    public bool? Completed { get; set; }
}

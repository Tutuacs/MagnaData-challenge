namespace api.Model.Dtos.Todo;

using System.ComponentModel.DataAnnotations;

public class UpdateTodoDto
{

    [StringLength(int.MaxValue, MinimumLength = 10)]
    public string? Description { get; set; }
    public Boolean? Completed { get; set; }
}

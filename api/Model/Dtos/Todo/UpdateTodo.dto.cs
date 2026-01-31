namespace api.Model.Dtos.Todo;

using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

public class UpdateTodoDto
{
    [Required]
    [StringLength(int.MaxValue, MinimumLength = 10)]
    public required string Description { get; set; }
    public Boolean? Completed { get; set; }
}

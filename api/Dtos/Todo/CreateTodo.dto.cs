namespace api.Dtos.Todo;

using System.ComponentModel.DataAnnotations;

public class CreateTodoDto
{
    [Required]
    [StringLength(int.MaxValue, MinimumLength = 10)]
    public required string Description { get; set; }

    [DataType(DataType.Date)]
    public DateOnly CreatedAt { get; } = DateOnly.FromDateTime(DateTime.Now);

}

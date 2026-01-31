using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Model.Entities;

[Table("todo")]
public class TodoDb(string description)
{
    [Key]
    public string Id { get; private set; } = Guid.NewGuid().ToString();
    public string Description { get; set; } = description;
    public DateOnly CreatedAt { get; private set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly? Completed {get; set;}
}
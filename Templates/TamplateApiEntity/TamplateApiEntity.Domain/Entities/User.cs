namespace TamplateApiEntity.Domain.Entities;

public class User : DefaultEntity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}

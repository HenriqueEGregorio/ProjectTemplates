namespace TemplateDapper.Api.Domain.Entities;

public class UserEntity : DefaultEntity
{
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
}

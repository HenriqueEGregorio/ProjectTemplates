using TemplateDapper.Api.Domain.Interfaces.Data;

namespace TemplateDapper.Api.Infrastucture.Data;

public class Settings : ISettings
{
    public required string Default { get; set; }
}

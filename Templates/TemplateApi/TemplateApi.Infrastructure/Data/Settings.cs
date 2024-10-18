using TemplateApi.Domain.Interfaces.Data;

namespace TemplateApi.Infrastructure.Data;

public class Settings : ISettings
{
    public required string Default { get; set; }
}

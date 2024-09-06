using TemplateEntity.Api.Domain.Interfaces.Data;

namespace TemplateEntity.Api.Infrastructure.Data;

public class Settings : ISettings
{
    public required string Default { get; set; }
}

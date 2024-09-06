using TemplateEntity.Api.Domain.Interfaces.Entities;

namespace TemplateEntity.Api.Domain.Entities;

public class DefaultEntity : IDefaultEntity
{
    public Guid Id { get; set; }
    public long Sequence { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreationAt { get; set; }
}

using TemplateDapper.Api.Domain.Interfaces.Entities;

namespace TemplateDapper.Api.Domain.Entities;

public class DefaultEntity : IDefaultEntity
{
    public Guid Id { get; set; }
    public long Sequence { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime CreationDate { get; set; }
}

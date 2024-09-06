namespace TemplateEntity.Api.Domain.Interfaces.Entities;

public interface IDefaultEntity
{
    Guid Id { get; set; }
    long Sequence { get; set; }
    DateTime UpdateAt { get; set; }
    DateTime CreationAt { get; set; }
}

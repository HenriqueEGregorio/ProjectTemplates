namespace TemplateDapper.Api.Domain.Interfaces.Entities;

public interface IDefaultEntity
{
    Guid Id { get; set; }
    long Sequence { get; set; }
    DateTime UpdateDate { get; set; }
    DateTime CreationDate { get; set; }
}

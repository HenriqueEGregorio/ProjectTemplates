using TamplateApiEntity.Domain.Intefaces;

namespace TamplateApiEntity.Domain.Entities;

public class DefaultEntity : IDefaultEntity
{
    public Guid Id { get; set; }
    public int Sequence { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
}

namespace TamplateApiEntity.Domain.Intefaces;

public interface IDefaultEntity
{
    Guid Id { get; set; }
    int Sequence { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime UpdateAt { get; set; }
}

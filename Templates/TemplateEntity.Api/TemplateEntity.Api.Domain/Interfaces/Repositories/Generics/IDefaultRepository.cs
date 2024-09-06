using TemplateEntity.Api.Domain.Interfaces.Entities;

namespace TemplateEntity.Api.Domain.Interfaces.Repositories.Generics;

public interface IDefaultRepository<T> : ICrudGenericRepository<T> where T : class, IDefaultEntity
{
}

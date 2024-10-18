namespace TemplateApi.Domain.Interfaces.Repository.Generics;

public interface IDefaultRepository<T> : IGenericRepository<T> where T : class, IDefaultEntity
{
}

namespace TemplateApi.Domain.Interfaces.Repository.Generics
{
    public interface IEntityDefaultRepository<T> : IEntityGenericRepository<T> where T : class, IDefaultEntity
    {
    }
}

using System.Linq.Expressions;
using TemplateApi.Domain.Interfaces.Filters;
using TemplateApi.Domain.Pagination;

namespace TemplateApi.Domain.Interfaces.Repository.Generics
{
    public interface IEntityGenericRepository<T> : IDisposable where T : class , IDefaultEntity 
    {
        Task<T?> GetById(Guid id);
        Task<IEnumerable<T>> GetAsync();
        Task<IPagination<T>> GetPaginatedAsync(IDefaultFilter filter);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(Guid id, T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task RemoveAsync(Guid id);
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}

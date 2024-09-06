using TemplateEntity.Api.Domain.Filters;
using TemplateEntity.Api.Domain.Interfaces.Entities;
using TemplateEntity.Api.Domain.Pagination;

namespace TemplateEntity.Api.Domain.Interfaces.Repositories.Generics;

public interface ICrudGenericRepository<T> : IDisposable where T : class, IDefaultEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAsync();
    Task<IPagination<T>> GetPaginatedAsync(IDefaultFilter filter);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(Guid id, T entity);
    Task UpdateRangeAsync(IEnumerable<T> entities);
    Task RemoveAsync(Guid id);
    Task RemoveRangeAsync(IEnumerable<T> entities);
}

using TemplateDapper.Api.Domain.Filters;
using TemplateDapper.Api.Domain.Interfaces.Entities;
using TemplateDapper.Api.Domain.Pagination;

namespace TemplateDapper.Api.Domain.Interfaces.Repositories.Generics;

public interface IGenericRepository<T> : IDisposable where T : class, IDefaultEntity
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

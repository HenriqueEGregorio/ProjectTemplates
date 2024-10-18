using TemplateApi.Domain.Entities;
using TemplateApi.Domain.Filters;
using TemplateApi.Domain.Pagination;

namespace TemplateApi.Domain.Interfaces.Services;

public interface IExampleEntityService
{
    Task<ExampleEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<ExampleEntity>> GetAsync();
    Task<IPagination<ExampleEntity>> GetPaginatedAsync(ExampleEntityFilter filter);
    Task<ExampleEntity> CreateAsync(ExampleEntity entity);
    Task UpdateAsync(Guid id, ExampleEntity entity);
    Task UpdateRangeAsync(IEnumerable<ExampleEntity> entities);
    Task DeleteAsync(Guid id);
    Task DeleteRangeAsync(IEnumerable<ExampleEntity> entities);
}

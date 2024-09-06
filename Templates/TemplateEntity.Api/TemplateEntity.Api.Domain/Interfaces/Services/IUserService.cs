using TemplateEntity.Api.Domain.Entities;
using TemplateEntity.Api.Domain.Filters;
using TemplateEntity.Api.Domain.Pagination;

namespace TemplateEntity.Api.Service.Services
{
    public interface IUserService
    {
        Task<Domain.Entities.UserEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<Domain.Entities.UserEntity>> GetAsync();
        Task<IPagination<Domain.Entities.UserEntity>> GetPaginatedAsync(UserFilter filter);
        Task<Domain.Entities.UserEntity> CreateAsync(Domain.Entities.UserEntity entity);
        Task UpdateAsync(Guid id, Domain.Entities.UserEntity entity);
        Task UpdateRangeAsync(IEnumerable<Domain.Entities.UserEntity> entities);
        Task DeleteAsync(Guid id);
        Task DeleteRangeAsync(IEnumerable<Domain.Entities.UserEntity> entities);
    }
}
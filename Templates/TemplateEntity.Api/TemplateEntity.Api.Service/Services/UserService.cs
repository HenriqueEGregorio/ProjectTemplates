using TemplateEntity.Api.Domain.Filters;
using TemplateEntity.Api.Domain.Interfaces.Repositories;
using TemplateEntity.Api.Domain.Pagination;

namespace TemplateEntity.Api.Service.Services;

public class UserService : IUserService
{
    private readonly IUserEntityRepository _userEntityRepository;

    public UserService(
        IUserEntityRepository userEntityRepository)
    {
        _userEntityRepository = userEntityRepository;
    }

    public async Task<Domain.Entities.UserEntity?> GetByIdAsync(Guid id)
    {
        var result = await _userEntityRepository.GetByIdAsync(id);
        return result;
    }

    public async Task<IEnumerable<Domain.Entities.UserEntity>> GetAsync()
    {
        var result = await _userEntityRepository.GetAsync();
        return result;
    }

    public async Task<IPagination<Domain.Entities.UserEntity>> GetPaginatedAsync(UserFilter filter)
    {
        var result = await _userEntityRepository.GetPaginatedAsync(filter);
        return result;
    }

    public async Task<Domain.Entities.UserEntity> CreateAsync(Domain.Entities.UserEntity entity)
    {
        return await _userEntityRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(Guid id, Domain.Entities.UserEntity entity)
    {
        await _userEntityRepository.UpdateAsync(id, entity);
    }

    public async Task UpdateRangeAsync(IEnumerable<Domain.Entities.UserEntity> entities)
    {
        await _userEntityRepository.UpdateRangeAsync(entities);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _userEntityRepository.RemoveAsync(id);
    }

    public async Task DeleteRangeAsync(IEnumerable<Domain.Entities.UserEntity> entities)
    {
        await _userEntityRepository.RemoveRangeAsync(entities);
    }
}

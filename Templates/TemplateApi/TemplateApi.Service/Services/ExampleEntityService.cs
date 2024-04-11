using TemplateApi.Domain.Entities;
using TemplateApi.Domain.Filters;
using TemplateApi.Domain.Interfaces.Repository.Repositories;
using TemplateApi.Domain.Interfaces.Services;
using TemplateApi.Domain.Pagination;

namespace TemplateApi.Service.Services
{
    public class ExampleEntityService : IExampleEntityService
    {
        private readonly IExampleEntityRepository _exampleEntityRepository;
        public ExampleEntityService(
            IExampleEntityRepository exampleEntityRepository)
        {
            _exampleEntityRepository = exampleEntityRepository;
        }

        public async Task<ExampleEntity?> GetByIdAsync(Guid id)
        {
            var result = await _exampleEntityRepository.GetById(id);
            return result;
        }

        public async Task<IEnumerable<ExampleEntity>> GetAsync()
        {
            var result = await _exampleEntityRepository.GetAsync();
            return result;
        }

        public async Task<IPagination<ExampleEntity>> GetPaginatedAsync(ExampleEntityFilter filter)
        {
            var result = await _exampleEntityRepository.GetPaginatedAsync(filter);
            return result;
        }

        public async Task<ExampleEntity> CreateAsync(ExampleEntity entity)
        {
            return await _exampleEntityRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(Guid id ,ExampleEntity entity)
        {
            await _exampleEntityRepository.UpdateAsync(id, entity);
        }

        public async Task UpdateRangeAsync(IEnumerable<ExampleEntity> entities)
        {
            await _exampleEntityRepository.UpdateRangeAsync(entities);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _exampleEntityRepository.RemoveAsync(id);
        }

        public async Task DeleteRangeAsync(IEnumerable<ExampleEntity> entities)
        {
            await _exampleEntityRepository.RemoveRangeAsync(entities);
        }
    }
}

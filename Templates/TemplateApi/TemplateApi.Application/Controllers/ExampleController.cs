using Mapster;
using Microsoft.AspNetCore.Mvc;
using TemplateApi.Domain.Entities;
using TemplateApi.Domain.Filters;
using TemplateApi.Domain.Interfaces.Services;
using TemplateApi.Domain.Pagination;
using TemplateApi.WebApplication.Models.Delete;
using TemplateApi.WebApplication.Models.Get;
using TemplateApi.WebApplication.Models.Post.Request;
using TemplateApi.WebApplication.Models.Post.Response;
using TemplateApi.WebApplication.Models.Put.Request;

namespace TemplateApi.WebApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExampleController : Controller
    {
        private readonly IExampleEntityService _exampleEntityService;
        public ExampleController(
            IExampleEntityService exampleEntityService)
        {
            _exampleEntityService = exampleEntityService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<GetExampleEntityResponseModel?> GetByIdAsync(Guid id)
        {
            var result = await _exampleEntityService.GetByIdAsync(id);
            return result.Adapt<GetExampleEntityResponseModel>();
        }

        [HttpGet]
        public async Task<IEnumerable<GetExampleEntityResponseModel>> GetAsync()
        {
            var result = await _exampleEntityService.GetAsync();
            return result.Adapt<IEnumerable<GetExampleEntityResponseModel>>();
        }

        [HttpGet]
        [Route("Paginated")]
        public async Task<IPagination<GetExampleEntityResponseModel>> GetPaginatedAsync([FromQuery]ExampleEntityFilter filter)
        {
            var result = await _exampleEntityService.GetPaginatedAsync(filter);
            return result.Adapt<IPagination<GetExampleEntityResponseModel>>();
        }

        [HttpPost]
        public async Task<PostExampleEntityResponseModel> PostAsync([FromBody] PostExampleEntityRequestModel model)
        {
            var entity = model.Adapt<ExampleEntity>();
            var result = await _exampleEntityService.CreateAsync(entity);
            return result.Adapt<PostExampleEntityResponseModel>();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task PutAsync(Guid id ,[FromBody] PutExampleEntityRequestModel model)
        {
            var entity = model.Adapt<ExampleEntity>();
            await _exampleEntityService.UpdateAsync(id ,entity);
        }

        [HttpPut]
        public async Task PutAsync([FromBody] IEnumerable<PutRangeExampleEntityRequestModel> models)
        {
            var entities = models.Adapt<IEnumerable<ExampleEntity>>();
            await _exampleEntityService.UpdateRangeAsync(entities);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _exampleEntityService.DeleteAsync(id);
        }

        [HttpDelete]
        public async Task DeleteAsync([FromBody] IEnumerable<DeleteExapleEntityRequestModel> models)
        {
            var entities = models.Adapt<IEnumerable<ExampleEntity>>();
            await _exampleEntityService.DeleteRangeAsync(entities);
        }
    }
}

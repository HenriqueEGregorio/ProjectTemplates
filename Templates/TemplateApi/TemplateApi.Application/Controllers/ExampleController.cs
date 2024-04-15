using Mapster;
using Microsoft.AspNetCore.Mvc;
using TemplateApi.Domain.Entities;
using TemplateApi.Domain.Filters;
using TemplateApi.Domain.Interfaces.Services;
using TemplateApi.Domain.Pagination;
using TemplateApi.Service.Models.Delete;
using TemplateApi.Service.Models.Get;
using TemplateApi.Service.Models.Post.Request;
using TemplateApi.Service.Models.Post.Response;
using TemplateApi.Service.Models.Put.Request;

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

        /// <summary>
        /// Busca uma entidade especificando um Id
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>
        /// Retorna uma entidade especifica
        /// </returns>
        /// <response code="200"> Sucesso </response>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<GetExampleEntityResponseModel?> GetByIdAsync(Guid id)
        {
            var result = await _exampleEntityService.GetByIdAsync(id);
            return result.Adapt<GetExampleEntityResponseModel>();
        }

        /// <summary>
        /// Busca uma lista com todas as entidades
        /// </summary>
        /// <returns>
        /// retorna uma lista de entidades
        /// </returns>
        /// <response code="200"> Sucesso </response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<GetExampleEntityResponseModel>> GetAsync()
        {
            var result = await _exampleEntityService.GetAsync();
            return result.Adapt<IEnumerable<GetExampleEntityResponseModel>>();
        }

        /// <summary>
        /// Busca uma lista com todas as entidades com paginação
        /// </summary>
        /// <param name="filter">Controle de paginação</param>
        /// <returns>
        /// retorna uma lista de entidades
        /// </returns>
        /// <response code="200"> Sucesso </response>
        [HttpGet]
        [Route("Paginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IPagination<GetExampleEntityResponseModel>> GetPaginatedAsync([FromQuery]ExampleEntityFilter filter)
        {
            var result = await _exampleEntityService.GetPaginatedAsync(filter);
            return result.Adapt<IPagination<GetExampleEntityResponseModel>>();
        }

        /// <summary>
        /// Cria uma entidade
        /// </summary>
        /// <remarks>
        /// {objeto Json}
        /// </remarks>
        /// <param name="model">Entidade para inserção</param>
        /// <returns>
        /// Id da entidade criada
        /// </returns>
        /// <response code="201"> Criado</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<PostExampleEntityResponseModel> PostAsync([FromBody] PostExampleEntityRequestModel model)
        {
            var entity = model.Adapt<ExampleEntity>();
            var result = await _exampleEntityService.CreateAsync(entity);
            return result.Adapt<PostExampleEntityResponseModel>();
        }

        /// <summary>
        /// Atualiza uma entidade especifica por Id
        /// </summary>
        /// <remarks>
        /// {objeto Json}
        /// </remarks>
        /// <param name="id">Identificador da entidade</param>
        /// <param name="model">Entidade para atualização</param>
        /// <returns>
        /// Não se aplica
        /// </returns>
        /// <response code="204"> Sucesso </response>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task PutAsync(Guid id ,[FromBody] PutExampleEntityRequestModel model)
        {
            throw new Exception();
            var entity = model.Adapt<ExampleEntity>();
            await _exampleEntityService.UpdateAsync(id ,entity);
        }

        /// <summary>
        /// Atualiza uma lista de entidades
        /// </summary>
        /// <remarks>
        /// {objeto Json}
        /// </remarks>
        /// <param name="models">Lista de entidade para atualização</param>
        /// <returns>
        /// Não se aplica
        /// </returns>
        /// <response code="204"> Sucesso </response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task PutAsync([FromBody] IEnumerable<PutRangeExampleEntityRequestModel> models)
        {
            var entities = models.Adapt<IEnumerable<ExampleEntity>>();
            await _exampleEntityService.UpdateRangeAsync(entities);
        }

        /// <summary>
        /// Deleta entidade especifica por Id
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>
        /// Não se aplica
        /// </returns>
        /// <response code="204"> Sucesso </response>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task DeleteAsync(Guid id)
        {
            await _exampleEntityService.DeleteAsync(id);
        }

        /// <summary>
        /// Deleta uma lista de entidades
        /// </summary>
        /// <remarks>
        /// {objeto Json}
        /// </remarks>
        /// <param name="models">Lista de entidade para deleção</param>
        /// <returns>
        /// Não se aplica
        /// </returns>
        /// <response code="204"> Sucesso </response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task DeleteAsync([FromBody] IEnumerable<DeleteExapleEntityRequestModel> models)
        {
            var entities = models.Adapt<IEnumerable<ExampleEntity>>();
            await _exampleEntityService.DeleteRangeAsync(entities);
        }
    }
}

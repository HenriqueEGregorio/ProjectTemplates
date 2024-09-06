using Mapster;
using Microsoft.AspNetCore.Mvc;
using TemplateEntity.Api.Domain.Entities;
using TemplateEntity.Api.Domain.Filters;
using TemplateEntity.Api.Domain.Pagination;
using TemplateEntity.Api.Service.Services;

namespace TemplateEntity.Api.Application.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(
        IUserService userService)
    {
        _userService = userService;
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
    public async Task<UserEntity?> GetByIdAsync(Guid id)
    {
        var result = await _userService.GetByIdAsync(id);
        return result.Adapt<UserEntity>();
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
    public async Task<IEnumerable<UserEntity>> GetAsync()
    {
        var result = await _userService.GetAsync();
        return result.Adapt<IEnumerable<UserEntity>>();
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
    public async Task<IPagination<UserEntity>> GetPaginatedAsync([FromQuery] UserFilter filter)
    {
        var result = await _userService.GetPaginatedAsync(filter);
        return result.Adapt<IPagination<UserEntity>>();
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
    public async Task<Domain.Entities.UserEntity> PostAsync([FromBody] Domain.Entities.UserEntity model)
    {
        var entity = model.Adapt<UserEntity>();
        var result = await _userService.CreateAsync(entity);
        return result.Adapt<Domain.Entities.UserEntity>();
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
    public async Task PutAsync(Guid id, [FromBody] UserEntity model)
    {
        var entity = model.Adapt<UserEntity>();
        await _userService.UpdateAsync(id, entity);
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
    public async Task PutAsync([FromBody] IEnumerable<UserEntity> models)
    {
        var entities = models.Adapt<IEnumerable<UserEntity>>();
        await _userService.UpdateRangeAsync(entities);
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
        await _userService.DeleteAsync(id);
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
    public async Task DeleteAsync([FromBody] IEnumerable<UserEntity> models)
    {
        var entities = models.Adapt<IEnumerable<UserEntity>>();
        await _userService.DeleteRangeAsync(entities);
    }
}

using System.Data;
using TemplateDapper.Api.Domain.Filters;
using TemplateDapper.Api.Domain.Interfaces;
using TemplateDapper.Api.Domain.Interfaces.Entities;
using TemplateDapper.Api.Domain.Interfaces.Repositories.Generics;
using TemplateDapper.Api.Domain.Pagination;
using static Dapper.SqlMapper;

namespace TemplateDapper.Api.Infrastucture.Repositories.Generics;

public abstract class CrudGenericRepository<T> : IGenericRepository<T> where T : class, IDefaultEntity
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IDbConnection _dbConn;

    protected abstract string InsertQuery { get; }
    protected abstract string InsertQueryReturnInserted { get; }
    protected abstract string UpdateByIdQuery { get; }
    protected abstract string DeleteByIdQuery { get; }
    protected abstract string SelectByIdQuery { get; }
    protected abstract string SelectAllQuery { get; }

    protected CrudGenericRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _dbConn = unitOfWork.GetDbConnection;
    }

    public virtual string GetQueryBase(IDefaultFilter filter)
    {
        return string.Empty;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        var entity = await _dbConn.QueryAsync<T>(SelectByIdQuery
            , new { Id = id }
            , transaction: _unitOfWork.GetDbTransaction);

        return entity.FirstOrDefault();
    }

    public async Task<IEnumerable<T>> GetAsync()
    {
        return await _dbConn.QueryAsync<T>(SelectAllQuery
            , transaction: _unitOfWork.GetDbTransaction);
    }

    public async Task<IPagination<T>> GetPaginatedAsync(IDefaultFilter filter)
    {
        var queryBase = GetQueryBase(filter);
        var queryCount = GetQueryCount(filter);

        SetPagination(ref queryBase, ref filter);
        return await ExecutePaginationQueries(queryBase, queryCount, filter);
    }

    public async Task<T> AddAsync(T entity)
    {
        entity.CreationDate = DateTime.Now;
        T result = await _dbConn.QuerySingleAsync<T>(InsertQueryReturnInserted
            , entity
            , transaction: _unitOfWork.GetDbTransaction);

        return result;
    }

    public async Task<int> AddRangeAsync(IEnumerable<T> entities)
    {
        return await _dbConn.ExecuteAsync(InsertQuery
            , entities
            , transaction: _unitOfWork.GetDbTransaction);
    }

    public async Task UpdateAsync(Guid id, T entity)
    {
        entity.UpdateDate = DateTime.Now;
        await _dbConn.ExecuteAsync(UpdateByIdQuery, entity, transaction: _unitOfWork.GetDbTransaction);
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        await _dbConn.ExecuteAsync(UpdateByIdQuery, entities.Select(obj => obj), transaction: _unitOfWork.GetDbTransaction);
    }

    public async Task RemoveAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
            return;

        await RemoveAsync(entity);
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        await _dbConn.ExecuteAsync(DeleteByIdQuery
           , entities.Select(obj => new { obj.Id })
           , transaction: _unitOfWork.GetDbTransaction);
    }

    protected async Task<IPagination<T>> ExecutePaginationQueries(string queryBase, string queryCount, IDefaultFilter parameters)
    {
        var result = _dbConn.QueryAsync<T>(queryBase, parameters);
        var count = _dbConn.ExecuteScalarAsync<int>(queryCount, parameters);

        await Task.WhenAll(result, count);
        return new Pagination<T>(result.Result.ToList(), count.Result);
    }

    private string GetQueryCount(IDefaultFilter filter)
    {
        var queryBase = GetQueryBase(filter);

        return @$"select count(1) from ({queryBase})";
    }

    private static void SetPagination(ref string query, ref IDefaultFilter parameters)
    {
        var limit = parameters.PageIndex * parameters.PageSize;
        var offset = parameters.PageIndex * parameters.PageSize - (parameters.PageSize - 1);

        query = @$"SELECT * 
                          FROM (SELECT result.*, rownum rn
                                  FROM ( {query} ) result
                                 WHERE rownum <= {limit})
                         WHERE rn >= {offset}";
    }

    private async Task<int> RemoveAsync(T entity)
    {
        return await _dbConn.ExecuteAsync(DeleteByIdQuery
            , new { entity.Id }
            , transaction: _unitOfWork.GetDbTransaction);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbConn?.Close();
            _dbConn?.Dispose();
        }
    }
}

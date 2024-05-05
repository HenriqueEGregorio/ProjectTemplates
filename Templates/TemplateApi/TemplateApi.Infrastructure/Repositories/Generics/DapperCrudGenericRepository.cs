using Dapper;
using System.Data;
using TemplateApi.Domain.Interfaces;
using TemplateApi.Domain.Interfaces.Filters;
using TemplateApi.Domain.Interfaces.Repository.Generics;
using TemplateApi.Domain.Pagination;
using static Dapper.SqlMapper;

namespace TemplateApi.Infrastructure.Repositories.Generics
{
    public abstract class DapperCrudGenericRepository<T> : IGenericRepository<T> where T : class, IDefaultEntity
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IDbConnection dbConn;

        protected abstract string InsertQuery { get; }
        protected abstract string InsertQueryReturnInserted { get; }
        protected abstract string UpdateByIdQuery { get; }
        protected abstract string DeleteByIdQuery { get; }
        protected abstract string SelectByIdQuery { get; }
        protected abstract string SelectAllQuery { get; }

        protected DapperCrudGenericRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            dbConn = unitOfWork.GetDbConnection;
        }

        public virtual string GetQueryBase(IDefaultFilter filter)
        {
            return string.Empty;
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var entity = await dbConn.QueryAsync<T>(SelectByIdQuery
                , new { Id = id }
                , transaction: unitOfWork.GetDbTransaction);

            return entity.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await dbConn.QueryAsync<T>(SelectAllQuery
                , transaction: unitOfWork.GetDbTransaction);
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
            T result = await dbConn.QuerySingleAsync<T>(InsertQueryReturnInserted
                , entity
                , transaction: unitOfWork.GetDbTransaction);

            return result;
        }

        public async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            return await dbConn.ExecuteAsync(InsertQuery
                , entities
                , transaction: unitOfWork.GetDbTransaction);
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            entity.UpdateDate = DateTime.Now;
            var result = await dbConn.ExecuteAsync(UpdateByIdQuery, entity, transaction: unitOfWork.GetDbTransaction);
            return;
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            await dbConn.ExecuteAsync(UpdateByIdQuery, entities.Select(obj => obj), transaction: unitOfWork.GetDbTransaction);
            return;
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                return;

            var result = await RemoveAsync(entity) > 0 ? true : false;
            return;
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            await dbConn.ExecuteAsync(DeleteByIdQuery
               , entities.Select(obj => new { obj.Id })
               , transaction: unitOfWork.GetDbTransaction);
            return;
        }

        protected async Task<IPagination<T>> ExecutePaginationQueries(string queryBase, string queryCount, IDefaultFilter parameters)
        {
            var result = dbConn.QueryAsync<T>(queryBase, parameters);

            var count = dbConn.ExecuteScalarAsync<int>(queryCount, parameters);

            await Task.WhenAll(result, count);

            return new Pagination<T>(result.Result.ToList(), count.Result);
        }

        private string GetQueryCount(IDefaultFilter filter)
        {
            var queryBase = GetQueryBase(filter);

            //SetFilter(ref queryBase, sqlExpression.Where);

            return @$"select count(1) from ({queryBase})";
        }

        private void SetPagination(ref string query, ref IDefaultFilter parameters)
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
            return await dbConn.ExecuteAsync(DeleteByIdQuery
                , new { entity.Id }
                , transaction: unitOfWork.GetDbTransaction);
        }

        public void Dispose()
        {
            dbConn?.Close();
            dbConn?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

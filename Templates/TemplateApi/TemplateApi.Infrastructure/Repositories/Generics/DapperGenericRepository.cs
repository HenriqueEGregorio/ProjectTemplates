using System.Data;
using TemplateApi.Domain.Interfaces;
using TemplateApi.Domain.Interfaces.Filters;

namespace TemplateApi.Infrastructure.Repositories.Generics
{
    public class DapperGenericRepository : IDisposable
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IDbConnection _dbConn;

        protected DapperGenericRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            _dbConn = unitOfWork.GetDbConnection;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual string GetQueryBase(IDefaultFilter filter)
        {
            return string.Empty;
        }
    }
}

using System.Data;
using TemplateDapper.Api.Domain.Filters;
using TemplateDapper.Api.Domain.Interfaces;

namespace TemplateDapper.Api.Infrastucture.Repositories.Generics;

public class GenericRepository : IDisposable
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IDbConnection _dbConn;

    protected GenericRepository(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
        _dbConn = unitOfWork.GetDbConnection;
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

    public virtual string GetQueryBase(IDefaultFilter filter)
    {
        return string.Empty;
    }
}

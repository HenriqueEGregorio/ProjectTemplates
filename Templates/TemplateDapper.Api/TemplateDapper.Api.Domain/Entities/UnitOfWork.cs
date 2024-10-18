using System.Data;
using TemplateDapper.Api.Domain.Interfaces;
using TemplateDapper.Api.Domain.Interfaces.Data;

namespace TemplateDapper.Api.Domain.Entities;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbConnection dbConn;
    private IDbTransaction? dbTransaction;

    public IDbConnection GetDbConnection => dbConn;
    public IDbTransaction? GetDbTransaction => dbTransaction;

    public void Dispose()
    {
        DisposeTransaction();
        dbConn?.Close();
        dbConn?.Dispose();
        GC.SuppressFinalize(this);
    }

    public UnitOfWork(IFactory databaseOptions)
    {
        dbConn = databaseOptions.GetDbConnection;
        if (dbConn.State != ConnectionState.Open)
            dbConn.Open();
    }

    public void BeginTransaction()
    {
        dbTransaction = dbConn.BeginTransaction();
    }

    public void Commit()
    {
        dbTransaction?.Commit();
    }

    public void Rollback()
    {
        dbTransaction?.Rollback();
    }

    public void DisposeTransaction()
    {
        dbTransaction?.Dispose();
    }
}

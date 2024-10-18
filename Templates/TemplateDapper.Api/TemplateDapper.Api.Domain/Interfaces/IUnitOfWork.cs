using System.Data;

namespace TemplateDapper.Api.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IDbConnection GetDbConnection { get; }
    IDbTransaction? GetDbTransaction { get; }
    void BeginTransaction();
    void Commit();
    void Rollback();
    void DisposeTransaction();
}

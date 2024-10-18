using System.Data;

namespace TemplateDapper.Api.Domain.Interfaces.Data;

public interface IFactory
{
    IDbConnection GetDbConnection { get; }
}

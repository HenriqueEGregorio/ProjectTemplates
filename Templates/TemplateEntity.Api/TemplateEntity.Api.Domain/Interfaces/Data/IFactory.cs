using System.Data;

namespace TemplateEntity.Api.Domain.Interfaces.Data;

public interface IFactory
{
    IDbConnection GetDbConnection { get; }
}

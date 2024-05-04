using System.Data;

namespace TemplateApi.Domain.Interfaces.Data
{
    public interface IFactory
    {
        IDbConnection GetDbConnection { get; }
    }
}

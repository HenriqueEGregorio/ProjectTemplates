using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;
using TemplateApi.Domain.Interfaces.Data;

namespace TemplateApi.Infrastructure.Data
{
    public  class Factory : IFactory
    {
        private IDbConnection _connection;
        private Settings dataSettings;

        protected string ConnectionString => dataSettings.Default;

        public IDbConnection GetDbConnection => _connection;

        public Factory(IOptions<Settings> dataSettings)
        {
            this.dataSettings = dataSettings.Value;
            _connection = new NpgsqlConnection(ConnectionString);
        }
    }
}

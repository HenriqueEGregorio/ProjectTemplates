﻿using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;
using TemplateApi.Domain.Interfaces.Data;

namespace TemplateApi.Infrastructure.Data;

public  class Factory : IFactory
{
    private readonly IDbConnection _connection;
    private readonly Settings _dataSettings;

    protected string ConnectionString => _dataSettings.Default;

    public IDbConnection GetDbConnection => _connection;

    public Factory(IOptions<Settings> dataSettings)
    {
        _dataSettings = dataSettings.Value;
        _connection = new NpgsqlConnection(ConnectionString);
    }
}

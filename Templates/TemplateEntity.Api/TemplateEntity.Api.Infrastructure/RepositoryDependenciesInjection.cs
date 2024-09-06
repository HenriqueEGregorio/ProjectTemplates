using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateEntity.Api.Domain.Interfaces.Data;
using TemplateEntity.Api.Domain.Interfaces.Repositories;
using TemplateEntity.Api.Infrastructure.Data;
using TemplateEntity.Api.Infrastructure.Repositories;

namespace TemplateEntity.Api.Infrastructure;

public static class RepositoryDependenciesInjection
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        IConfigurationSection dbConnectionSettings = configuration.GetSection("ConnectionStrings");
        services.Configure<Settings>(dbConnectionSettings);
        services.AddScoped<IFactory, Factory>();

        services.AddScoped<IUserEntityRepository, UserEntityRepository>();

        return services;
    }
}

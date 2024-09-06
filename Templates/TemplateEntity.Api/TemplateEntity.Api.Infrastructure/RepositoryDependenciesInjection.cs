using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateEntity.Api.Domain.Interfaces.Data;
using TemplateEntity.Api.Infrastructure.Data;

namespace TemplateEntity.Api.Infrastructure;

public static class RepositoryDependenciesInjection
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        IConfigurationSection dbConnectionSettings = configuration.GetSection("ConnectionStrings");
        services.Configure<Settings>(dbConnectionSettings);

        services.AddScoped<IFactory, Factory>();

        return services;
    }
}

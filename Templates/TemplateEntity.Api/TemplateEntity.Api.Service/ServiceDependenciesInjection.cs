using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateEntity.Api.Service.Services;

namespace TemplateEntity.Api.Service;

public static class ServiceDependenciesInjection
{
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
